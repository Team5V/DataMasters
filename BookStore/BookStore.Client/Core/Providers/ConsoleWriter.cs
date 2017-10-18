using BookStore.Core.Contracts;
using System;

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