using BookStore.Data;
using BookStore.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Client.Utils
{
    public static class ContextExtension
    {
        public static void ValidateParameters(this ICollection<string> collection, int paramsCount = 0)
        {
            Guard.WhenArgument(collection, ErrorMessage.Params).IsNullOrEmpty().Throw();
            Guard.WhenArgument(collection.Count, "Argument count.").IsLessThan(paramsCount).Throw();

            if (collection.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentNullException("Null or Empty or WhiteSpace value");
            }
        }

        public static string Print(this Book book, string authorNames)
        {
            return $"Title: {book.Title}, \n"
                        + $"Pages: {book.Pages}, \n"
                        + $"Language: {book.Language}, \n"
                        + $"Genre: {book.Genre}, \n"
                        + $"Authors: {string.Join(", ", authorNames)}";
        }

        public static string Print(this Offer offer, string title)
        {
            return $"{title} price:{offer.Price} copies:{offer.Copies}";
        }

        public static ICollection<Author> ResolveAuthors(this IBookStoreContext context, IList<string> fullNames)
        {
            fullNames.ValidateParameters(1);

            var result = new HashSet<Author>();
            foreach (var fullName in fullNames)
            {
                var holder = context.Authors.FirstOrDefault(x => x.FullName == fullName);
                if (holder == null)
                {
                    result.Add(new Author { FullName = fullName });
                }
                else
                {
                    result.Add(holder);
                }
            }
            return result;
        }
    }
}
