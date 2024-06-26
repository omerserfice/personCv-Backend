﻿using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseSqlServer("Server=89.252.185.155\\MSSQLSERVER2019;Database=neoverde_personCvDatabase;User Id=neoverde_person;Password=p2f209Lw^");
            //vt kullanici şfire p2f209Lw^

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Certificates> Certificates { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


    }
}
