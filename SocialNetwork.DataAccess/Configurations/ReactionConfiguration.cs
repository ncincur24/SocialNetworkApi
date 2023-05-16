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
    public class ReactionConfiguration : EntityConfiguration<Reaction>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Reaction> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.Icon)
                   .WithMany()
                   .HasForeignKey(x => x.FileId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
