﻿using BookStore.Client.Utils;
using BookStore.Data;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Client.Commands
{
    public class SaleCreateCommand : BaseCommand, ICommand
    {
        public SaleCreateCommand(IBookStoreContext context) 
            : base(context)
        {
        }
        //syntax salecreate:offerId,offerId..ets;
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, ErrorMessage.Params).IsNullOrEmpty().Throw();
            Guard.WhenArgument(parameters.Count, ErrorMessage.Less).IsNotEqual(1).Throw();

            var offerIds = parameters[0].Split(',').Select(x => int.Parse(x));
<<<<<<< HEAD
           



=======
            var validOffers = this.Context.Offers.Where(x => x.Book_Id.Equals(offerIds.Any()));
            var validOffers2 = this.Context.Offers.Where(x => offerIds.Contains(x.Book_Id));
            
>>>>>>> 0ab72287fd08a4ba486fce56cc1225ea4f82b731
            //this.Context.Sales.Add(sale);
            //this.Context.SaveChanges();
            return "Sale conducted";
        }
    }
}
