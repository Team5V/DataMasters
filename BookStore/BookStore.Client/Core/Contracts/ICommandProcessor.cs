namespace BookStore.Core.Contracts
{
    public interface ICommandProcessor
    {
        string ProcessCommand(string fullCommand);
    }
}
