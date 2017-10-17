using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}