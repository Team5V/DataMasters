using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new SortedSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(200)]
        public string Bio { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}