﻿using BookStore.Client.Commands;
using Bytes2you.Validation;
using Ninject;

namespace BookStore.Client.Core
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            Guard.WhenArgument(kernel, "kernel").IsNull().Throw();

            this.kernel = kernel;
        }

        public ICommand ResolveCommand(string commandName)
        {
            return this.kernel.Get<ICommand>(commandName);
        }
    }
}
