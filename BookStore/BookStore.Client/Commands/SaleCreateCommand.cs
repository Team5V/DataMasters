using BookStore.Client.Core;
using BookStore.Client.Utils;
using BookStore.Database;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class SaleCreateCommand : BaseCommand, ICommand
    {
        private readonly IBookStoreFactory factory;

        public SaleCreateCommand(IBookStoreContext context, IBookStoreFactory factory) : base(context)
        {
            Guard.WhenArgument(factory, Msg.ErrFactory).IsNull().Throw();
            this.factory = factory;
        }
        //syntax salecreate:offerId,offerId..ets;
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Msg.ErrParams).IsNullOrEmpty().Throw();
            Guard.WhenArgument(parameters.Count, Msg.ErrLess).IsNotEqual(1).Throw();

            // var offerIds = parameters[0].Split(',').Select(x => int.Parse(x));
            // var validOffers = this.Context.BookOffers.Where(x => x.Book_Id.Equals(offerIds.Any()));
            // var validOffers2 = this.Context.BookOffers.Where(x => offerIds.Contains(x.Book_Id));



            //this.Context.Sales.Add(sale);
            //this.Context.SaveChanges();
            return Msg.Create;
        }
    }
}
