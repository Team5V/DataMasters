using BookStore.Client.Utils;
using BookStore.Data;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace BookStore.Client.Commands
{
    public class OfferUpdateCommand : BaseCommand, ICommand
    {
        public OfferUpdateCommand(IBookStoreContext context)
            : base(context)
        {
        }

        //offerupdate:1;price;30
        //offerupdate:1;copies;40
        public override string Execute(IList<string> parameters)
        {
            parameters.ValidateParameters(3);

            var offer = this.Context.Offers.Find(parameters[0]);
            var result = ErrorMessage.NoID;
            if (offer != null)
            {
                try
                {
                    var prop = parameters[1].ToLower();
                    switch (prop)
                    {
                        case "price":
                            offer.Price = decimal.Parse(parameters[2]);
                            break;
                        case "copies":
                            offer.Copies = int.Parse(parameters[2]);
                            break;
                        default:
                            return ErrorMessage.Prop;
                    }
                    this.Context.SaveChanges();
                    result = $"Offer`s {prop} was updated to {parameters[2]}";
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