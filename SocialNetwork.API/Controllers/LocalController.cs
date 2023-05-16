using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.ErrorLogging;
using System;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class LocalController : ControllerBase
    {
        private IErrorLogger _logger;
        protected LocalController(IErrorLogger logger)
        {
            _logger = logger;
        }
        protected IActionResult Error(Exception ex)
        {
            //Logovati izuzetak
            /*
                -- Jedinstven identifikator greske, kako bismo je locirali (šalje se krajnjem korisniku)
                -- Datum i vreme kada je greška nastala
                -- Korisnik u app (opciono, na nekim funkcionalnostima korisnik nije ulogovan)
                -- ex.Message - opis greške    
                -- ex.StackTrace - Putanja stack-a gde je nastala greška
            */
            Guid errorId = Guid.NewGuid();
            AppError error = new AppError
            {
                Exception = ex,
                ErrorId = errorId,
                Username = "test"
            };
            _logger.Log(error);
            return StatusCode(500, new { message = $"There was an error, please contact support with this error code: {errorId}." });
        }
    }
}
