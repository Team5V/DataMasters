using BookStore.Commands;
using BookStore.Core.Contracts;
using BookStore.Database;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private IBookStoreContext context;
        private readonly IBookStoreFactory factory;

        public BaseCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
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