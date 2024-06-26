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
    [Migration("20220726191240_init4")]
    partial class init4
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AbilityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("AbilityPoint")
                        .HasColumnType("int");

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

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("personApp.DAL.Entites.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

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

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Certificates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<string>("CertificateDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertificateImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertificateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.Property<string>("Organisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Github")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<string>("Departmen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EducationDetail")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Departman")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateOfWork")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateOfWork")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("WorkDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Message", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Person", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Project", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectGithubLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Role", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CDate = new DateTime(2022, 7, 26, 22, 12, 40, 193, DateTimeKind.Local).AddTicks(5244),
                            CUserId = 0,
                            IsDeleted = false,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CDate = new DateTime(2022, 7, 26, 22, 12, 40, 196, DateTimeKind.Local).AddTicks(944),
                            CUserId = 0,
                            IsDeleted = false,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("personApp.DAL.Entites.User", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TCNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("TCNo");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("personApp.DAL.Entites.UserRole", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Ability", b =>
                {
                    b.HasOne("personApp.DAL.Entites.Person", "PersonFK")
                        .WithMany("Abilities")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonFK");
                });

            modelBuilder.Entity("personApp.DAL.Entites.About", b =>
                {
                    b.HasOne("personApp.DAL.Entites.Person", "PersonFK")
                        .WithMany("Abouts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonFK");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Certificates", b =>
                {
                    b.HasOne("personApp.DAL.Entites.Person", "PersonFK")
                        .WithMany("Certificates")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonFK");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Contact", b =>
                {
                    b.HasOne("personApp.DAL.Entites.Person", "PersonFK")
                        .WithMany("Contacts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonFK");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Education", b =>
                {
                    b.HasOne("personApp.DAL.Entites.Person", "PersonFK")
                        .WithMany("Educations")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonFK");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Experience", b =>
                {
                    b.HasOne("personApp.DAL.Entites.Person", "PersonFK")
                        .WithMany("Experiences")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonFK");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Project", b =>
                {
                    b.HasOne("personApp.DAL.Entites.Person", "PersonFK")
                        .WithMany("Projects")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonFK");
                });

            modelBuilder.Entity("personApp.DAL.Entites.UserRole", b =>
                {
                    b.HasOne("personApp.DAL.Entites.Role", "RoleFK")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("personApp.DAL.Entites.User", "UserFK")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleFK");

                    b.Navigation("UserFK");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Person", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("Abouts");

                    b.Navigation("Certificates");

                    b.Navigation("Contacts");

                    b.Navigation("Educations");

                    b.Navigation("Experiences");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("personApp.DAL.Entites.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("personApp.DAL.Entites.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
