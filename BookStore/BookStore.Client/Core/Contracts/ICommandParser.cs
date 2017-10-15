using System.Collections.Generic;
using BookStore.Commands;

namespace BookStore.Core.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
