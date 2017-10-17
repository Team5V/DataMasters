using BookStore.Client.Commands;
using System.Collections.Generic;

namespace BookStore.Client.Core
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
