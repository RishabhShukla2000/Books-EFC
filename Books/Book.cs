namespace Books
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public List<Writer> Writers { get; set; } = new List<Writer>();
        public string Writer { get; set; } = String.Empty;
    }
}
