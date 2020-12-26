using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGym.Domain.Entities;

namespace SmartGym.Infra.Data.Mapping
{
    public class PersonalTrainerMap : IEntityTypeConfiguration<PersonalTrainer>
    {
        public void Configure(EntityTypeBuilder<PersonalTrainer> builder)
        {
            builder.ToTable("PersonalTrainer");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            builder
                .HasMany(p => p.Students)
                .WithOne(s => s.PersonalTrainer)
                .HasForeignKey(s => s.PersonalTrainerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
