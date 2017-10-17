using BookStore.Client.Utils;
using BookStore.Database;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class BookOfferUpdateCommand : BaseCommand, ICommand
    {
        public BookOfferUpdateCommand(IBookStoreContext context) : base(context) { }

        //offerupdate:id;prop;value
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Msg.ErrParams).IsNullOrEmpty().Throw();
            Guard.WhenArgument(parameters.Count, Msg.ErrLess).IsLessThan(3).Throw();

            int.TryParse(parameters[0], out int id);
            var offer = this.GetOffer(id);
            if (offer == null)
            {
                return Msg.ErrNoID;
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
                    return Msg.ErrProp;
            }

            this.Context.SaveChanges();

            return Msg.Change;
        }
    }
}
