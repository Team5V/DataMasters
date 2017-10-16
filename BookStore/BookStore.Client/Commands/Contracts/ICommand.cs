using System.Collections.Generic;

namespace BookStore.Commands
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}