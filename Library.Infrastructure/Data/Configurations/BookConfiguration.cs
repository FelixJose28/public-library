using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> entity)
        {
            entity.ToTable("Book");

            entity.HasKey(e => e.BookId);

            entity.Property(e => e.Edition).HasMaxLength(75);

            entity.Property(e => e.ImgUrl).HasMaxLength(1000);

            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("ISBN");

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

            entity.HasOne(d => d.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_AuthorId_Author_AuthorId");

            entity.HasOne(d => d.LiteraryGender)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.LiteraryGenderId)
                .HasConstraintName("FK_Book_LiteraryGenderId_LiteraryGender_LiteraryGenderId");

            entity.HasOne(d => d.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("FK_Book_PublisherId_Publisher_PublisherId");
        }
    }
}
