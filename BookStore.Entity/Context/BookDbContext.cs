using BookStore.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Entity.Context
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }

        #region Models Definition

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<User_Password> User_Password { get; set; }
        public DbSet<User_Profile> User_Profile { get; set; }
        public DbSet<User_Log> User_Log { get; set; }
        public DbSet<User_Book> User_Book { get; set; }


        #endregion
    }
}
