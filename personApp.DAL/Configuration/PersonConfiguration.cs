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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.PersonName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.PersonSurname).HasMaxLength(150).IsRequired();
            builder.Property(p=>p.PersonCity).IsRequired();
            builder.Property(p=>p.PersonBirthDay).IsRequired();

        }
    }
}
