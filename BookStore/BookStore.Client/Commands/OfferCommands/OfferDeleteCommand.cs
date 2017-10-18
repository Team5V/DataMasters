using BookStore.Commands;
using BookStore.Core.Contracts;
using BookStore.Database;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class OfferDeleteCommand : BaseCommand, ICommand
    {
        public OfferDeleteCommand(IBookStoreContext context, IBookStoreFactory factory) : base(context)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
