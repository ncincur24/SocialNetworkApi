using System.Collections.Generic;

namespace SocialNetwork.API.DTO
{
    public class UpdatePostDto
    {
        public string TextContent { get; set; }
        public IEnumerable<string> HashTags { get; set; } = new List<string>();
        public IEnumerable<string> Files { get; set; } = new List<string>();
    }
}
