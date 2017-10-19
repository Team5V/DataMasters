using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(20, MinimumLength = 5,
            ErrorMessage = "Author.FullName's length cannot be less than 5 or more than 20 symbols long.")]
        public string FullName { get; set; }

        [StringLength(200,
            ErrorMessage = "Author.Bio's length cannot be more than 200 symbols long.")]
        public string Bio { get; set; }

        public virtual ICollection<Book> Books { get; set; }



    }
}