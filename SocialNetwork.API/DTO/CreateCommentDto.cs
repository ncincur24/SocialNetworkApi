namespace SocialNetwork.API.DTO
{
    public class CreateCommentDto
    {
        public int? PostId { get; set; }
        public int? AuthorId { get; set; }
        public int? ParentCommentId { get; set; }
        public string Text { get; set; }
    }
}
