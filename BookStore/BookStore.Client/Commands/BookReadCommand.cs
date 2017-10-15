using BookStore.Client.Commands;
using BookStore.Core.Contracts;
using BookStore.Database;
using System.Collections.Generic;

namespace BookStore.Commands
{
    public class BookReadCommand : BaseCommand
    {
        public BookReadCommand(IBookStoreContext context, IBookStoreFactory factory) : base(context, factory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
