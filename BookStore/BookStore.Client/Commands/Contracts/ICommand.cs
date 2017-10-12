using System.Collections.Generic;

namespace BookStore.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}