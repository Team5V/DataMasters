using BookStore.Client.Core;
using BookStore.Client.Utils;
using BookStore.Database;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class BookOfferCreateCommand : BaseCommand, ICommand
    {
        private readonly IBookStoreFactory factory;
        public BookOfferCreateCommand(IBookStoreContext context, IBookStoreFactory factory) : base(context)
        {
            Guard.WhenArgument(factory, Msg.ErrFactory).IsNull().Throw();
            this.factory = factory;
        }

        //offercreate:bookId;price;copies
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Msg.ErrParams).IsNullOrEmpty().Throw();
            Guard.WhenArgument(parameters.Count, Msg.ErrLess).IsLessThan(3).Throw();

            int.TryParse(parameters[0], out int bookId);

            var book = this.GetBook(bookId);
            try
            {
                if (this.GetOffer(bookId) != null)
                {
                    return Msg.ErrExist;
                }
            }
            //we want to be null that proves nonExistence
            catch (System.ArgumentNullException) { }

            decimal.TryParse(parameters[1], out decimal price);
            int.TryParse(parameters[0], out int copies);
            var offer = this.factory.CreateOffer(bookId, price, copies);

            this.Context.BookOffers.Add(offer);
            this.Context.SaveChanges();

            return Msg.Create;
        }
    }
}
