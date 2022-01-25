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
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificates>
    {
        public void Configure(EntityTypeBuilder<Certificates> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p=>p.Id).ValueGeneratedOnAdd();
            builder.Property(p=>p.CertificateName).IsRequired();
            builder.Property(P=>P.CertificateImage).IsRequired();
            builder.Property(p => p.CertificateDetail).IsRequired();
            builder.Property(p=>p.Organisation).IsRequired();
            builder.Property(p => p.DateOfIssue).IsRequired();  
        }
    }
}
