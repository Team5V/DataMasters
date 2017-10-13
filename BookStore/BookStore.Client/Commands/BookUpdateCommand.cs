using BookStore.Commands.Contracts;
using BookStore.Core.Contracts;
using System.Collections.Generic;

namespace BookStore.Commands
{
    public class UpdateBookCommand : ICommand
    {
        public UpdateBookCommand(IBookStoreFactory factory)
        {

        }

        public string Execute(IList<string> parameters)
        {
            return null;
        }
    }
}
