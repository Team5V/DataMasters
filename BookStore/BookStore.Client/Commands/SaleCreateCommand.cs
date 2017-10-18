using BookStore.Client.Utils;
using BookStore.Data;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Client.Commands
{
    public class SaleCreateCommand : BaseCommand, ICommand
    {
        public SaleCreateCommand(IBookStoreContext context) : base(context) { }
        //syntax salecreate:offerId,offerId..ets;
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Err.Params).IsNullOrEmpty().Throw();
            Guard.WhenArgument(parameters.Count, Err.Less).IsNotEqual(1).Throw();

            var offerIds = parameters[0].Split(',').Select(x => int.Parse(x));
           



            //this.Context.Sales.Add(sale);
            //this.Context.SaveChanges();
            return "sale conducted";
        }
    }
}
