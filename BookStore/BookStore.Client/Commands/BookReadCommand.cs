using BookStore.Client.Commands;
using BookStore.Core.Contracts;
using BookStore.Data;
using BookStore.Database;
<<<<<<< HEAD
using Bytes2you.Validation;
=======
>>>>>>> dea4ea1f64958e8bde6a1e730cd56a9f87c46233
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Commands
{
    public class BookReadCommand : BaseCommand
    public class ReadBookCommand : BaseCommand
    {
        private readonly IBookStoreContext context;
        private readonly IWriter writer;
        private readonly IReader reader;

        public BookReadCommand(IBookStoreContext context, IReader reader, IWriter writer)
        public ReadBookCommand(IBookStoreContext context, IReader reader, IWriter writer)
>>>>>>> dea4ea1f64958e8bde6a1e730cd56a9f87c46233
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
