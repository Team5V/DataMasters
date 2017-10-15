using BookStore.Commands;
using Ninject;
using System;

namespace BookStore.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            this.kernel = kernel ?? throw new ArgumentNullException("kernel");
        }

        public ICommand ResolveCommand(string commandName)
        {
            return this.kernel.Get<ICommand>(commandName);
        }
    }
}
