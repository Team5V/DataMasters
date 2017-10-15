using BookStore.Commands;

namespace BookStore.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand ResolveCommand(string commandName);
    }
}
