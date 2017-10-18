using BookStore.Client.Commands;
using BookStore.Client.Core;
using BookStore.Core;
using BookStore.Data;
using Ninject.Modules;

namespace BookStore.DependencyInjection
{
    public class BookStoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<ICommandProcessor>().To<CommandProcessor>();
            this.Bind<ICommandParser>().To<CommandParser>();

            this.Bind<IEngine>().To<Engine>().InSingletonScope().Named("Engine");

            //DataContext
            this.Bind<IBookStoreContext>().To<BookStoreContext>();
            //Book commands
            this.Bind<ICommand>().To<BookCreateCommand>().Named("bookcreate");
            this.Bind<ICommand>().To<BookDeleteCommand>().Named("bookdelete");
            this.Bind<ICommand>().To<BookUpdateCommand>().Named("bookupdate");
            this.Bind<ICommand>().To<BookReadCommand>().Named("bookread");
            //Offer commands
            this.Bind<ICommand>().To<OfferCreateCommand>().Named("offercreate");
            this.Bind<ICommand>().To<OfferDeleteCommand>().Named("offerdelete");
            this.Bind<ICommand>().To<OfferUpdateCommand>().Named("offerupdate");
            //report commands
            this.Bind<ICommand>().To<ReportGenerateCommand>().Named("reportgenerate");
            //sale commands
            this.Bind<ICommand>().To<SaleCreateCommand>().Named("saleconduct");
            this.Bind<ICommand>().To<JsonReader>().Named("jsonreader");
            this.Bind<IPdfExporter>().To<PdfExporter>();

           
        }
    }
}
