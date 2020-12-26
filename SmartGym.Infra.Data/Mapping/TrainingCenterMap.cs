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

            builder.Property(prop => prop.CompanyName)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("CompanyName")
                .HasColumnType("varchar(100)");


            builder
                .HasMany(prop => prop.Students)
                .WithOne(prop => prop.TrainingCenter)
                .HasForeignKey(prop => prop.TrainingCenterId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasMany(prop => prop.Students)
                .WithOne(prop => prop.TrainingCenter)
                .HasForeignKey(prop => prop.TrainingCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(prop => prop.PersonalTrainers)
                .WithOne(prop => prop.TrainingCenter)
                .HasForeignKey(prop => prop.TrainingCenterId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
