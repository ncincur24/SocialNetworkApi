using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public abstract class Message : Entity
    {
        public int SenderId { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }
        public DateTime? ReceivedAt { get; set; }
        
        
        public virtual User Sender { get; set; }
        public virtual Message ParentMessage { get; set; }
        public virtual ICollection<Message> ChildMessages { get; set;}
    }

    public class UserMessage : Message
    {
        public int ReceiverId { get; set; }
        public DateTime? SeenAt { get; set; }

        public virtual User Receiver { get; set; }
    }

    public class GroupChatMessage : Message
    {
        public int GroupChatId { get; set; }

        public virtual GroupChat GroupChat { get; set; }
    }
}
