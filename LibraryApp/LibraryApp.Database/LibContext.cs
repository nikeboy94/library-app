using LibraryApp.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Database
{
    public class LibContext : DbContext
    {
        public LibContext(DbContextOptions<LibContext> options): base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");
                entity.HasIndex(e => e.Title).IsUnique();
            });
        }
    }
}
