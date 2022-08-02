using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public ICollection<Book_Category>? Book_Categories { get; set; }
    }
}