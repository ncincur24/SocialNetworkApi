using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public class HashTag : Entity
    {
        public string TagValue { get; set; }

        public virtual ICollection<HashTagPost> HashTagPosts { get; set; } = new HashSet<HashTagPost>();
    }
}
