using FluentValidation;
using SocialNetwork.API.DTO;
using SocialNetwork.DataAccess;
using System.Linq;

namespace SocialNetwork.API.Validators
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentValidator(SocialNetworkContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Text).NotEmpty();

            RuleFor(x => x.AuthorId)
                   .NotEmpty()
                   .Must(x => context.Users.Any(u => u.Id == x && u.IsActive))
                   .WithMessage("Requested user doesn't exist.");
            RuleFor(x => x.PostId)
                .Must(x => context.Post.Any(p => p.Id == x && p.IsActive))
                .When(x => x.ParentCommentId is null)
                .WithMessage("Requested post doesn't exist.");

            RuleFor(x => x.ParentCommentId)
                    .Must(x => x == null || context.Comment.Any(c => c.Id == x && c.IsActive))
                    .WithMessage("Parent comment doesn't exist.");
                    
        }
    }
}
