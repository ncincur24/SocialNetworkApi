using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.DTO;
using SocialNetwork.API.ErrorLogging;
using SocialNetwork.API.Extensions;
using SocialNetwork.API.Validators;
using SocialNetwork.DataAccess;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : LocalController
    {
        private SocialNetworkContext _context;

        public CommentsController(SocialNetworkContext context, IErrorLogger logger)
            : base(logger)
        {
            _context = context;
        }

        // POST api/<CommentsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCommentDto dto, [FromServices] CreateCommentValidator validator)
        {
            try
            {
                var result = validator.Validate(dto);

                if (!result.IsValid)
                {
                    return result.ToUnprocessableEntity();
                }

                int postId = dto.PostId.GetValueOrDefault();

                if (dto.ParentCommentId.HasValue)
                {
                    var parentComment = _context.Comment.Find(dto.ParentCommentId.Value);
                    postId = parentComment.PostId;
                }

                _context.Comment.Add(new DataAccess.Entities.Comment
                {
                    AuthorId = dto.AuthorId.Value,
                    PostId = postId,
                    ParentCommentId = dto.ParentCommentId,
                    Text = dto.Text
                });

                _context.SaveChanges();

                return StatusCode(201);
            }
            catch (System.Exception ex)
            {
                return Error(ex);
            }
        }

        //ruta: DELETE /api/comments/{id} 
        //podaci id
        // 204|500|404
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var comment = _context.Comment.Find(id);

                if(comment == null || !comment.IsActive)
                {
                    return NotFound();
                }

                comment.IsActive = false;
                comment.DeletedAt = DateTime.UtcNow;
                comment.DeletedBy = "Test user";

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        // /api/comments/5/reactions

        [HttpPost("{id}/reactions")]
        public IActionResult AddReaction(int id, 
            [FromBody] CreateCommentReactionDto dto,
            [FromServices] CreateCommentReactionValidator validator)
        {
            dto.CommentId = id;

            var result = validator.Validate(dto);

            if(!result.IsValid)
            {
                return result.ToUnprocessableEntity();
            }

            _context.CommentReaction.Add(new DataAccess.Entities.CommentReaction
            {
                CommentId = dto.CommentId.Value,
                ReactionId = dto.ReactionId.Value,
                UserId = dto.AuthorId.Value
            });

            _context.SaveChanges();

            return StatusCode(201);
        }

        [HttpPut("{id}/reactions")]
        public IActionResult UpdateReaction(int id,
           [FromBody] CreateCommentReactionDto dto,
           [FromServices] CreateCommentReactionValidator validator)
        {
            dto.CommentId = id;

            var previousReaction = _context.CommentReaction
                                        .FirstOrDefault(x => x.UserId == dto.AuthorId && 
                                                             x.CommentId == dto.CommentId);

            if(previousReaction == null)
            {
                return NotFound();
            }

            _context.CommentReaction.Remove(previousReaction);
            _context.SaveChanges();

            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                return result.ToUnprocessableEntity();
            }

            _context.CommentReaction.Add(new DataAccess.Entities.CommentReaction
            {
                CommentId = dto.CommentId.Value,
                ReactionId = dto.ReactionId.Value,
                UserId = dto.AuthorId.Value
            });

            _context.SaveChanges();

            return StatusCode(201);
        }
    }
}
