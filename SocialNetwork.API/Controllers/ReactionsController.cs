using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.API.DTO;
using SocialNetwork.API.Searches;
using SocialNetwork.DataAccess;
using SocialNetwork.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//SOLID
//Single Responsibility
//Open-Closed principle
//Liskov Substitution principle
//Interface Seggregation
//Dependency Inversion (nije dependency injection)

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionsController : ControllerBase
    {
        private SocialNetworkContext _context;

        public ReactionsController(SocialNetworkContext context)
        {
            _context = context;
           
        }

        // GET: api/<ReactionsController>
        [HttpGet]
        public IActionResult Get([FromQuery] ReactionSearch search)
        {
            var query = _context.Reactions.Include(x => x.Icon).AsQueryable();
            
            if(!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }

            var result = query.Select(x => new ReadReactionDto
                                          {
                                                FilePath = x.Icon.Path,
                                                Id = x.Id,
                                                ReactionName = x.Name,
                                          })
                               .OrderBy(x => x.ReactionName)
                               .ToList();

            return Ok(result);
        }

        // GET api/<ReactionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Reaction reaction = _context.Reactions
                                .Include(x => x.Icon)
                                .FirstOrDefault(x => x.Id == id);

            if (reaction == null)
            {
                return NotFound();
            }

            return Ok(new ReadReactionDto
            {
                Id = reaction.Id,
                FilePath = reaction.Icon.Path,
                ReactionName = reaction.Name
            });
        }

        // POST api/<ReactionsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateReactionDto dto)
        {
            try
            {
                List<string> errors = new List<string>();
                if(string.IsNullOrEmpty(dto.Name))
                {
                    errors.Add("Name is required");
                }

                if(string.IsNullOrEmpty(dto.IconPath))
                {
                    errors.Add("Icon is required");
                }
                
                if(errors.Any())
                {
                    return UnprocessableEntity(errors);
                }


                bool reactionExists = _context.Reactions.Any(x => x.Name.ToLower() ==
                                                                 dto.Name.ToLower());
                
                if(reactionExists)
                {
                    return Conflict(new { message = "Reaciton with the same name already exists." });
                }
                
                File file = new File
                {
                    Path = dto.IconPath,
                    Size = 300
                };

                Reaction reaction = new Reaction
                {
                    Name = dto.Name,
                    Icon = file
                };

                //Entity State
                //Added, Modified, Detached, Unchanged, Deleted

                _context.Reactions.Add(reaction);

                _context.SaveChanges();

                return StatusCode(201);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "Unexpected error has occured."
                });
            }
        }

        // PUT api/<ReactionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReactionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
