﻿// <auto-generated />
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AOM.FIFA.ManagerPlayer.Persistence.Migrations
{
    [DbContext(typeof(FIFAManagerPlayerDbContext))]
    [Migration("20220501165237_AddingNationTableMigration")]
    partial class AddingNationTableMigration
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

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Application.Club.Entities.Club", b =>
                {
                    b.HasOne("AOM.FIFA.ManagerPlayer.Application.League.Entities.League", "League")
                        .WithMany("Clubs")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Application.League.Entities.League", b =>
                {
                    b.Navigation("Clubs");
                });
#pragma warning restore 612, 618
        }
    }
}
