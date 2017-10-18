using BookStore.Client.Utils;
using BookStore.Data;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public BaseCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, Err.Context).IsNull().Throw();
            this.context = context;
        }

        public abstract string Execute(IList<string> parameters);

        protected IBookStoreContext Context { get { return this.context; } }
    }
}