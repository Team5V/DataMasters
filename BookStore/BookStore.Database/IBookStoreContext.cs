using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Database
{
    public interface IBookStoreContext
    {
        IDbSet<Book> Books { get; set; }

        IDbSet<Author> Authors { get; set; }

        int SaveChanges();
    }
}