using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Configurations
{
    public class HashTagConfiguration : EntityConfiguration<HashTag>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<HashTag> builder)
        {
            builder.Property(x => x.TagValue)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(x => x.TagValue).IsUnique();

            builder.HasMany(x => x.HashTagPosts)
                    .WithOne(x => x.HashTag)
                    .HasForeignKey(x => x.HashTagId)
                    .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
