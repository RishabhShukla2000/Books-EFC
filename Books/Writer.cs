namespace Books
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
