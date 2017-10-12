using BookStore.Commands.Contracts;

namespace BookStore.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
