using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Data.Configurations
{
    public class LiteraryGenderConfiguration : IEntityTypeConfiguration<LiteraryGender>
    {
        public void Configure(EntityTypeBuilder<LiteraryGender> entity)
        {
            entity.ToTable("LiteraryGender");

            entity.HasKey(e =>e.LiteraryGenderId);

            entity.Property(e => e.Info).HasMaxLength(400);

            entity.Property(e => e.ModificationDate).HasColumnType("datetime");

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Name).HasMaxLength(100);

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
