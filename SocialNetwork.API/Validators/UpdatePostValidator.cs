using FluentValidation;
using SocialNetwork.API.DTO;
using SocialNetwork.API.Extensions;
using System.Linq;

namespace SocialNetwork.API.Validators
{
    public class UpdatePostValidator : AbstractValidator<UpdatePostDto>
    {
        public UpdatePostValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.TextContent).NotEmpty()
                                .When(x => !x.Files.Any())
                                .WithMessage("Text is required when no files are uploaded.");

            RuleFor(x => x.Files).NotEmpty()
                                .When(x => string.IsNullOrEmpty(x.TextContent))
                                .WithMessage("Files are required when no text is provided.")
                                .DependentRules(() =>
                                {
                                    RuleForEach(x => x.Files).Must(x => x.Split(".").Count() == 2)
                                                             .WithMessage("Invalid file path.")
                                                             .Must(x => ValidationExtensions.AllowedExtensions.Contains(x.Split(".")[1]))
                                                             .WithMessage("Unsupported file extension. Supported: " + string.Join(", ", ValidationExtensions.AllowedExtensions));
                                });
        }

        //private bool HasExtension(string x)
        //{

        //}
    }
}
