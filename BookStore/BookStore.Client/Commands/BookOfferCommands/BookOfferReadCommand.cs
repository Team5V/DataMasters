using BookStore.Database;
using System;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class BookOfferReadCommand : BaseCommand, ICommand
    {
        public BookOfferReadCommand(IBookStoreContext context) 
            : base(context)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
