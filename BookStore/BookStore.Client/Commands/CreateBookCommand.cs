using BookStore.Commands.Contracts;
using BookStore.Core.Contracts;
using System.Collections.Generic;

namespace BookStore.Commands
{
    public class CreateBookCommand : ICommand
    {
        public CreateBookCommand(IBookStoreFactory factory)
        {

        }

        public string Execute(IList<string> parameters)
        {
            return null;
        }
    }
}
