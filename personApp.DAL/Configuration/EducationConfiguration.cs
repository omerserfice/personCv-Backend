using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using personApp.DAL.DTO.Education;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Configuration
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.SchoolName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.EducationDetail).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.Departmen).HasMaxLength(100).IsRequired();
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.PersonId).IsRequired();
            builder.HasOne(x => x.PersonFK).WithMany(x => x.Educations).HasForeignKey(p => p.PersonId);
        }
    }
}
