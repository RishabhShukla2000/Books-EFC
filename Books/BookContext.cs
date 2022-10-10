global using Microsoft.EntityFrameworkCore;
namespace Books
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        public DbSet<Book> Books => Set<Book>();
    }
}
