using BookStore.Client.Commands;
using BookStore.Core.Contracts;
using BookStore.Database;
using BookStore.Models;
using BookStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Commands
{
    public class BookCreateCommand : BaseCommand
    {
        //NOT COMPLEATED
        public BookCreateCommand(IBookStoreContext context, IBookStoreFactory factory)
            : base(context, factory)
        {
        }

        // Syntax
        // bookcreate:title;language;pages;Author1,Author2,Author3;GenreType
        // test bookcreate:Nai-qkata Kniga;BG;80;Author1,Author2,Author3;Comedy
        public override string Execute(IList<string> props)
        {
            var title = props[0];
            var language = props[1];
            var pages = int.Parse(props[2]);
            var authorNames = props[3].Split(',');
            var genre = (GenreType)Enum.Parse(typeof(GenreType), props[4]);

            var book = Factory.CreateBook(title, language, pages, genre); //NoAuthors add yet

            var result = "";
            //Book title Check
            if (Context.Books.FirstOrDefault(x => x.Title == title) == null)
            {
                //Author Check to add or set ids to tables
                foreach (var item in authorNames)
                {
                    var holder = Context.Authors.FirstOrDefault(x => x.FullName == item);
                    if (holder.FullName == string.Empty)
                    {
                        book.Authors.Add(new Author { FullName = item });
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
                result = $"{title} allready exists.";
            }
            return result;
        }
    }
}
