using BookStore.Commands;
using BookStore.Database;
using System;
using System.Collections.Generic;

namespace BookStore.Client.Commands.OfferCommands
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
