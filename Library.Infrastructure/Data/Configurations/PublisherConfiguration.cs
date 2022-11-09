﻿using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> entity)
        {
            entity.ToTable("Publisher");

            entity.HasKey(e => e.PublisherId);

            entity.Property(e => e.Info)
                .IsRequired()
                .HasMaxLength(400);

            entity.Property(e => e.ModificationDate).HasColumnType("datetime");

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.RegisteredBy)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

            entity.Property(e => e.RegistrationStatus)
                .IsRequired()
                .HasDefaultValueSql("((1))");
        }
    }
}
