﻿using BookStore.Core.Contracts;
using BookStore.Data;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class OfferUpdateCommand : BaseCommand
    {
        public OfferUpdateCommand(IStoreContext context, IBookStoreFactory factory) : base(context, factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
