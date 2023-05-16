using System.Collections.Generic;

namespace SocialNetwork.API.DTO
{
    public class CreatePostDto
    {
        public string Text { get; set; }
        public int? UserId { get; set; }
        public IEnumerable<string> HashTags { get; set; } = new List<string>();
        public IEnumerable<string> Files { get; set; } = new List<string>();
    }
}
