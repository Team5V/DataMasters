using BookStore.Client.Utils;
using BookStore.Database;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class BookReadCommand : BaseCommand, ICommand
    {
        public BookReadCommand(IBookStoreContext context) : base(context) { }

        //syntax bookread:id;
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Msg.ErrParams).IsNullOrEmpty().Throw();

            int.TryParse(parameters[0], out int id);

            var book = this.GetBook(id);

            return $"Title: {book.Title}, \n"
                   + $"Pages: {book.Pages}, \n"
                   + $"Language: {book.Language}, \n"
                   + $"Genre: {book.Genre}, \n"
                   + $"Authors: {string.Join(", ", book.Authors)}";
        }
    }
}
