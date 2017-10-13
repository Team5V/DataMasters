using BookStore.Commands.Contracts;
using BookStore.Core.Contracts;
using BookStore.Data;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private IStoreContext context;
        private readonly IBookStoreFactory factory;

        public BaseCommand(IStoreContext context, IBookStoreFactory factory)
        {
            //TO DO VALIDATE
        }

        public abstract string Execute(IList<string> parameters);

        internal IBookStoreFactory Factory { get { return this.factory; } }

        internal IStoreContext Context { get { return this.context; } }
    }
}