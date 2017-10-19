using BookStore.Client.Utils;
using BookStore.Data;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookStore.Client.Commands
{
    public class BookCreateCommand : BaseCommand, ICommand
    {

        public BookCreateCommand(IBookStoreContext context)
            : base(context)
        {
        }

        // bookcreate:Nai-qkata;bg;60;Pesho;Comedy
        public override string Execute(IList<string> parameters)
        {
            parameters.ValidateParameters(5);

            var title = parameters[0].Trim();
            var result = ErrorMessage.Exist;
            if (Context.Books.FirstOrDefault(x => x.Title == title) == null)
            {
                try
                {
                    var book = new Book { Title = title };
                    book.Language = parameters[1];
                    book.Pages = int.Parse(parameters[2]);
                    var authorNames = parameters[3].Split(',');
                    var genre = (GenreType)Enum.Parse(typeof(GenreType), parameters[4]);

                    book.Authors = this.Context.ResolveAuthors(authorNames);
                    this.Context.Books.Add(book);
                    this.Context.SaveChanges();
                    result = $"Successfully added {book.Title}.";
                }
                catch (DbEntityValidationException ex)
                {
                    result = "Entity framework X like u" + ex;
                }
            }

            return result;
        }
    }
}