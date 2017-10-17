using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Client.Core
{
    public interface IBookStoreFactory
    {
        Book CreateBook(string title, string language, int pages, SortedSet<Author> authors, GenreType genreType);

        BookOffer CreateOffer(int book_id, decimal price, int copies);

        Sale CreateSale();
    }
}