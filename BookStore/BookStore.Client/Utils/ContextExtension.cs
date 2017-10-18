using BookStore.Database;
using BookStore.Models;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Client.Utils
{
    public static class ContextExtension
    {
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

        public static HashSet<Author> ResolveAuthors(this IBookStoreContext context, IEnumerable<string> names)
        {
            Guard.WhenArgument(names, ErrorMessage.Params).IsNull().Throw();

            var result = new HashSet<Author>();
            foreach (var authorName in names)
            {
                var holder = context.Authors.FirstOrDefault(x => x.FullName == authorName);
                if (holder == null)
                {
                    result.Add(new Author { FullName = authorName });
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
