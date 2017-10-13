using BookStore.Client.Commands;
using BookStore.Core.Contracts;
using BookStore.Data;
using System.Collections.Generic;

namespace BookStore.Commands
{
    public class ReadBookCommand : BaseCommand
    {
        public ReadBookCommand(IStoreContext context, IBookStoreFactory factory) : base(context, factory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
