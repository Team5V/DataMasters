using BookStore.Models;

namespace BookStore.Core.Contracts
{
    public interface IBookStoreFactory
    {
        Book CreateBook();
    }
}