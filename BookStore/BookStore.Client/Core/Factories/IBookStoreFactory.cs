using BookStore.Models;
using BookStore.Models.Enums;

namespace BookStore.Core.Contracts
{
    public interface IBookStoreFactory
    {
        Book CreateBook(string title, string language, int pages, GenreType genreType);
    }
}