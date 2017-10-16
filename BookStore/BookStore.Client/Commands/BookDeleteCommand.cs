using BookStore.Client.Commands;
using BookStore.Database;
using BookStore.Models;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Commands
{
    public class BookDeleteCommand : BaseCommand
    {
        public BookDeleteCommand(IBookStoreContext context)
            : base(context)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters,
                "Invalid command parameters\n 1. Make sure you have selected a book title e.g.\n deletebook HumptyDumpty")
                .IsNullOrEmpty().Throw();

            var bookTitle = parameters[0];

            Book book = Context.Books.FirstOrDefault(b => b.Title == bookTitle);
            //check for existence
            Context.Books.Remove(book);

            return $"Deleted {book.Title} from {string.Join(", ", book.Authors)}";
        }
    }
}
