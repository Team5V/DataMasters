using Ninject;
using System;
using BookStore.Commands.Contracts;

namespace BookStore.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            this.kernel = kernel ?? throw new ArgumentNullException("kernel");
        }

        public ICommand CreateCommand(string commandName)
        {
            return this.kernel.Get<ICommand>(commandName);
        }
    }
}
