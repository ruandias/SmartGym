﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGym.Infra.Data.Context;

namespace SmartGym.Infra.Data.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    partial class SqlServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SmartGym.Domain.Entities.PersonalTrainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdTrainingCenter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTrainingCenter");

                    b.ToTable("PersonalTrainer");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdPersonalTrainer")
                        .HasColumnType("int");

                    b.Property<int>("IdTrainingCenter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPersonalTrainer");

                    b.HasIndex("IdTrainingCenter");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.TrainingCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrainingCenter");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.PersonalTrainer", b =>
                {
                    b.HasOne("SmartGym.Domain.Entities.TrainingCenter", "TrainingCenter")
                        .WithMany("PersonalTrainers")
                        .HasForeignKey("IdTrainingCenter")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TrainingCenter");
                });

            modelBuilder.Entity("SmartGym.Domain.Entities.Student", b =>
                {
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

                    b.Navigation("PersonalTrainer");

                    b.Navigation("TrainingCenter");
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
