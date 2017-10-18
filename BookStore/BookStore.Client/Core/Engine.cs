using BookStore.Core.Contracts;
using Bytes2you.Validation;
using System;

namespace BookStore.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor processor;

        public Engine(IReader reader, IWriter writer, ICommandProcessor processor)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(processor, "processor").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.processor = processor;
        }


        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    if (commandAsString != string.Empty)
                    {
                        var executionResult = this.processor.ProcessCommand(commandAsString);
                        this.writer.WriteLine(executionResult);
                    }
                }
                catch (ArgumentNullException)
                {
                    this.writer.WriteLine("Command cannot be null or empty.");
                }

                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}