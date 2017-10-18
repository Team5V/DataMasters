
using BookStore.Client.Utils;
using BookStore.Data;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Client.Commands
{
    public class BookReadCommand : BaseCommand, ICommand
    {
        public BookReadCommand(IBookStoreContext context)
            : base(context)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, ErrorMessage.Params).IsNullOrEmpty().Throw();

            var bookTitle = parameters[0];

            string result = string.Empty;
            
            var readBook = Context.Books.FirstOrDefault(t => t.Title == bookTitle);
            result = $"Title: {readBook.Title}, \n"
                        + $"Pages: {readBook.Pages}, \n"
                        + $"Language: {readBook.Language}, \n"
                        + $"Genre: {readBook.Genre}, \n"
                        + $"Authors: {string.Join(", ", readBook.Authors)}";
           
            
            return result;
        }
    }
}
