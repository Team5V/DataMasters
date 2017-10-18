using BookStore.Database;
using BookStore.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Client.Commands
{
    public class BookUpdateCommand : BaseCommand, ICommand
    {
        public BookUpdateCommand(IBookStoreContext context)
            : base(context)
        {
        }
        //syntax bookupdate:id;property;newValue;
        //Title Language Pages Genre Authors
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "Need an Id").IsNullOrEmpty().Throw();
            var id = int.Parse(parameters[0]);
            var prop = parameters[1];
            var newValue = parameters[2];

            var book = this.Context.Books.Find(id);
            if (book == null)
            {
                return "No book with that Id.";
            }

            switch (prop)
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
                    foreach (var author in authors)
                    {
                        var holder = Context.Authors.FirstOrDefault(x => x.FullName == author);
                        if (holder.FullName == string.Empty)
                        {
                            book.Authors.Add(new Author { FullName = author });
                        }
                        else
                        {
                            book.Authors.Add(holder);
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid property.");
            }

            this.Context.SaveChanges();

            return $"Changed {book.Title}'s {prop} to {newValue}";
        }
    }
}
