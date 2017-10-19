using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public Book()
        {
            this.Authors = new HashSet<Author>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50, MinimumLength = 2,
            ErrorMessage = "The Title's length cannot be less than 2 or more than 50 symbols long.")]
        public string Title { get; set; }

        [Required, StringLength(2, MinimumLength = 2,
            ErrorMessage = "The Language's length is exact 2 symbols.")]
        public string Language { get; set; }

        [Required, Range(minimum: 1, maximum: 2000)]
        public int Pages { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        [Required, EnumDataType(typeof(GenreType))]
        public GenreType Genre { get; set; }

        public virtual Offer BookOffer { get; set; }
    }
}