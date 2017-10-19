using BookStore.Client.Utils;
using BookStore.Data;
using BookStore.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookStore.Client.Commands
{
    public class OfferCreateCommand : BaseCommand, ICommand
    {
        public OfferCreateCommand(IBookStoreContext context)
            : base(context)
        {
        }

        //offercreate:bookId;price;copies
        public override string Execute(IList<string> parameters)
        {
            parameters.ValidateParameters(3);

            var book = Context.Books.Find(int.Parse(parameters[0]));
            var result = $"Book {book.Title} already has an offer.";
            if (book == null)
            {
                result = $"No match for that Id.";
            }
            else if (book.BookOffer == null)
            {
                try
                {
                    var offer = book.BookOffer = new Offer();
                    offer.Price = decimal.Parse(parameters[1]);
                    offer.Copies = int.Parse(parameters[2]);

                    this.Context.Offers.Add(offer);
                    this.Context.SaveChanges();
                    result = $"Successfully added offer on {book.Title}.";
                }
                catch (DbEntityValidationException ex)
                {
                    result = "Entity framework X like u" + ex;
                }
            }

            return result;
        }
    }
}
