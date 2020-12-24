using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGym.Domain.Entities;

namespace SmartGym.Infra.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Street)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Street")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Number)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Number")
                .HasColumnType("varchar(2)");

            builder.Property(prop => prop.Neighborhood)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Neighborhood")
                .HasColumnType("varchar(30)");

            builder.Property(prop => prop.City)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("varchar(30)");

            builder.Property(prop => prop.State)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("State")
                .HasColumnType("varchar(30)");

            builder.Property(prop => prop.Country)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Country")
                .HasColumnType("varchar(30)");

            builder.Property(prop => prop.ZipCode)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("ZipCode")
                .HasColumnType("varchar(30)");

        }
    }
}
