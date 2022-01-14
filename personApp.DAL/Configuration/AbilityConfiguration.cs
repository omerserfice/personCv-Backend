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
            builder.HasKey(p => p.abilityId);
            builder.Property(p => p.abilityId).ValueGeneratedOnAdd();
            builder.Property(p => p.abilityName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.abilityPoint).IsRequired();
            builder.HasOne(p => p.PersonFK).WithMany(p => p.Abilities).HasForeignKey(p => p.PersonID);
         }
    }
}
