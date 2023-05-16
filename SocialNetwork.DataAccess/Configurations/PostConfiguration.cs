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
    public class PostConfiguration : EntityConfiguration<Post>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Post> builder)
        {

            builder.HasOne(x => x.Author)
                   .WithMany(x => x.Posts)
                   .HasForeignKey(x => x.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.PostReactions)
                   .WithOne(x => x.Post)
                   .HasForeignKey(x => x.PostId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.PostHashTags)
                   .WithOne(x => x.Post)
                   .HasForeignKey(x => x.PostId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
