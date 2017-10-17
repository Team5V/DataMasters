using BookStore.Client.Utils;
using BookStore.Database;
using BookStore.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class BookUpdateCommand : BaseCommand, ICommand
    {
        public BookUpdateCommand(IBookStoreContext context) : base(context) { }

        //syntax bookupdate:id;property;newValue
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Msg.ErrParams).IsNullOrEmpty().Throw();
            Guard.WhenArgument(parameters.Count, Msg.ErrLess).IsLessThan(3).Throw();

            var book = this.GetBook(int.Parse(parameters[0]));

            var property = parameters[1];
            var newValue = parameters[2];

            switch (property)
            {
                case "title":
                    book.Title = newValue;
                    break;
                case "language":
                    book.Language = newValue.ToUpper();
                    break;
                case "pages":
                    book.Pages = int.Parse(newValue);
                    break;
                case "genre":
                    book.Genre = (GenreType)Enum.Parse(typeof(GenreType), newValue);
                    break;
                case "authors":
                    var authors = newValue.Split(',');
                    book.Authors = this.ResolveAuthors(authors);
                    break;
                default:
                    return Msg.ErrProp;
            }

            this.Context.SaveChanges();
            return Msg.Change;
        }
    }
}
