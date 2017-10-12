using Ninject;
using BookStore.Core.Contracts;
using BookStore.DependencyInjection;
using BookStore.Data;

namespace BookStore.Client
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var dataContext = new BookStoreSystemContext();
            dataContext.Database.CreateIfNotExists();

            var kernel = new StandardKernel(new BookStoreModule());
            kernel.Get<IEngine>().Start();
        }
    }
}