using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Data.Configurations
{
    public class RegisterBookConfiguration : IEntityTypeConfiguration<RegisterBook>
    {
        public void Configure(EntityTypeBuilder<RegisterBook> entity)
        {
            entity.ToTable("RegisterBook");

            entity.HasKey(e =>e.RegisterBookId);

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

            entity.HasOne(d => d.Book)
                .WithMany(p => p.RegisterBooks)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegisterBook_BookId_Book_BookId");

            entity.HasOne(d => d.BookStatus)
                .WithMany(p => p.RegisterBooks)
                .HasForeignKey(d => d.BookStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegisterBook_BookstatusId_Bookstatus_BookstatusId");
        }
    }
}
