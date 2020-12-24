﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGym.API.Persistence;

namespace SmartGym.API.Persistence.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20201224151530_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SmartGym.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.PersonalTrainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdTrainingCenter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("IdTrainingCenter");

                    b.ToTable("PersonalTrainers");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdPersonalTrainer")
                        .HasColumnType("int");

                    b.Property<int>("IdTrainingCenter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("IdPersonalTrainer");

                    b.HasIndex("IdTrainingCenter");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.TrainingCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("TrainingCenters");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.PersonalTrainer", b =>
                {
                    b.HasOne("SmartGym.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("SmartGym.Domain.Entities.TrainingCenter", "TrainingCenter")
                        .WithMany("PersonalTrainers")
                        .HasForeignKey("IdTrainingCenter")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("TrainingCenter");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.Student", b =>
                {
                    b.HasOne("SmartGym.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("SmartGym.Domain.Entities.PersonalTrainer", "PersonalTrainer")
                        .WithMany("Students")
                        .HasForeignKey("IdPersonalTrainer")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartGym.Domain.Entities.TrainingCenter", "TrainingCenter")
                        .WithMany("Students")
                        .HasForeignKey("IdTrainingCenter")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("PersonalTrainer");

                    b.Navigation("TrainingCenter");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.TrainingCenter", b =>
                {
                    b.HasOne("SmartGym.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.PersonalTrainer", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.TrainingCenter", b =>
                {
                    b.Navigation("PersonalTrainers");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
