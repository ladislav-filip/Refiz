#region Info

// FileName:    CountryConfig.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refiz.Domain;

namespace Refiz.Infrastructure.Configurations;

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> entity)
    {
        entity.HasKey(e => e.IdCountry)
            .HasName("PK_countries");

        entity.HasIndex(e => e.CountryCode, "UK_countries")
            .IsUnique();

        entity.Property(e => e.IdCountry).HasColumnName("IDCountry");

        entity.Property(e => e.CountryCode).HasMaxLength(3);

        entity.Property(e => e.Idlanguage).HasColumnName("IDLanguage");

        entity.HasOne(d => d.IdlanguageNavigation)
            .WithMany(p => p.Countries)
            .HasForeignKey(d => d.Idlanguage)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_countries_language");
    }
}