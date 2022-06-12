using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> entity)
        {
            entity.ToTable("Author");

            entity.HasKey(e => e.AuthorId)
                .HasName("");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.FirstSurname).HasMaxLength(50);

            entity.Property(e => e.ModificationDate).HasColumnType("datetime");

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.RegisteredBy)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

            entity.Property(e => e.RegistrationStatus)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.SecondName).HasMaxLength(50);

            entity.Property(e => e.SecondSurname).HasMaxLength(50);
        }
    }
}
