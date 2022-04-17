#region Info

// FileName:    EntityConfig.cs
// Author:      Ladislav Filip
// Created:     17.04.2022

#endregion

using Refiz.Domain.AggregatesModel.EntityAggregate;

namespace Refiz.Infrastructure.Configurations;

public class EntityConfig : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> entity)
    {
        entity.HasKey(e => e.Id);

        entity.ToTable("entities");

        entity.HasIndex(e => e.Email, "UK_entities_email")
            .IsUnique();

        entity.Property(e => e.Id).HasColumnName("IDEntity");

        entity.Property(e => e.Cin)
            .HasMaxLength(15)
            .HasColumnName("CIN");

        entity.Property(e => e.City).HasMaxLength(50);

        entity.Property(e => e.DateActivated).HasColumnType("datetime");

        entity.Property(e => e.DateCreate).HasColumnType("datetime");

        entity.Property(e => e.DateDeleted).HasColumnType("datetime");

        entity.Property(e => e.Email).HasMaxLength(150);

        entity.Property(e => e.FirmName).HasMaxLength(150);

        entity.Property(e => e.Idcountry).HasColumnName("IDCountry");

        entity.Property(e => e.Idorganisation).HasColumnName("IDOrganisation");

        entity.Property(e => e.Idregion).HasColumnName("IDRegion");

        entity.Property(e => e.Idrole).HasColumnName("IDRole");

        entity.Property(e => e.NameEntity).HasMaxLength(50);

        entity.Property(e => e.Password).HasMaxLength(150);

        entity.Property(e => e.Phone).HasMaxLength(50);

        entity.Property(e => e.Street).HasMaxLength(50);

        entity.Property(e => e.SurnameEntity).HasMaxLength(250);

        entity.Property(e => e.Zip).HasMaxLength(10);

        entity.HasOne(d => d.Country)
            .WithMany(p => p.Entities)
            .HasForeignKey(d => d.Idcountry)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_entities_Countries");

        entity.HasOne(d => d.Organisation)
            .WithMany(p => p.Entities)
            .HasForeignKey(d => d.Idorganisation)
            .HasConstraintName("FK_entities_Organisations");

        entity.HasOne(d => d.Region)
            .WithMany(p => p.Entities)
            .HasForeignKey(d => d.Idregion)
            .HasConstraintName("FK_entities_Regions");

        entity.HasOne(d => d.Role)
            .WithMany(p => p.Entities)
            .HasForeignKey(d => d.Idrole)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_entities_roles");
    }
}