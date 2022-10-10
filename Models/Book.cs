using System.ComponentModel.DataAnnotations;

namespace BookWriters.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string? BookName { get; set; }
        public List<Writer> BookWriters { get; set; } = new List<Writer>();
    }
}
