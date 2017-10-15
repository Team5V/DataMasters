using BookStore.Core.Contracts;
using BookStore.Database;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class OfferDeleteCommand : BaseCommand
    {
        public OfferDeleteCommand(IBookStoreContext context, IBookStoreFactory factory) : base(context, factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
