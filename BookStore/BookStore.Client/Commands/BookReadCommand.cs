using BookStore.Client.Commands;
using BookStore.Core.Contracts;
using BookStore.Database;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Commands
{
    public class BookReadCommand : BaseCommand
    {
        private readonly IBookStoreContext context;
        private readonly IWriter writer;
        private readonly IReader reader;

        public BookReadCommand(IBookStoreContext context, IReader reader, IWriter writer)
            : base(context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.context = context;
            this.writer = writer;
            this.reader = reader;
        }

        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "parameters").IsNullOrEmpty().Throw();
            var bookTitle = parameters[0];

            var readBook = context.Books.Where(t => t.Title == bookTitle);

            return string.Join(", ", readBook);
        }
    }
}
