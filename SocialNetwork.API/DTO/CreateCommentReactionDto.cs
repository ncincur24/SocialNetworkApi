namespace SocialNetwork.API.DTO
{
    public class CreateCommentReactionDto
    {
        public int? AuthorId { get; set; }
        public int? ReactionId { get; set; }
        public int? CommentId { get; set; }

    }
}
