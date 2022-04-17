#region Info

// FileName:    CountryConfig.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

using Refiz.Domain;

namespace Refiz.Infrastructure.Configurations;

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> entity)
    {
        entity.HasKey(e => e.Id)
            .HasName("PK_countries");

        entity.HasIndex(e => e.CountryCode, "UK_countries")
            .IsUnique();

        entity.Property(e => e.Id).HasColumnName("IDCountry");

        entity.Property(e => e.CountryCode).HasMaxLength(3);

        entity.Property(e => e.IdLanguage).HasColumnName("IDLanguage");

        entity.HasOne(d => d.IdlanguageNavigation)
            .WithMany(p => p.Countries)
            .HasForeignKey(d => d.IdLanguage)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_countries_language");
    }
}