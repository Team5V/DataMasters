using BookStore.Models;
using BookStore.Models.Enums;
using System.Collections.Generic;

namespace BookStore.Core.Contracts
{
    public interface IBookStoreFactory
    {
        Book CreateBook(string title, string language, int pages, GenreType genreType);
    }
}