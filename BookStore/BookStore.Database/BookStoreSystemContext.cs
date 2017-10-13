using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Data
{
    public class BookStoreSystemContext : DbContext, IStoreContext
    {
        public BookStoreSystemContext()
            : base("name=BookStoreSystem")
        {

        }

        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }



        public override int SaveChanges()
        {
            return this.SaveChanges();
        }
    }
}
