using BookStore.Client.Utils;
using BookStore.Database;
using BookStore.Models;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class OfferUpdateCommand : BaseCommand, ICommand
    {
        public OfferUpdateCommand(IBookStoreContext context) : base(context) { }

        //offerupdate:id;prop;value
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Err.Params).IsNullOrEmpty().Throw();
            Guard.WhenArgument(parameters.Count, Err.Less).IsLessThan(3).Throw();

            int.TryParse(parameters[0], out int id);
            var offer = new Offer();//this.GetOffer(id);
            if (offer == null)
            {
                return Err.NoID;
            }

            var prop = parameters[1].ToLower();
            switch (prop)
            {
                case "price":
                    offer.Price = decimal.Parse(parameters[1]);
                    break;
                case "copies":
                    offer.Copies = int.Parse(parameters[1]);
                    break;
                default:
                    return Err.Prop;
            }

            this.Context.SaveChanges();

            return "Offer updated";
        }
    }
}
