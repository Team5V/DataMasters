using BookStore.Core.Contracts;
using BookStore.Database;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class OfferUpdateCommand : BaseCommand
    {
        public OfferUpdateCommand(IBookStoreContext context, IBookStoreFactory factory) : base(context)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
