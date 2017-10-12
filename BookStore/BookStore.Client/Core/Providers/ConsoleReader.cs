using System;
using BookStore.Core.Contracts;

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
