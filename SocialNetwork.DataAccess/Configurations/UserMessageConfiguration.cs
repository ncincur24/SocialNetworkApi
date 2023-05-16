using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Configurations
{
    public class MessageConfiguration : EntityConfiguration<Message>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Message> builder)
        {
            builder.HasOne(x => x.ParentMessage)
                .WithMany(x => x.ChildMessages)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
