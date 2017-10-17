using BookStore.Client.Commands;

namespace BookStore.Client.Core
{
    public interface ICommandFactory
    {
        ICommand ResolveCommand(string commandName);
    }
}
