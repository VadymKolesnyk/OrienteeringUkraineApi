﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrienteeringUkraine.Data;

namespace OrienteeringUkraine.Data.Migrations
{
    [DbContext(typeof(OrienteeringUkraineContext))]
    partial class OrienteeringUkraineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Chip")
                        .HasColumnType("int");

                    b.Property<int>("EventGroupId")
                        .HasColumnType("int");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserLogin", "EventGroupId");

                    b.HasIndex("EventGroupId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("InfoLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsApplicationOpen")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Location")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("OrganizerLogin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("ResultsLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Date");

                    b.HasIndex("OrganizerLogin");

                    b.HasIndex("RegionId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.EventGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("EventId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("EventGroups");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(31)
                        .HasColumnType("nvarchar(31)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.LoginData", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Login");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.User", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Login");

                    b.HasIndex("ClubId");

                    b.HasIndex("RegionId");

                    b.HasIndex("RoleId");

                    b.HasIndex("Surname");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Application", b =>
                {
                    b.HasOne("OrienteeringUkraine.Domain.Entities.EventGroup", "EventGroup")
                        .WithMany("Applications")
                        .HasForeignKey("EventGroupId")
                        .HasConstraintName("FK_Applications_EventGroups")
                        .IsRequired();

                    b.HasOne("OrienteeringUkraine.Domain.Entities.User", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserLogin")
                        .HasConstraintName("FK_Applications_Users")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Event", b =>
                {
                    b.HasOne("OrienteeringUkraine.Domain.Entities.User", "Organizer")
                        .WithMany("Events")
                        .HasForeignKey("OrganizerLogin")
                        .HasConstraintName("FK_Events_Users");

                    b.HasOne("OrienteeringUkraine.Domain.Entities.Region", "Region")
                        .WithMany("Events")
                        .HasForeignKey("RegionId")
                        .HasConstraintName("FK_Events_Regions")
                        .IsRequired();

                    b.Navigation("Organizer");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.EventGroup", b =>
                {
                    b.HasOne("OrienteeringUkraine.Domain.Entities.Event", "Event")
                        .WithMany("EventGroups")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_EventGroups_Events")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrienteeringUkraine.Domain.Entities.Group", "Group")
                        .WithMany("EventGroups")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_EventGroups_Groups")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.LoginData", b =>
                {
                    b.HasOne("OrienteeringUkraine.Domain.Entities.User", "User")
                        .WithOne("LoginData")
                        .HasForeignKey("OrienteeringUkraine.Domain.Entities.LoginData", "Login")
                        .HasConstraintName("FK_Users_Logins")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.User", b =>
                {
                    b.HasOne("OrienteeringUkraine.Domain.Entities.Club", "Club")
                        .WithMany("Users")
                        .HasForeignKey("ClubId")
                        .HasConstraintName("FK_Users_Clubs");

                    b.HasOne("OrienteeringUkraine.Domain.Entities.Region", "Region")
                        .WithMany("Users")
                        .HasForeignKey("RegionId")
                        .HasConstraintName("FK_Users_Regions")
                        .IsRequired();

                    b.HasOne("OrienteeringUkraine.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_Users_Roles")
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Region");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Club", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Event", b =>
                {
                    b.Navigation("EventGroups");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.EventGroup", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Group", b =>
                {
                    b.Navigation("EventGroups");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Region", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("OrienteeringUkraine.Domain.Entities.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Events");

                    b.Navigation("LoginData");
                });
#pragma warning restore 612, 618
        }
    }
}
