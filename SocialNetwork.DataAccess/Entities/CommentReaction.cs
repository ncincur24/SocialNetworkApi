﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public class CommentReaction
    {
        public int CommentId { get; set; }
        public int ReactionId { get; set; }
        public int UserId { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual User User { get; set; }
        public virtual Reaction Reaction { get; set; }
    }
}
