using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Commands.Contracts;
using BookStore.Core.Contracts;
using BookStore.Core.Factories;

namespace BookStore.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory factory;
        private readonly SortedSet<string> commandNames;

        public CommandParser(ICommandFactory factory, IEnumerable<string> commandNames)
        {
            this.factory = factory ?? throw new ArgumentNullException("factory");
            if (commandNames == null || commandNames.Count() == 0)
            {
                throw new ArgumentNullException("command names must not be null and more than 0");
            }
            this.commandNames = new SortedSet<string>(commandNames);
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split()[0];
            if (!this.commandNames.Contains(commandName))
            {
                throw new ArgumentException("The passed command is not found!");
            }
            var command = this.factory.CreateCommand(commandName);
            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split().Skip(1).ToList();
            if (commandParts.Count == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}