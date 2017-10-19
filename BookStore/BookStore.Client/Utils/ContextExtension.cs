using BookStore.Data;
using BookStore.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
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

        public static Book GetBook(this IBookStoreContext context, int id)
        {
            var book = context.Books.Find(id);
            Guard.WhenArgument(book, ErrorMessage.NoID).IsNull().Throw();
            return book;
        }

        public static Offer GetOffer(this IBookStoreContext context, int id)
        {
            var offer = context.Offers.Find(id);
            Guard.WhenArgument(offer, ErrorMessage.NoID).IsNull().Throw();
            return offer;
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
