using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.DTO;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.API.Extensions
{
    public static class ValidationExtensions
    {

        public static IEnumerable<string> AllowedExtensions => new List<string>
        {
            "jpg", "jpeg", "mp4", "gif", "png"
        };


        public static UnprocessableEntityObjectResult ToUnprocessableEntity(this ValidationResult result)
        {
            var errors = result.Errors.Select(x => new ClientErrorDto
            {
                Error = x.ErrorMessage,
                Property = x.PropertyName
            });

            return new UnprocessableEntityObjectResult(errors);
        }
    }
}
