using BookStore.Client.Utils;
using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace BookStore.Client.Commands
{
    public class OfferReadCommand : BaseCommand, ICommand
    {
        public OfferReadCommand(IBookStoreContext context)
            : base(context)
        {
        }
        //syntax offerread:id
        public override string Execute(IList<string> parameters)
        {
            parameters.ValidateParameters(1);
            var result = $"No match found.";
            var offer = this.Context.Offers.Find(int.Parse(parameters[0]));

            if (offer != null)
            {
                try
                {
                    var title = offer.Book.Title;
                    result = $"{title} price:{offer.Price} copies:{offer.Copies}";
                }
                catch (DbEntityValidationException ex)
                {
                    result = "Entity framework X like u" + ex;
                }
            }
            return result;
        }
    }
}
