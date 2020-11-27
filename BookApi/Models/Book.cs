using System.ComponentModel.DataAnnotations;

namespace BookApi.Models
{
    public enum Type
    {
        Hardcover,
        Paperback,
        eBook
    }
    public class Book
    {
        [Required]
        public int Id { get; init; }
        [Required]
        public string Title { get; init; }

        [Required]
        public string Author { get; init; }

        public string Summary { get; init; }

        [Required]
        public Type Type { get; init; }
    }
}
