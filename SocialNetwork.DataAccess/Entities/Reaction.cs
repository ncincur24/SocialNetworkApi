using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public class Reaction : Entity
    {
        public string Name { get; set; }
        public int FileId { get; set; }
        public virtual File Icon { get; set; }
    }
}
