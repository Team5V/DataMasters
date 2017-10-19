﻿using BookStore.Client.Utils;
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

        // bookcreate:title;bg;60;Aut,Author2,Author3;Comedy
        public override string Execute(IList<string> parameters)
        {
            parameters.ValidateParameters(5);

            var title = parameters[0].Trim();
            var result = $"{title} already exist";
            if (Context.Books.FirstOrDefault(x => x.Title == title) == null)
            {
                try
                {
                    var book = new Book { Title = parameters[0].Trim() };
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
                    result = "Invalid parameter:" + ex.EntityValidationErrors.First().Entry.Entity.ToString().Split('.').Last();
                }
            }

            return result;
        }
    }
}