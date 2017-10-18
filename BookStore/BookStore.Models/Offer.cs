using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Offer
    {
        [Key, ForeignKey("Book")]
        public int BookId { get; set; }

        [Required, Range(minimum: 1.95, maximum: 195.00,
            ErrorMessage = "Price range is between 1.95 & 195.00")]
        public decimal Price { get; set; }

        [Required, Range(minimum: 0, maximum: 100,
            ErrorMessage = "Max stored copies are 100/book")]
        public int Copies { get; set; }

        public virtual Book Book { get; set; }
    }
}