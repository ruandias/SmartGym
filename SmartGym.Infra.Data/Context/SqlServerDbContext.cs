using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using SmartGym.Domain.Entities;
using SmartGym.Infra.Data.Mapping;
using System.Linq;
using System.Reflection;

namespace SmartGym.Infra.Data.Context
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(new StudentMap().Configure);
            modelBuilder.Entity<PersonalTrainer>(new PersonalTrainerMap().Configure);
            modelBuilder.Entity<TrainingCenter>(new TrainingCenterMap().Configure);

            var entites = Assembly
                .Load("SmartGym.Domain")
                .GetTypes()
                .Where(w => w.Namespace == "SmartGym.Domain.Entities" && w.BaseType.BaseType == typeof(Notifiable));

            foreach (var item in entites)
            {
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Invalid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Valid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Notifications));
            }

        }
    }
}


