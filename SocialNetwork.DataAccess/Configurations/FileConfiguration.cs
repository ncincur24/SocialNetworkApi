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
    public class FileConfiguration : EntityConfiguration<File>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<File> builder)
        {
            builder.Property(x => x.Path)
                .IsRequired().HasMaxLength(250);
        }
    }
}
