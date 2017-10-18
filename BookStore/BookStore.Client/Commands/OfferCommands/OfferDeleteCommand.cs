﻿using BookStore.Client.Utils;
using BookStore.Database;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class OfferDeleteCommand : BaseCommand, ICommand
    {
        public OfferDeleteCommand(IBookStoreContext context) : base(context) { }

        //syntax offerdelete:id
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Err.Params).IsNullOrEmpty().Throw();

            int.TryParse(parameters[0], out int id);

            //var offer = this.GetOffer(id);

            //this.Context.Offers.Remove(offer);
            this.Context.SaveChanges();

            return "offer deleted";
        }
    }
}
