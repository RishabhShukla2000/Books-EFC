namespace BookWriters.Services
{
    public interface IBookServices
    {
        public IEnumerable<Book> GetAllBooks();
        public void DeleteBook(int ID);
    }
}
