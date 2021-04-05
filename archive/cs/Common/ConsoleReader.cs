using System;

namespace Common
{
    internal class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}