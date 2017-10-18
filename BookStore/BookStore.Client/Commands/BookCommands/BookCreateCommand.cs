using BookStore.Client.Utils;
using BookStore.Data;
using BookStore.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Client.Commands
{
    public class BookCreateCommand : BaseCommand, ICommand
    {

        public BookCreateCommand(IBookStoreContext context)
            : base(context)
        {
        }

        // bookcreate:title;language;pages;Author1,Author2,Author3;GenreType
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, ErrorMessage.Params).IsNullOrEmpty().Throw();
            Guard.WhenArgument(parameters.Count, "Parameters are less than five").IsLessThan(5).Throw();

            var title = parameters[0];
            if (Context.Books.Count() > 0)
            {
                if (this.Context.Books.Where(x => x.Title == title) != null) // ne raboti dobre na kogato nqma zapisi
                {
                    return "Book already exist";
                }
            }
            try
            {
                var language = parameters[1];
                var pages = int.Parse(parameters[2]);
                var authorNames = parameters[3].Split(',');
                var genre = (GenreType)Enum.Parse(typeof(GenreType), parameters[4]);
                var book = new Book
                {
                    Title = title,
                    Language = language,
                    Pages = pages,
                    Genre = genre
                };

                //book.Authors = this.Context.ResolveAuthors(authorNames);

                this.Context.Books.Add(book);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return $"Successfully added {title}.";
        }
    }
}
