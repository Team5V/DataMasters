using BookStore.Core.Contracts;
using BookStore.DependencyInjection;
using Ninject;

namespace BookStore.Client
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreSystemContext, Configuration>());

            var kernel = new StandardKernel(new BookStoreModule());
            kernel.Get<IEngine>().Start();
        }
    }
}