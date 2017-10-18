using BookStore.Core.Contracts;
using Bytes2you.Validation;

namespace BookStore.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ICommandParser parser;

        public CommandProcessor(ICommandParser parser)
        {
            Guard.WhenArgument(parser, "parser").IsNull().Throw();
            this.parser = parser;
        }

        public string ProcessCommand(string commandAsString)
        {
            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);
            var result = command.Execute(parameters);
            return result;
        }
    }
}