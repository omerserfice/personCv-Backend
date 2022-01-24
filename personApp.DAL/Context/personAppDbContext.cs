using Microsoft.EntityFrameworkCore;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Context
{
    public class personAppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=OMER\\SQLExpress;Database=personCvDatabase;Trusted_Connection=True;");
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
    }
}
