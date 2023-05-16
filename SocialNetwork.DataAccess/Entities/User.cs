using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ProfileImageId { get; set; }

        public virtual File ProfileImage { get; set; }
        public virtual ICollection<GroupChatUser> GroupChatUsers { get; set; } = new List<GroupChatUser>();
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<UserRelation> SentRequests { get; set; } = new HashSet<UserRelation>();
        public virtual ICollection<UserRelation> ReceivedRequests { get; set; } = new HashSet<UserRelation>();
        public virtual ICollection<UserMessage> SentUserMessages { get; set; }
        public virtual ICollection<UserMessage> ReceivedUserMessages { get; set; }
        public virtual ICollection<GroupChatMessage> SentGroupMessages { get; set; }
    }
}
