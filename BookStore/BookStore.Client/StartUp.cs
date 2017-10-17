using BookStore.Client.Container;
using BookStore.Client.Core;
using Ninject;

namespace BookStore.Client
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreSystemContext, Configuration>());

            IKernel kernel = new StandardKernel(new BookStoreModule());
            kernel.Get<IEngine>().Start();

        }
    }
}