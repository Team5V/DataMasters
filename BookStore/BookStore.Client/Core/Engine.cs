using System;
using System.Text;
using BookStore.Core.Contracts;

namespace BookStore.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor processor;
        private readonly StringBuilder builder;

        public Engine(IReader reader, IWriter writer, ICommandProcessor processor)
        {
            this.reader = reader ?? throw new ArgumentNullException("reader");
            this.writer = writer ?? throw new ArgumentNullException("writer");
            this.processor = processor ?? throw new ArgumentNullException("processor");

            this.builder = new StringBuilder();
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
                        this.writer.WriteLine(this.builder.ToString());
                        break;
                    }

                    var executionResult = this.processor.ProcessCommand(commandAsString);
                    this.builder.AppendLine(executionResult);
                }
                catch (ArgumentNullException)
                {
                    this.builder.AppendLine("Command cannot be null or empty.");
                }

                catch (Exception ex)
                {
                    this.builder.AppendLine(ex.Message);
                }
            }
        }
    }
}