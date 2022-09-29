using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Data.Configurations
{
    public class TelephoneConfiguration : IEntityTypeConfiguration<Telephone>
    {
        public void Configure(EntityTypeBuilder<Telephone> entity)
        {
            entity.ToTable("Telephone", "user");

            entity.HasKey(e =>e.TelephoneId);

            entity.HasIndex(e => e.PhoneNumber)
                .IsUnique();

            entity.Property(e => e.ModificationDate).HasColumnType("datetime");

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .IsRequired()
                .IsUnicode(false);

            entity.Property(e => e.RegisteredBy)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

            entity.Property(e => e.RegistrationStatus)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Telephones)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Telephone_UserId_User_UserId");
        }
    }
}
