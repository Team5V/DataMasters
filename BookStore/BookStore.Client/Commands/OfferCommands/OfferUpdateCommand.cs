using BookStore.Client.Utils;
using BookStore.Data;
using BookStore.Models;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class OfferUpdateCommand : BaseCommand, ICommand
    {
        public OfferUpdateCommand(IBookStoreContext context) 
            : base(context)
        {
        }

        //offerupdate:id;prop;value
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, ErrorMessage.Params).IsNullOrEmpty().Throw();
            Guard.WhenArgument(parameters.Count, "Parameters need to be at least three").IsLessThan(3).Throw();

            int.TryParse(parameters[0], out int id);
            var offer = new Offer();//this.GetOffer(id);
            if (offer == null)
            {
                return ErrorMessage.NoID;
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
                    return ErrorMessage.Prop;
            }

            this.Context.SaveChanges();

            return "Offer updated";
        }
    }
}