using BookStore.Client.Commands;
using BookStore.Client.Core;
using BookStore.Database;
using Ninject.Modules;

namespace BookStore.Client.Container
{
    public class BookStoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<ICommandParser>().To<CommandParser>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IBookStoreFactory>().To<BookStoreFactory>().InSingletonScope();

            //DataContext
            this.Bind<IBookStoreContext>().To<BookStoreContext>();
            //Book commands
            this.Bind<ICommand>().To<BookCreateCommand>().Named("bookcreate");
            this.Bind<ICommand>().To<BookDeleteCommand>().Named("bookdelete");
            this.Bind<ICommand>().To<BookUpdateCommand>().Named("bookupdate");
            this.Bind<ICommand>().To<BookReadCommand>().Named("bookread");
            //BookOffer commands
            this.Bind<ICommand>().To<BookOfferCreateCommand>().Named("offercreate");
            this.Bind<ICommand>().To<BookOfferDeleteCommand>().Named("offerdelete");
            this.Bind<ICommand>().To<BookOfferUpdateCommand>().Named("offerupdate");
            this.Bind<ICommand>().To<BookOfferReadCommand>().Named("offerread");
            //report commands
            this.Bind<ICommand>().To<ReportGenerateCommand>().Named("reportgenerate");
            //sale commands
            this.Bind<ICommand>().To<SaleCreateCommand>().Named("salecreate");

            //?? Icommand
            this.Bind<ICommand>().To<JsonReader>();
            this.Bind<IPdfExporter>().To<PdfExporter>();
        }
    }
}
