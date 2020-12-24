using Microsoft.EntityFrameworkCore;
using SmartGym.Domain.Entities;

namespace SmartGym.API.Persistence
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainers { get; set; }
        public DbSet<TrainingCenter> TrainingCenters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<PersonalTrainer>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<PersonalTrainer>()
                .HasMany(p => p.Students)
                .WithOne(s => s.PersonalTrainer)
                .HasForeignKey(s => s.IdPersonalTrainer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainingCenter>()
                .HasKey(t => t.Id);


            modelBuilder.Entity<TrainingCenter>()
                .HasMany(t => t.Students)
                .WithOne(s => s.TrainingCenter)
                .HasForeignKey(s => s.IdTrainingCenter)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainingCenter>()
                .HasMany(t => t.PersonalTrainers)
                .WithOne(p => p.TrainingCenter)
                .HasForeignKey(p => p.IdTrainingCenter)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}


