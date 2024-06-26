﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using personApp.DAL.Context;

namespace personApp.DAL.Migrations
{
    [DbContext(typeof(personAppDbContext))]
    [Migration("20220115171626_mg2")]
    partial class mg2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("personApp.DAL.Entites.Ability", b =>
                {
                    b.Property<int>("abilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<string>("abilityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("abilityPoint")
                        .HasColumnType("int");

                    b.HasKey("abilityId");

                    b.HasIndex("PersonID");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PersonBirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("PersonCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PersonSurname")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Ability", b =>
                {
                    b.HasOne("personApp.DAL.Entites.Person", "PersonFK")
                        .WithMany("Abilities")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonFK");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Person", b =>
                {
                    b.Navigation("Abilities");
                });
#pragma warning restore 612, 618
        }
    }
}
