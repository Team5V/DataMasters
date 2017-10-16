using BookStore.Client.Commands;
using BookStore.Database;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Commands
{
    public class BookReadCommand : BaseCommand
    {
        public BookReadCommand(IBookStoreContext context)
            : base(context)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "parameters").IsNullOrEmpty().Throw();
            var bookTitle = parameters[0];

            var book = Context.Books.FirstOrDefault(t => t.Title == bookTitle);

            return string.Join(", ", book);
        }
    }
}
