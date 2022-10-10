namespace BookWriters.Services
{
    public class BookServices : IBookServices
    {
        BWContext db;
        public BookServices(BWContext _db)
        {
            db = _db;
        }
        public void DeleteBook(int ID)
        {
            Book book = db.Books.FirstOrDefault(s => s.BookID == ID);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return (db.Books.Select(s => s).ToList());
        }
    }
}
