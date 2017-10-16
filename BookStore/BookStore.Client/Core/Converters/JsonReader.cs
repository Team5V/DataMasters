using BookStore.Client.Commands;
using BookStore.Core.Contracts;
using BookStore.Database;
using BookStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BookStore.Client
{
    public class JsonReader : BaseCommand
    {
        public JsonReader(IBookStoreContext context) 
            : base(context)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            using (StreamReader r = new StreamReader("jsonbooks.json"))
            {
                string json = r.ReadToEnd();
                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
                foreach (var book in books)
                {
                    //check book object for flaws
                    Context.Books.Add(book);
                }
                Context.SaveChanges();
            }
            return $"Operation was successful!";
        }
    }
}
