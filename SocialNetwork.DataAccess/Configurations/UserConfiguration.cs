using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Username)
                .IsRequired().HasMaxLength(25);

            builder.HasIndex(x => x.Username).IsUnique();

            builder.HasOne(x => x.ProfileImage)
                   .WithMany()
                   .HasForeignKey(x => x.ProfileImageId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GroupChatUsers)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
