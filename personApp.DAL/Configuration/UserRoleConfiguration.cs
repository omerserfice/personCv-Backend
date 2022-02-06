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
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.RoleId).IsRequired();

            builder.HasOne(p => p.RoleFK).WithMany(p => p.UserRoles).HasForeignKey(p => p.RoleId);
            builder.HasOne(p => p.UserFK).WithMany(p => p.UserRoles).HasForeignKey(p => p.UserId);


        }
    }
}
