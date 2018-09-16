using System;
using cs.Common;
using System.Linq;

namespace cs.Algorithms
{
    public class BonAppetit
    {
        private readonly ConsoleReader _consoleReader;

        public BonAppetit(ConsoleReader consoleReader)
        {
            _consoleReader = consoleReader;
        }

        public string Solve()
        {
            string[] input = _consoleReader.Read(3);

            var lineOne = input[0];
            var lineTwo = input[1];
            var lineThree = input[2];
            
            var numberOfItems = lineOne.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
            var itemNotEaten = lineOne.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

            int actualBill = lineTwo.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToInt32(s)).SkipWhile(.Sum();
        }
    }
}