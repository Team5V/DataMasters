using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Database
{
    public class BookStoreContext : DbContext, IBookStoreContext
    {
        public BookStoreContext()
             : base("name=BookStoreContext")
        {
            Database.CreateIfNotExists();
        }

        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<BookOffer> BookOffers { get; set; }
        public IDbSet<Sale> Sales { get; set; }

        int IBookStoreContext.SaveChanges()
        {
            return this.SaveChanges();
        }
    }
}
