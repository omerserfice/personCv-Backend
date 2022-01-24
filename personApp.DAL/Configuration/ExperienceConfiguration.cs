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
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CompanyName).HasMaxLength(100).IsRequired();
            builder.Property(p=>p.Departman).IsRequired();
            builder.Property(p=>p.WorkPosition).IsRequired();
            builder.Property(p => p.StartDateOfWork).IsRequired();
            builder.Property(p => p.EndDateOfWork).IsRequired();
            builder.Property(p=>p.WorkDetail).IsRequired();
        }
    }
}
