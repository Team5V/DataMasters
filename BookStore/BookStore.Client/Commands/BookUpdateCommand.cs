using BookStore.Client.Commands;
using BookStore.Core.Contracts;
using BookStore.Data;
using BookStore.Models.Enums;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Commands
{
    public class UpdateBookCommand : BaseCommand
    {
        private readonly IStoreContext context;
        private readonly IBookStoreFactory factory;
        private readonly IWriter writer;
        private readonly IReader reader;

        public UpdateBookCommand(IStoreContext context, IBookStoreFactory factory, IWriter writer, IReader reader)
            : base(context, factory)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.context = context;
            this.factory = factory;
            this.writer = writer;
            this.reader = reader;
        }

        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters,
                "Invalid command parameters\n 1. Make sure you have selected a book title e.g.\n updatebook Warcrimes")
                .IsNullOrEmpty().Throw();
            var bookTitle = parameters[0];

            this.writer.WriteLine(
                "Choose a property to edit:\n Author\n Title\n Language\n Pages\n Genre");
            var propertyToEdit = this.reader.ReadLine().ToLower();

            this.writer.WriteLine(
                $"What will be {bookTitle}'s new {propertyToEdit}?");
            var editedBookProperty = this.reader.ReadLine().ToLower();

            //select which book to edit, based on user's input
            var editedBook = (from uneditedBook in this.context.Books
                              where uneditedBook.Title == bookTitle
                              select uneditedBook).First();

            //need advice on refactoring this
            //how to select different properties to edit without using switch case?
            switch (propertyToEdit)
            {
                case "author":
                    //I am working on this
                    throw new NotImplementedException("Coming soon");
                case "title":
                    editedBook.Title = editedBookProperty;
                    break;
                case "language":
                    //follow convention e.g. RU, EN, BG;
                    //console will print the genre in lowercase but DB will store it in upper case
                    editedBook.Language = editedBookProperty.ToUpper();
                    break;
                case "pages":
                    editedBook.Pages = int.Parse(editedBookProperty);
                    break;
                case "genre":
                    //TODO refactor this using SOLID but have no idea how
                    //also, enums can go to hell
                    var newGenre = new GenreType();
                    //editedBookProperty is the user input, which is parsed to enum
                    Enum.TryParse(editedBookProperty, true, out newGenre);
                    editedBook.Genre = newGenre;
                    break;
                default:
                    throw new ArgumentException("Invalid property.");
            }

            //TODO add validation on return so that you don't access DB when the command fails.
            //Question: how to check if the Database has been accessed?


            //BookStoreContext throws a stack overflow exception it overrides the SaveChanges() method.
            //traveller project uses the above approach
            this.context.SaveChanges();

            return $"Changed {bookTitle}'s {propertyToEdit} to {editedBookProperty}";
        }
    }
}
