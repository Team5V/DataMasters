using System;
using BookStore.Core.Contracts;

namespace BookStore.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ICommandParser parser;

        public CommandProcessor(ICommandParser parser)
        {
            this.parser = parser ?? throw new ArgumentNullException("parser");
        }

        public string ProcessCommand(string commandAsString)
        {
            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            return executionResult;
        }
    }
}   