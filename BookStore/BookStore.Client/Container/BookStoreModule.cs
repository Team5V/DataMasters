using Ninject;
using Ninject.Modules;
using System.Collections.Generic;
using BookStore.Commands.Contracts;
using BookStore.Commands;
using BookStore.Core;
using BookStore.Core.Contracts;
using BookStore.Core.Factories;
using BookStore.Core.Providers;

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
            Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            Bind<ICommandParser>().To<CommandParser>().InSingletonScope().WithConstructorArgument(commandNames);

            Bind<IEngine>().To<Engine>().InSingletonScope();
            Bind<IBookStoreFactory>().To<BookStoreFactory>().InSingletonScope();

            Bind<ICommand>().To<CreateBookCommand>().InSingletonScope().Named("createbook");
            Bind<ICommand>().To<DeleteBookCommand>().InSingletonScope().Named("readbook");
            Bind<ICommand>().To<UpdateBookCommand>().InSingletonScope().Named("updatebook");
            Bind<ICommand>().To<ReadBookCommand>().InSingletonScope().Named("deletebook");
        }
    }
}
