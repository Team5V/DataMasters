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

        /// <summary>
        /// bookcreate:imeto;en;60;Joross,Krisiss;Comedy
        /// title;en;250;Author1,author2,author3;genre
        /// </summary>
        /// <param name="props"></param>
        /// <returns></returns>
        public override string Execute(IList<string> props)
        {
            var title = props[0];
            var language = props[1];
            var pages = int.Parse(props[2]);
            var authors = props[3].Split(',').Select(x => new Author { FullName = x }).ToList();
            var genre = (GenreType)Enum.Parse(typeof(GenreType), props[4]);

            var book = Factory.CreateBook(title, language, pages, authors, genre);

            var result = "";
            //Book title Check
            if (Context.Books.SingleOrDefault(x => x.Title == title) == null)
            {
                this.Context.Books.Add(book);
                this.Context.SaveChanges();
                result = $"Successfully added {title}.";
            }
            else
            {
                result = $"{title} allready exists.";
            }
            //Book authors Check
            foreach (var item in authors)
            {
                if (Context.Authors.SingleOrDefault(x => x.FullName == item.FullName) == null)
                {
                    this.Context.Authors.Add(item);
                    this.Context.SaveChanges();
                    result = $"Successfully added {title}.";
                }
                else
                {
                    result = $"{title} allready exists.";
                }
            }


            return result;
        }
    }
}
