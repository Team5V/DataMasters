using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Data
{
    public interface IStoreContext
    {
        IDbSet<Book> Books { get; set; }

        IDbSet<Author> Authors { get; set; }

        int SaveChanges();
    }
}