﻿using BookStore.Data;
using BookStore.Models;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Client.Commands
{
    public class BookDeleteCommand : BaseCommand, ICommand
    {
        public BookDeleteCommand(IBookStoreContext context)
            : base(context)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters,
                "Invalid command parameters\n 1. Make sure you have selected a book title e.g.\n deletebook:HumptyDumpty")
                .IsNullOrEmpty().Throw();

            var bookTitle = parameters[0];

            var book = Context.Books.FirstOrDefault(b => b.Title == bookTitle);

            Context.Books.Remove(book);
            Context.SaveChanges();

            return $"Deleted {book.Title} from Library";
        }
    }
}
