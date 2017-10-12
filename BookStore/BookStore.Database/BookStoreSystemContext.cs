using System.Data.Entity;
using BookStore.Models;

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
            //PUT OUR RELATIONS HERE
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
    }
}
