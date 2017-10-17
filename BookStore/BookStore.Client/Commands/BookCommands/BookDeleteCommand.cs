﻿using BookStore.Client.Utils;
using BookStore.Database;
using BookStore.Models;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class BookDeleteCommand : BaseCommand, ICommand
    {
        public BookDeleteCommand(IBookStoreContext context) : base(context) { }

        //bookdelete:id;
        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, Msg.ErrParams).IsNullOrEmpty().Throw();

            int.TryParse(parameters[0], out int id);

            Book book = this.GetBook(id);

            Context.Books.Remove(book);
            Context.SaveChanges();
            return Msg.Delete;
        }
    }
}
