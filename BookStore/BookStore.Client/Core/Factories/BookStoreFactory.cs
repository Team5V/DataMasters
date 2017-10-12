using BookStore.Core.Contracts;
using BookStore.Models;

namespace BookStore.Core.Factories
{
    public class BookStoreFactory : IBookStoreFactory
    {
        public Book CreateBook()
        {
            return new Book();
        }
    }
}