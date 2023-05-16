using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Configurations
{
    public class GroupChatConfiguration : EntityConfiguration<GroupChat>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<GroupChat> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.HasIndex(x => x.Name);

            builder.HasMany(x => x.GroupChatUsers)
                   .WithOne(x => x.GroupChat)
                   .HasForeignKey(x => x.GroupChatId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
