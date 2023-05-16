using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public class HashTagPost
    {
        public int PostId { get; set; }
        public int HashTagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual HashTag HashTag { get; set; }
    }
}
