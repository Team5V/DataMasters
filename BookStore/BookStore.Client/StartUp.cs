using BookStore.Core.Contracts;
using BookStore.Data;
using BookStore.DependencyInjection;
using BookStore.Models;
using BookStore.Models.Enums;
using Ninject;

namespace BookStore.Client
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var dataContext = new BookStoreSystemContext();
            dataContext.Database.CreateIfNotExists();

            var author = new Author
            {
                FullName = "Pisatela"
            };

            var book = new Book
            {
                Title = "Imeto",
                Pages = 125,
                Language = "BG",
                Genre = GenreType.Essay

            };

            book.Authors.Add(author);

            dataContext.Books.Add(book);
            dataContext.SaveChanges();

            //var kernel = new StandardKernel(new BookStoreModule());
            //kernel.Get<IEngine>().Start();
        }
    }
}