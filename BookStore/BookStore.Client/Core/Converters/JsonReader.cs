using BookStore.Client.Commands;
using BookStore.Database;
using BookStore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace BookStore.Client.Core
{
    public class JsonReader : BaseCommand, ICommand
    {
        public JsonReader(IBookStoreContext context)
            : base(context)
        {
        }
        // TODO: Fix Deserializing since it needs a structure to deserialize the object
        public override string Execute(IList<string> parameters)
        {
            var path = "..\\..\\..\\BookStore.AppData\\jsonbooks.json";
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();

                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
                foreach (var book in books)
                {
                    Context.Books.Add(book);
                }
                Context.SaveChanges();
            }
            return $"Operation was successful!";
        }
        private static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
