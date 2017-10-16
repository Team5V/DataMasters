using BookStore.Commands;
using BookStore.Database;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private IBookStoreContext context;

        public BaseCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public abstract string Execute(IList<string> parameters);

        public IBookStoreContext Context { get { return this.context; } }
    }
}