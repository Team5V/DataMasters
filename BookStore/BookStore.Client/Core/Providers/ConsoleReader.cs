using BookStore.Core.Contracts;
using System;

namespace BookStore.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}