using BookStore.Data;
using System;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class OfferReadCommand : BaseCommand, ICommand
    {
        public OfferReadCommand(IBookStoreContext context) 
            : base(context)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
