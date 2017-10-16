using BookStore.Core.Contracts;
using BookStore.Database;
using BookStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BookStore.Client
{
    internal class JsonReader
    {
        // Is Contructor needed since this is a one time operation, or we need to get the context in the method and that's it! 
        // This is newtonsoft.Json package from NuGet
        public void LoadJson(IBookStoreContext context)
        {
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
                foreach (var book in books)
                {
                    //check book object for flaws
                    context.Books.Add(book);
                }
                context.SaveChanges();
            }

        }

    }
}
