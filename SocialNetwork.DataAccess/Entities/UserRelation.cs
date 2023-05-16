using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public class UserRelation : Entity
    {
        public RelationStatus Status { get; set; }
        public int InitiatorId { get; set; }
        public int ReceiverId { get; set; }

        public virtual User Initiator { get; set; }
        public virtual User Receiver { get; set; }
    }
}
