using BookStore.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public Book()
        {
            this.Authors = new SortedSet<Author>();

        }

        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        //BG, EN toUpper
        [MinLength(2)]
        [MaxLength(2)]
        [Required]
        public string Language { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        public virtual ICollection<Author> Authors { get; set; }

        [Required]
        [EnumDataType(typeof(GenreType))]
        public GenreType Genre { get; set; }
    }
}