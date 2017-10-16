using BookStore.Client.Commands;
using BookStore.Commands;
using BookStore.Core;
using BookStore.Core.Contracts;
using BookStore.Core.Factories;
using BookStore.Core.Providers;
using BookStore.Database;
using Ninject.Modules;
using System.Collections.Generic;

namespace BookStore.DependencyInjection
{
    public class BookStoreModule : NinjectModule
    {
        private readonly IEnumerable<string> commandNames = new string[] {
                "bookcreate",
                "bookread",
                "bookupdate",
                "bookdelete",
                "offercreate",
                "offerdelete",
                "offerupdate",
                "reportgenerate",
                "saleconduct",
            };

        public override void Load()
        {
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<ICommandParser>().To<CommandParser>().InSingletonScope().WithConstructorArgument(commandNames);

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IBookStoreFactory>().To<BookStoreFactory>().InSingletonScope();

            //DataContext
            this.Bind<IBookStoreContext>().To<BookStoreContext>();
            //Book commands
            this.Bind<ICommand>().To<BookCreateCommand>().Named("bookcreate");
            this.Bind<ICommand>().To<BookDeleteCommand>().Named("bookdelete");
            this.Bind<ICommand>().To<DeleteBookCommand>().Named("bookdelete");
>>>>>>> dea4ea1f64958e8bde6a1e730cd56a9f87c46233
            this.Bind<ICommand>().To<BookUpdateCommand>().Named("bookupdate");
            this.Bind<ICommand>().To<BookReadCommand>().Named("bookread");
            //Offer commands
            this.Bind<ICommand>().To<OfferCreateCommand>().Named("offercreate");
            this.Bind<ICommand>().To<OfferDeleteCommand>().Named("offerdelete");
            this.Bind<ICommand>().To<OfferUpdateCommand>().Named("offerupdate");
            //report commands
            this.Bind<ICommand>().To<ReportGenerateCommand>().Named("reportgenerate");
            //sale commands
            this.Bind<ICommand>().To<SaleConductCommand>().Named("saleconduct");
        }
    }
}
