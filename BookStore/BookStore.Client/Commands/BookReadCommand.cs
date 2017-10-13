using BookStore.Commands.Contracts;
using BookStore.Core.Contracts;
using System.Collections.Generic;

namespace BookStore.Commands
{
    public class ReadBookCommand : ICommand
    {
        public ReadBookCommand(IBookStoreFactory factory)
        {

        }

        public string Execute(IList<string> parameters)
        {
            return null;
        }
    }
}
