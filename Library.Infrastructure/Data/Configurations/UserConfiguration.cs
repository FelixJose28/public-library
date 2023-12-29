using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User", "user");

            entity.HasKey(e => e.UserId);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasIndex(e => e.Email, "UQ__User__A9D105345FB9982E")
                .IsUnique();


            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.FirstSurname)
                .HasMaxLength(50);

            entity.Property(e => e.HouseNumber)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.ModificationDate)
                .HasColumnType("datetime");

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.MunicipalDistrict)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Municipality)
                .HasMaxLength(100);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Province)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.RegisteredBy)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.RegistrationDate)
                .HasColumnType("datetime");

            entity.Property(e => e.RegistrationStatus)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.SecondName)
                .HasMaxLength(50);

            entity.Property(e => e.SecondSurname)
                .HasMaxLength(50);

            entity.Property(e => e.Street)
                .HasMaxLength(100);

            entity.Property(e => e.UserCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasIndex(e => e.UserCode, "UC_UserCode")
                .IsUnique();

            entity.HasOne(d => d.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_RoleId_Role_RoleId");
        }
    }
}
