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
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p=>p.Name).IsRequired();
            builder.Property(p => p.Surname).IsRequired();
            builder.Property(p => p.Mail).IsRequired();
            builder.Property(p=>p.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(p => p.Subject).IsRequired();
            builder.Property(p => p.MessageDetail).IsRequired();
        }
    }
}
