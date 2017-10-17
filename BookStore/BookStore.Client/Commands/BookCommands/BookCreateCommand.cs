using BookStore.Client.Core;
using BookStore.Client.Utils;
using BookStore.Database;
using BookStore.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class BookCreateCommand : BaseCommand, ICommand
    {
        private readonly IBookStoreFactory factory;
        public BookCreateCommand(IBookStoreContext context, IBookStoreFactory factory)
            : base(context)
        {
            Guard.WhenArgument(factory, Msg.ErrFactory).IsNull().Throw();
            this.factory = factory;
        }

        //Syntax bookcreate:title;language;pages;Author1,Author2,Author3;GenreType
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Msg.ErrParams).IsNullOrEmpty().Throw();
            Guard.WhenArgument(parameters.Count, Msg.ErrLess).IsLessThan(5).Throw();

            var title = parameters[0];

            //Tuk trqbva da se fixne che na prazna baza mi iska da gi compare
            //  if (Context.Books.FirstOrDefault(x => x.Title == title) != null)
            //  {
            //      return Msg.ErrExist;
            //  }

            var language = parameters[1];
            var pages = int.Parse(parameters[2]);
            var authorNames = parameters[3].Split(',');
            var genre = (GenreType)Enum.Parse(typeof(GenreType), parameters[4]);

            var book = this.factory.CreateBook(title, language, pages, this.ResolveAuthors(authorNames), genre);

            this.Context.Books.Add(book);
            this.Context.SaveChanges();
            return Msg.Create;
        }
    }
}
