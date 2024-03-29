﻿// <auto-generated />
using System;
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AOM.FIFA.ManagerPlayer.Persistence.Migrations
{
    [DbContext(typeof(FIFAManagerPlayerDbContext))]
    [Migration("20220502231133_CreatingPlayerTableMigration")]
    partial class CreatingPlayerTableMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Application.Club.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Application.League.Entities.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("League");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Application.Nation.Entities.Nation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Nation");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Application.Player.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("AttackWorkRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("CommonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Defending")
                        .HasColumnType("int");

                    b.Property<string>("DefenseWorkRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dribbling")
                        .HasColumnType("int");

                    b.Property<string>("Foot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("LastName")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationId")
                        .HasColumnType("int");

                    b.Property<int>("Pace")
                        .HasColumnType("int");

                    b.Property<int>("Passing")
                        .HasColumnType("int");

                    b.Property<int>("Physicality")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rarity")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("Shooting")
                        .HasColumnType("int");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.Property<string>("TotalStats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("NationId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Application.Club.Entities.Club", b =>
                {
                    b.HasOne("AOM.FIFA.ManagerPlayer.Application.League.Entities.League", "League")
                        .WithMany("Clubs")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Application.Player.Entities.Player", b =>
                {
                    b.HasOne("AOM.FIFA.ManagerPlayer.Application.Club.Entities.Club", "Club")
                        .WithMany("Player")
                        .HasForeignKey("ClubId");

                    b.HasOne("AOM.FIFA.ManagerPlayer.Application.Nation.Entities.Nation", "Nation")
                        .WithMany("Players")
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Nation");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Application.Club.Entities.Club", b =>
                {
                    b.Navigation("Player");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Application.League.Entities.League", b =>
                {
                    b.Navigation("Clubs");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Application.Nation.Entities.Nation", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
