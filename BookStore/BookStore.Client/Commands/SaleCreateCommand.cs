using BookStore.Database;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class SaleCreateCommand : BaseCommand, ICommand
    {
        public SaleCreateCommand(IBookStoreContext context) : base(context)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
