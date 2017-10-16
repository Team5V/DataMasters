using BookStore.Core.Contracts;
using BookStore.Models;
using BookStore.Models.Enums;

namespace BookStore.Core.Factories
{
    public class BookStoreFactory : IBookStoreFactory
    {
        public Book CreateBook(string title, string language, int pages, GenreType genreType)
        {
            // Ask if this will happen automagically when the book is created with new parameters 

            //if (title == null || title.Length < 2 || title.Length > 50)
            //{
            //    throw new ArgumentOutOfRangeException("Invalid title");
            //}
            //if (language == null || language.Length != 2)
            //{
            //    throw new ArgumentOutOfRangeException("Invalid language");
            //}
            //if (pages == 0 || pages < 1 || pages > 2000)
            //{
            //    throw new ArgumentOutOfRangeException("Invalid pages");
            //}
            
            return new Book{ Title = title, Language = language, Pages = pages, Genre = genreType };
        }
    }
}