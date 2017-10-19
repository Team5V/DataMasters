using BookStore.Client.Utils;
using BookStore.Data;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace BookStore.Client.Commands
{
    public class OfferDeleteCommand : BaseCommand, ICommand
    {
        public OfferDeleteCommand(IBookStoreContext context)
            : base(context)
        {
        }

        //syntax offerdelete:1
        public override string Execute(IList<string> parameters)
        {
            parameters.ValidateParameters(1);
            var result = ErrorMessage.NoID;
            var offer = this.Context.Offers.Find(int.Parse(parameters[0]));

            if (offer != null)
            {
                try
                {
                    this.Context.Offers.Remove(offer);
                    var title = offer.Book.Title;
                    this.Context.SaveChanges();
                    result = $"Successfully removed offer on <{title}>.";
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