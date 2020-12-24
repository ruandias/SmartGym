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

            builder
                .HasMany(prop => prop.Students)
                .WithOne(prop => prop.PersonalTrainer)
                .HasForeignKey(prop => prop.IdPersonalTrainer)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
