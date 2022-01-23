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
    public class AbilityConfiguration : IEntityTypeConfiguration<Ability>
    {
        public void Configure(EntityTypeBuilder<Ability> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.AbilityName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.AbilityPoint).IsRequired();
        }
    }
}