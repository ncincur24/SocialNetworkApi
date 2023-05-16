using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public class GroupChat : Entity
    {
        public string Name { get; set; }
        public ICollection<GroupChatUser> GroupChatUsers { get; set; } = new HashSet<GroupChatUser>();
        public ICollection<GroupChatMessage> GroupChatMessages { get; set; } = new HashSet<GroupChatMessage>();
    }
}
