using BookStore.Client.Commands;
using BookStore.Core.Contracts;
using BookStore.Database;
using BookStore.Models;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Commands
{
    public class BookDeleteCommand : BaseCommand
    {
        private readonly IBookStoreContext context;
        private readonly IWriter writer;
        private readonly IReader reader;

        public BookDeleteCommand(IBookStoreContext context, IReader reader, IWriter writer)
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
            Guard.WhenArgument(parameters,
                "Invalid command parameters\n 1. Make sure you have selected a book title e.g.\n deletebook HumptyDumpty")
                .IsNullOrEmpty().Throw();

            string bookTitle = parameters[0];

            Book bookToDelete = context.Books.Where(b => b.Title == bookTitle).FirstOrDefault();

            using (var newContext = new BookStoreContext())
            {
                newContext.Entry(bookToDelete).State = EntityState.Deleted;

                newContext.SaveChanges();
            }
            System.Console.WriteLine("sad");
            return $"Deleted {bookToDelete.Title} from {string.Join(", ", bookToDelete.Authors)}";
        }
    }
}
