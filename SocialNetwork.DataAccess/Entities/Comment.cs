using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public class Comment : Entity
    {
        public int PostId { get; set; }
        public int AuthorId { get; set; }
        public int? ParentCommentId { get; set; }
        public string Text { get; set; }


        public virtual Comment ParentComment { get; set; }
        public virtual ICollection<Comment> ChildComments { get; set; }
        public virtual User Author { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<CommentReaction> Reactions { get; set; } = new HashSet<CommentReaction>();
    }
}
