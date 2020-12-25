using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGym.Domain.Entities;

namespace SmartGym.Infra.Data.Mapping
{
    public class TrainingCenterMap : IEntityTypeConfiguration<TrainingCenter>
    {
        public void Configure(EntityTypeBuilder<TrainingCenter> builder)
        {
            builder.ToTable("TrainingCenter");

            builder.HasKey(prop => prop.Id);


            builder
                .HasMany(prop => prop.Students)
                .WithOne(prop => prop.TrainingCenter)
                .HasForeignKey(prop => prop.IdTrainingCenter)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasMany(prop => prop.Students)
                .WithOne(prop => prop.TrainingCenter)
                .HasForeignKey(prop => prop.IdTrainingCenter)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(prop => prop.PersonalTrainers)
                .WithOne(prop => prop.TrainingCenter)
                .HasForeignKey(prop => prop.IdTrainingCenter)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
