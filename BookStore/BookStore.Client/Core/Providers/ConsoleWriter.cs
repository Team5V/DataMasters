using System;
using BookStore.Core.Contracts;

namespace BookStore.Core.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
