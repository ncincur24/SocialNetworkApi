namespace SocialNetwork.API.DTO
{
    public class CreateReactionDto
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
    }

    //CQRS - Command Query Responsibility Seggregation
    public class ReadReactionDto
    {
        public int Id { get; set; }
        public string ReactionName { get; set; }
        public string FilePath { get; set; }
    }
}
