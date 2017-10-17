using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Database
{
    public interface IBookStoreContext
    {
        IDbSet<Book> Books { get; }

        IDbSet<Author> Authors { get; }

        IDbSet<BookOffer> BookOffers { get; }

        IDbSet<Sale> Sales { get; }

        int SaveChanges();
    }
}