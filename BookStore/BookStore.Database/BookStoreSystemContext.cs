using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Data
{
    public class BookStoreSystemContext : DbContext
    {
        public BookStoreSystemContext()
            : base("name=BookStoreSystem")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasMany(x => x.Authors).WithMany(x => x.Books);

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }

        //Binded in container
    }
}
