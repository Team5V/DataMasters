using BookStore.Commands;
using BookStore.Core.Contracts;
using BookStore.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var commandName = fullCommand.Split(':')[0].ToLower();
            if (!this.commandNames.Contains(commandName))
            {
                string msg = $"No idea of {commandName}. Available commands are:{string.Join(", ", commandNames)}";
                throw new ArgumentException(msg);
            }
            var command = this.factory.ResolveCommand(commandName);
            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(':')[1].Split(';').ToList();
            if (commandParts.Count == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}