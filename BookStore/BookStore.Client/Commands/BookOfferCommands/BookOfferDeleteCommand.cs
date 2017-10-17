using BookStore.Client.Utils;
using BookStore.Database;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class BookOfferDeleteCommand : BaseCommand, ICommand
    {
        public BookOfferDeleteCommand(IBookStoreContext context) : base(context) { }

        //syntax offerdelete:id
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Msg.ErrParams).IsNullOrEmpty().Throw();

            int.TryParse(parameters[0], out int id);

            var offer = this.GetOffer(id);

            Context.BookOffers.Remove(offer);
            Context.SaveChanges();

            return Msg.Delete;
        }
    }
}
