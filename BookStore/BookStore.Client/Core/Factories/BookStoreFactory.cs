using BookStore.Client.Utils;
using BookStore.Models;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Core
{
    public class BookStoreFactory : IBookStoreFactory
    {
        public Book CreateBook(string title, string language, int pages, SortedSet<Author> authors, GenreType genreType)
        {
            Guard.WhenArgument(title, Msg.ErrParams).IsNullOrEmpty().Throw();
            Guard.WhenArgument(title.Length, Msg.ErrParams).IsLessThan(2).IsGreaterThan(50).Throw();
            Guard.WhenArgument(language, Msg.ErrParams).IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(language.Length, Msg.ErrParams).IsNotEqual(2).Throw();
            Guard.WhenArgument(pages, Msg.ErrParams).IsLessThan(1).IsGreaterThan(2048).Throw();

            var book = new Book(); //Important to create the obj like that don`t use the short syntax pls
            book.Title = title;
            book.Language = language;
            book.Pages = pages;
            book.Authors = authors;
            book.Genre = genreType;

            return book;
        }

        public BookOffer CreateOffer(int book_id, decimal price, int copies)
        {
            return new BookOffer();
        }

        public Sale CreateSale()
        {
            return new Sale();
        }
    }
}