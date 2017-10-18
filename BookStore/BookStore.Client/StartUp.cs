using BookStore.Client.Core;
using BookStore.Data.Migrations;
using BookStore.DependencyInjection;
using Ninject;
using BookStore.Data;
using System.Data.Entity;

namespace BookStore.Client
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreContext, Configuration>());

            IKernel kernel = new StandardKernel(new BookStoreModule());
            IEngine engine = kernel.Get<IEngine>("Engine");
            engine.Start();
        }
    }
}