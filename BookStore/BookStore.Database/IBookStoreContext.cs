using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Data
{
    public interface IBookStoreContext
    {
        IDbSet<Book> Books { get; set; }

        IDbSet<Author> Authors { get; set; }

        IDbSet<Offer> Offers { get; set; }

        IDbSet<Sale> Sales { get; set; }

        int SaveChanges();
    }
}