using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookOffer
    {
        [Key]
        public int Book_Id { get; set; }

        [Required]
        [Range(minimum: 1.95, maximum: 195.00, ErrorMessage = "Price range is between 1.95 & 195.00")]
        public decimal Price { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "Max stored copies are 100/book")]
        public int Copies { get; set; }
    }
}