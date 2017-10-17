using BookStore.Client.Utils;
using BookStore.Database;
using BookStore.Models;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Client.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public BaseCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, Msg.ErrContext).IsNull().Throw();
            this.context = context;
        }

        public abstract string Execute(IList<string> parameters);

        protected IBookStoreContext Context { get { return this.context; } }

        protected SortedSet<Author> ResolveAuthors(IEnumerable<string> authorNames)
        {
            Guard.WhenArgument(authorNames, Msg.ErrParams).IsNullOrEmpty().Throw();

            var result = new SortedSet<Author>();
            foreach (var authorName in authorNames)
            {
                var holder = Context.Authors.FirstOrDefault(x => x.FullName == authorName);
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

        protected Book GetBook(int id)
        {
            var book = this.Context.Books.Find(id);
            Guard.WhenArgument(book, Msg.ErrNoID).IsNull().Throw();
            return book;
        }

        protected BookOffer GetOffer(int id)
        {
            var bookOffer = this.Context.BookOffers.Find(id);
            Guard.WhenArgument(bookOffer, Msg.ErrNoID).IsNull().Throw();
            return bookOffer;
        }

    }
}