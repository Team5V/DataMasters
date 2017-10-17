using BookStore.Client.Commands;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Client.Core
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory factory;

        public CommandParser(ICommandFactory factory)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();
            this.factory = factory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(':')[0].ToLower();

            return this.factory.ResolveCommand(commandName);
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var parameters = fullCommand.Split(':')[1]
                                        .Split(new char[]{ ';' }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();
            if (parameters.Count == 0)
            {
                return new List<string>();
            }

            return parameters;
        }
    }
}