using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Configuration
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasKey(x => x.Id);  
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.AboutTitle).IsRequired().HasMaxLength(200);
            builder.Property(x => x.AboutDetail).IsRequired();
            builder.Property(x => x.AboutImage).IsRequired();
            

        }
    }
}
