using BookStore.Client.Utils;
using BookStore.Data;
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
        //syntax offerread:1
        public override string Execute(IList<string> parameters)
        {
            parameters.ValidateParameters(1);
            var result = ErrorMessage.NoID;
            var offer = this.Context.Offers.Find(int.Parse(parameters[0]));

            if (offer != null)
            {
                try
                {
                    var title = offer.Book.Title;
                    result = offer.Print(title);
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
