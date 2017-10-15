using BookStore.Core.Contracts;
using BookStore.Models;
using BookStore.Models.Enums;
using System;
using System.Collections.Generic;

namespace BookStore.Core.Factories
{
    public class BookStoreFactory : IBookStoreFactory
    {
        public Book CreateBook(string title, string language, int pages, IList<Author> authors, GenreType genreType)
        {
            if (title == null || title.Length < 2 || title.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Invalid title");
            }
            if (language == null || language.Length != 2)
            {
                throw new ArgumentOutOfRangeException("Invalid language");
            }
            if (pages == 0 || pages < 1 || pages > 2000)
            {
                throw new ArgumentOutOfRangeException("Invalid pages");
            }
            if (authors == null || authors.Count == 0 || authors.Count > 3)
            {
                throw new ArgumentOutOfRangeException("Invalid authors");
            }
            var book = new Book { Title = title, Language = language, Pages = pages, Genre = genreType };
            foreach (var item in authors)
            {
                book.Authors.Add(item);
            }
            return book;
        }
    }
}