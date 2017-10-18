using BookStore.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

namespace BookStore.Data.Migrations
{

    public sealed class Configuration : DbMigrationsConfiguration<BookStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BookStoreContext context)
        {
            this.AuthorSeed(context);
            context.SaveChanges();
        }

        private void BookSeed(BookStoreContext context)
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
                                bookToAdd.Authors = new HashSet<Author>();
                                bookToAdd.Language = book.Language;
                                bookToAdd.Genre = book.Genre;

                                context.Books.AddOrUpdate(bookToAdd);
                            }
                        }
                    }
                }
            }
        }
        private void AuthorSeed(BookStoreContext context)
        {
            if (context.Authors.Any())
            {
                using (StreamReader reader = new StreamReader(@"\..\..\..\BookStore.AppData\authors.json"))
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
                                authorToAdd.FullName = author.Fullname;

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
    }
}
