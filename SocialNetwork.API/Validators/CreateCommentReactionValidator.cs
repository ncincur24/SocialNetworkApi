using FluentValidation;
using SocialNetwork.API.DTO;
using SocialNetwork.DataAccess;
using System.Linq;

namespace SocialNetwork.API.Validators
{
    public class CreateCommentReactionValidator : AbstractValidator<CreateCommentReactionDto>
    {
        private readonly SocialNetworkContext _context;
        public CreateCommentReactionValidator(SocialNetworkContext context)
        {
            _context = context;

            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("Author is required.")
                .Must(x => context.Users.Any(u => u.IsActive && u.Id == x));

            RuleFor(x => x.ReactionId)
                .NotEmpty().WithMessage("Reaction is required")
                .Must(x => context.Reactions.Any(u => u.IsActive && u.Id == x))
                .WithMessage("Reaction doesnt exist.");

            RuleFor(x => x.CommentId)
                .NotEmpty().WithMessage("Comment is required")
                .Must(x => context.Comment.Any(u => u.IsActive && u.Id == x)).WithMessage("Comment doesnt exist")
                .Must(UserHasNotReacted).WithMessage("You have already reacted to this comment.");
        }

        private bool UserHasNotReacted(CreateCommentReactionDto dto, int? id)
            => !_context.CommentReaction.Any(x => x.UserId == dto.AuthorId && x.CommentId == dto.CommentId);
    }
}
