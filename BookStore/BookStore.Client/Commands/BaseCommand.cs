using BookStore.Commands;
using BookStore.Core.Contracts;
using BookStore.Database;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private IBookStoreContext context;
        private readonly IBookStoreFactory factory;

        public BaseCommand(IBookStoreContext context, IBookStoreFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }

        public abstract string Execute(IList<string> parameters);

        protected IBookStoreFactory Factory { get { return this.factory; } }

        protected IBookStoreContext Context
        {
            get { return this.context; }

            [Ninject.Inject]
            private set { }
        }
    }
}