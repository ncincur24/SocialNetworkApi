using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.API.DTO;
using SocialNetwork.API.ErrorLogging;
using SocialNetwork.API.Extensions;
using SocialNetwork.API.Searches;
using SocialNetwork.API.Validators;
using SocialNetwork.DataAccess;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : LocalController
    {
        private SocialNetworkContext _context;

        public PostsController(SocialNetworkContext context, IErrorLogger logger)
            :base(logger)
        {
            _context = context;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public IActionResult Get([FromQuery] PostSearch search)
        {
            try
            {
                var query = _context.Post
                               .Include(x => x.Author)
                               .Where(x => x.IsActive && x.DeletedAt == null);

                if (!string.IsNullOrEmpty(search.HashTag))
                {
                    query = query.Where(x => x.PostHashTags.Any(ht => ht.HashTag.TagValue.ToLower() == search.HashTag.ToLower()));
                }

                if (!string.IsNullOrEmpty(search.Username))
                {
                    query = query.Where(x => x.Author.Username.ToLower() == search.Username.ToLower());
                }

                if (search.HasComments.HasValue)
                {
                    //kada stigne true - vracamo objave koje imaju komentare
                    //kada stigne false - vracamo objave bez komentara
                    //if(search.HasComments.Value)
                    //{
                    //    query = query.Where(x => x.Comments.Any());
                    //} else
                    //{
                    //    query = query.Where(x => !x.Comments.Any());
                    //}
                    query = query.Where(x => x.Comments.Any() == search.HasComments.Value);
                }

                if (search.DateFrom.HasValue)
                {
                    query = query.Where(x => x.CreatedAt >= search.DateFrom.Value);
                }

                if (search.DateTo.HasValue)
                {
                    query = query.Where(x => x.CreatedAt <= search.DateTo.Value);
                }

                IEnumerable<PostDto> result = query.Select(x => new PostDto
                {
                    Id = x.Id,
                    Username = x.Author.Username,
                    CreatedAt = x.CreatedAt,
                    Text = x.TextContent,
                    HashTags = x.PostHashTags.Select(y => y.HashTag.TagValue),
                    Reactions = x.PostReactions.Select(pr => new PostReactionDto
                    {
                        Icon = pr.Reaction.Icon.Path,
                        Id = pr.Id,
                        ReactedAt = pr.CreatedAt,
                        Username = pr.User.Username
                    }),
                    Files = x.PostFiles.Select(x => new PostFileDto
                    {
                        Id = x.FileId,
                        Path = x.File.Path
                    }),
                    Comments = x.Comments.Select(x => new CommentDto
                    {
                        Id = x.Id,
                        Text = x.Text,
                        Username = x.Author.Username,
                        ParentId = x.ParentCommentId,
                        CommentedAt = x.CreatedAt,
                        Reactions = x.Reactions.Select(r => new PostReactionDto
                        {
                            Id = r.ReactionId,
                            Icon = r.Reaction.Icon.Path,
                            Username = r.User.Username,
                        })
                    })
                }).ToList();

                foreach (var post in result)
                {
                    foreach (var comment in post.Comments)
                    {
                        //if(comment.ParentId.HasValue)
                        //{

                        //}
                        HandleSubcomments(comment);
                    }
                }

                return Ok(result);
            }
            catch (System.Exception ex) //neočekivan izuzetak
            {
                //
                return Error(ex);
            }
        }

        private void HandleSubcomments(CommentDto dto)
        {
            var context = new SocialNetworkContext();

            var subcomments = context.Comment.Where(x => x.ParentCommentId == dto.Id)
                                             .Select(x => new CommentDto
                                             {
                                                 Id = x.Id,
                                                 ParentId = x.ParentCommentId,
                                                 Text = x.Text,
                                                 Username = x.Author.Username,
                                                 CommentedAt = x.CreatedAt,
                                                 Reactions = x.Reactions.Select(r => new PostReactionDto
                                                 {
                                                     Id = r.ReactionId,
                                                     Icon = r.Reaction.Icon.Path,
                                                     Username = r.User.Username,
                                                 })
                                             }).ToList();

            dto.ChildComments = subcomments;

            foreach(var sub in subcomments)
            {
                HandleSubcomments(sub);
            }
        }

        //// GET api/<PostsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<PostsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreatePostDto dto,
                                  [FromServices] CreatePostValidator validator)
        {

            ValidationResult result = validator.Validate(dto);

            if (!result.IsValid)
            {
                return result.ToUnprocessableEntity();
                //var errors = result.Errors.Select(x => new ClientErrorDto
                //            {
                //                Error = x.ErrorMessage,
                //                Property = x.PropertyName
                //            });

                //return UnprocessableEntity(errors);
            }

            List<HashTag> hashTags = new List<HashTag>();

            foreach (var hashTag in dto.HashTags)
            {
                HashTag fromDb = _context.HashTag.Where(x => x.TagValue == hashTag && x.IsActive)
                                                .FirstOrDefault();

                if (fromDb == null)
                {
                    fromDb = new HashTag
                    {
                        TagValue = hashTag,
                        IsActive = true
                    };
                    _context.HashTag.Add(fromDb);
                }

                hashTags.Add(fromDb);
            }

            Post post = new Post();
            post.TextContent = dto.Text;
            post.AuthorId = dto.UserId.Value;
            post.PostHashTags = hashTags.Select(x => new HashTagPost
            {
                HashTag = x
            }).ToList();
            post.PostFiles = dto.Files.Select(x => new DataAccess.Entities.PostFile
            {
                File = new File
                {
                    Path = x,
                    Size = 100
                }
            }).ToList();

            _context.Add(post);
            _context.SaveChanges();


            return StatusCode(201);
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var post = _context.Post.Find(id);
                if (post == null || !post.IsActive || post.DeletedAt.HasValue)
                {
                    return NotFound();
                }

                post.DeletedAt = DateTime.UtcNow;
                post.IsActive = false;

                //context.Post.Remove(post);

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePostDto dto, 
                                         [FromServices] UpdatePostValidator validator)
        {
            //eager loading
            var post = _context.Post.Include(x => x.PostHashTags)
                                        .ThenInclude(x => x.HashTag)
                                    .Include(x => x.PostFiles)
                                        .ThenInclude(x => x.File)
                                    .FirstOrDefault(x => x.Id == id && x.IsActive);
            if(post == null)
            {
                return NotFound();
            }

            var result = validator.Validate(dto);

            if(!result.IsValid)
            {
                return result.ToUnprocessableEntity();
            }

            if(dto.HashTags == null || !dto.HashTags.Any())
            {
                post.PostHashTags.Clear();
            } else
            {
                foreach(var hashTag in dto.HashTags)
                {
                    if(post.PostHashTags.Any(x => x.HashTag.TagValue == hashTag))
                    {
                        continue;
                    }

                    var dbHashTag = _context.HashTag.FirstOrDefault(x => x.IsActive && 
                                                                         x.TagValue == hashTag);

                    if(dbHashTag == null)
                    {
                        post.PostHashTags.Add(new HashTagPost
                        {
                            HashTag = new HashTag
                            {
                                TagValue = hashTag,
                            }
                        });
                    } else
                    {
                        post.PostHashTags.Add(new HashTagPost
                        {
                            HashTag = dbHashTag
                        });
                    }

                    var hashTagsToRemove = post.PostHashTags.Where(x => !dto.HashTags.Contains(x.HashTag.TagValue));
                    _context.HashTagPost.RemoveRange(hashTagsToRemove); 
                }
            }

            post.TextContent = dto.TextContent;

            post.PostFiles = dto.Files.Select(x => new PostFile
            {
                File = new File
                {
                    Path = x,
                    Size = 100
                }
            }).ToHashSet();

            _context.Entry(post).State = EntityState.Modified;

            _context.SaveChanges();

            return NoContent();
        }

    }
}
