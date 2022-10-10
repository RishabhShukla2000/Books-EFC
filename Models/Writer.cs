using System.ComponentModel.DataAnnotations;

namespace BookWriters.Models
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string? WriterName { get; set; }
        public Book Book { get; set; }
    }
}
