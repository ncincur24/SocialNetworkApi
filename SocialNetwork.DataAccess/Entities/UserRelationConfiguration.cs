using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Entities
{
    public class UserRelationConfiguration : EntityConfiguration<UserRelation>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<UserRelation> builder)
        {
            builder.HasOne(x => x.Initiator)
                   .WithMany(x => x.SentRequests)
                   .HasForeignKey(x => x.InitiatorId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(x => x.Receiver)
                   .WithMany(x => x.ReceivedRequests)
                   .HasForeignKey(x => x.ReceiverId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
