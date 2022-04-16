#region Info

// FileName:    LanguageConfig.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refiz.Domain;

namespace Refiz.Infrastructure.Configurations;

public class LanguageConfig : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> entity)
    {
        entity.HasKey(e => e.Id)
            .HasName("pk_languages");

        entity.HasIndex(e => e.Code, "uk_languages_code")
            .IsUnique();

        entity.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("IDLanguage");

        entity.Property(e => e.Code).HasMaxLength(3);
    }
}