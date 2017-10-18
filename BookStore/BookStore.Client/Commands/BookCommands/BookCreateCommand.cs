using BookStore.Database;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Client.Commands
{
    public class BookCreateCommand : BaseCommand, ICommand
    {
        public BookCreateCommand(IBookStoreContext context) : base(context) { }

        // Syntax
        // bookcreate:title;language;pages;Author1,Author2,Author3;GenreType
        // test bookcreate:Nai-qkata Kniga;BG;80;Author1,Author2,Author3;Comedy
        public override string Execute(IList<string> parameters)
        {
            var title = parameters[0];
            var language = parameters[1];
            var pages = int.Parse(parameters[2]);
            var authorNames = parameters[3].Split(',');
            var genre = (GenreType)Enum.Parse(typeof(GenreType), parameters[4]);

            var book = new Book();//this.factory.CreateBook(title, language, pages, genre); //NoAuthors add yet

            var result = "";
            //Book title Check
            if (Context.Books.FirstOrDefault(x => x.Title == title) == null)
            {
                //Author Check to add or set ids to tables
                foreach (var authorName in authorNames)
                {
                    var holder = Context.Authors.FirstOrDefault(x => x.FullName == authorName);
                    if (holder == null)
                    {
                        book.Authors.Add(new Author { FullName = authorName });
                    }
                    else
                    {
                        book.Authors.Add(holder);
                    }
                }

                this.Context.Books.Add(book);
                this.Context.SaveChanges();
                result = $"Successfully added {title}.";
            }
            else
            {
                result = $"{title} already exists.";
            }
            return result;
        }
    }
}
