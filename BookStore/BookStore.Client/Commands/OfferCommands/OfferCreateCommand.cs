using BookStore.Client.Utils;
using BookStore.Database;
using BookStore.Models;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class OfferCreateCommand : BaseCommand, ICommand
    {
        public OfferCreateCommand(IBookStoreContext context) : base(context) { }

        //offercreate:bookId;price;copies
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Err.Params).IsNullOrEmpty().Throw();
            Guard.WhenArgument(parameters.Count, Err.Less).IsLessThan(3).Throw();

            int.TryParse(parameters[0], out int bookId);

            // var book = this.GetBook(bookId);
            // try
            // {
            //     if (this.GetOffer(bookId) != null)
            //     {
            //         return Err.Exist;
            //     }
            // }
            // //we want to be null that proves nonExistence
            // catch (ArgumentNullException) { }

            decimal.TryParse(parameters[1], out decimal price);
            int.TryParse(parameters[0], out int copies);
            var offer = new Offer();

            // this.Context.Offers.Add(offer);
            this.Context.SaveChanges();

            return "Created offer";
        }
    }
}
