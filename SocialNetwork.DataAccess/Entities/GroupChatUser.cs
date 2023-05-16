using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public class GroupChatUser
    {
        public int GroupChatId { get; set; }
        public int UserId { get; set; }
        public DateTime AddedAt { get; set; }
        public virtual GroupChat GroupChat { get; set; }
        public virtual User User { get; set; }
    }
}
