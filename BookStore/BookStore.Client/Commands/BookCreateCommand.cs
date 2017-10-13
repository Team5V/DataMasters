using BookStore.Client.Commands;
using BookStore.Core.Contracts;
using BookStore.Data;
using System.Collections.Generic;

namespace BookStore.Commands
{
    public class CreateBookCommand : BaseCommand
    {
        public CreateBookCommand(IStoreContext context, IBookStoreFactory factory)
            : base(context, factory)
        {
        }


        public override string Execute(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
