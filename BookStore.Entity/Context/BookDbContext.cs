using BookStore.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Entity.Context
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBook>().HasKey(table => new { table.BookIdFk, table.UserIdFk });
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserPassword> UserPassword { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserLog> UserLog { get; set; }
        public DbSet<UserBook> UserBook { get; set; }
    }
}
