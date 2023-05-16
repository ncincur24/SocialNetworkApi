using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public class Post : Entity
    {
        public int AuthorId { get; set; }
        public string TextContent { get; set; }
        

        public virtual User Author  { get; set; }
        public virtual ICollection<PostFile> PostFiles { get; set; } = new HashSet<PostFile>();
        public virtual ICollection<PostReaction> PostReactions { get; set; } = new HashSet<PostReaction>();
        public virtual ICollection<HashTagPost> PostHashTags { get; set; } = new HashSet<HashTagPost>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
