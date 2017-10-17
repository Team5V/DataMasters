namespace BookStore.Client.Core
{
    public interface ICommandProcessor
    {
        string ProcessCommand(string fullCommand);
    }
}
