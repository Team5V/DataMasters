﻿using BookStore.Client.Commands;
using BookStore.Data;
using BookStore.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

namespace BookStore.Client.Core.Converters
{
    public class JsonSeedCommand : BaseCommand, ICommand
    {
        public JsonSeedCommand(IBookStoreContext context) : base(context)
        {
        }
        
        private void BookSeed(IBookStoreContext context)
        {
            if (!context.Books.Any())
            {
                using (StreamReader reader = new StreamReader(@"..\..\..\BookStore.AppData\jsonbooks.json"))
                {
                    string json = reader.ReadToEnd();
                    dynamic parsed = JObject.Parse(json);
                    foreach (var wrappedBooks in parsed)
                    {
                        foreach (var books in wrappedBooks)
                        {
                            foreach (var book in books)
                            {
                                Book bookToAdd = new Book();
                                bookToAdd.Title = book.Title;
                                bookToAdd.Language = book.Language;
                                bookToAdd.Pages = book.Pages;
                                bookToAdd.Genre = book.Genre;

                                context.Books.AddOrUpdate(bookToAdd);
                            }
                        }
                    }
                }
            }
        }
        private void AuthorSeed(IBookStoreContext context)
        {
            if (!context.Authors.Any())
            {
                using (StreamReader reader = new StreamReader(@"..\..\..\BookStore.AppData\authors.json"))
                {
                    string json = reader.ReadToEnd();
                    dynamic parsed = JObject.Parse(json);
                    foreach (var wrappedAuthors in parsed)
                    {
                        foreach (var authors in wrappedAuthors)
                        {
                            foreach (var author in authors)
                            {
                                Author authorToAdd = new Author();
                                authorToAdd.FullName = author.FullName;
                                authorToAdd.Books = new HashSet<Book>();
                                foreach (string bookTitle in author.Books)
                                {
                                    Book book = context.Books
                                        .FirstOrDefault(b => b.Title == bookTitle);

                                    authorToAdd.Books.Add(book);
                                }
                                authorToAdd.Bio = author.Bio;

                                context.Authors.AddOrUpdate(authorToAdd);
                            }
                        }
                    }
                }
            }
        }

        public override string Execute(IList<string> parameters)
        {
            this.BookSeed(this.Context);
            this.Context.SaveChanges();

            this.AuthorSeed(this.Context);
            this.Context.SaveChanges();


            return $"Seeded from json.";
        }
    }
}
