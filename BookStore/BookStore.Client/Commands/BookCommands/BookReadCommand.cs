using BookStore.Client.Commands;
using BookStore.Database;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Commands
{
    public class BookReadCommand : BaseCommand, ICommand
    {
        public BookReadCommand(IBookStoreContext context)
            : base(context)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "parameters").IsNullOrEmpty().Throw();

            var bookTitle = parameters[0];

            string result = string.Empty;
            // See if there is better exception handling
            try
            {
                var readBook = Context.Books.FirstOrDefault(t => t.Title == bookTitle);
                result = "Book Title: " + readBook.Title + ", \n"
                        + "Pages: "+ readBook.Pages + ", \n"
                        + "Language: " + readBook.Language + ", \n"
                        + "Genre: " + readBook.Genre + ", \n"
                        + "Authors: " + string.Join(", ", readBook.Authors);
            }
            catch (Exception)
            {
                throw new ContextMarshalException();
            }
            
            return result;
        }
    }
}
