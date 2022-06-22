using System;
using System.Reflection;
using Library.Core.Models.Entities;
using Library.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Infrastructure.Data
{
    public class DBLibraryContext : DbContext
    {
        public DBLibraryContext()
        {
        }

        public DBLibraryContext(DbContextOptions<DBLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alert> Alerts { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookStatus> BookStatuses { get; set; }
        public virtual DbSet<LiteraryGender> LiteraryGenders { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<RegisterBook> RegisterBooks { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Telephone> Telephones { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BookImg> BookImgs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            //modelBuilder.ApplyConfiguration(new AlertConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
