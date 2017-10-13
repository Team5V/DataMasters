using BookStore.Commands;
using BookStore.Commands.Contracts;
using BookStore.Core;
using BookStore.Core.Contracts;
using BookStore.Core.Factories;
using BookStore.Core.Providers;
using BookStore.Data;
using Ninject.Modules;
using System.Collections.Generic;

namespace BookStore.DependencyInjection
{
    public class BookStoreModule : NinjectModule
    {
        private readonly IEnumerable<string> commandNames = new string[] {
                "createbook",
                "readbook",
                "updatebook",
                "deletebook",
                "export" // TODO: Bind export 
            };

        public override void Load()
        {
            this.Bind<IStoreContext>().To<BookStoreSystemContext>(); //BAZATA
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<ICommandParser>().To<CommandParser>().InSingletonScope().WithConstructorArgument(commandNames);

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IBookStoreFactory>().To<BookStoreFactory>().InSingletonScope();

            this.Bind<ICommand>().To<CreateBookCommand>().InSingletonScope().Named("createbook");
            //Bind<ICommand>().To<DeleteBookCommand>().InSingletonScope().Named("readbook");
            this.Bind<ICommand>().To<UpdateBookCommand>().InSingletonScope().Named("updatebook");
            this.Bind<ICommand>().To<ReadBookCommand>().InSingletonScope().Named("deletebook");
        }
    }
}
