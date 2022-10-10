global using BookWriters.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWriters.Context
{
    public class BWContext : DbContext
    {
        public BWContext(DbContextOptions options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
