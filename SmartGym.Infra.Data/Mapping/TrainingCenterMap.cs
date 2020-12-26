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
                .HasMany(t => t.Students)
                .WithOne(s => s.TrainingCenter)
                .HasForeignKey(s => s.TrainingCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasMany(t => t.PersonalTrainers)
               .WithOne(p => p.TrainingCenter)
               .HasForeignKey(s => s.TrainingCenterId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
