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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
             builder.HasKey(x => x.Id);
             builder.Property(x=>x.Id).ValueGeneratedOnAdd();
             builder.Property(x=>x.Address).IsRequired();
             builder.Property(x=>x.EMail).IsRequired();
             builder.Property(x=>x.PhoneNumber).IsRequired().HasMaxLength(11);
             
            
            



        }
    }
}
