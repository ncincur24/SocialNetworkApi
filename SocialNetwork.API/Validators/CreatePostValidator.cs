using FluentValidation;
using SocialNetwork.API.DTO;
using SocialNetwork.DataAccess;
using System.Linq;

namespace SocialNetwork.API.Validators
{
    public class CreatePostValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostValidator(SocialNetworkContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.UserId).NotNull()
                                  .WithMessage("UserId is required.")
                                  .Must(x => context.Users.Any(u => u.Id == x && u.IsActive))
                                  .WithMessage("User with provided id doesn't exist.");
                                  
            RuleFor(x => x.Text).NotEmpty()
                                .When(x => !x.Files.Any())
                                .WithMessage("Text is required when no files are uploaded.");

            RuleFor(x => x.Files).NotEmpty()
                                .When(x => string.IsNullOrEmpty(x.Text))
                                .WithMessage("Files are required when no text is provided.");
        }
    }
}
