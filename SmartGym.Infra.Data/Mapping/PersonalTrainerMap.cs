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
                .HasMany(prop => prop.Students)
                .WithOne(prop => prop.PersonalTrainer)
                .HasForeignKey(prop => prop.PersonalTrainerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
