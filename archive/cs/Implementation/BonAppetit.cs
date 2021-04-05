using System;
using System.Linq;
using Common;

namespace Implementation
{
    internal class BonAppetit : ISolveable
    {
        private readonly IOutputWriter _outputWriter;
        private readonly IInputReader _inputReader;

        public BonAppetit(IOutputWriter outputWriter, IInputReader inputReader)
        {
            _outputWriter = outputWriter;
            _inputReader = inputReader;
        }
        
        public void Solve()
        {
            var line1 = _inputReader.ReadLine();
            var line2 = _inputReader.ReadLine();
            var line3 = _inputReader.ReadLine();

            var splitLine1 = line1.Split(new[] {" "}, StringSplitOptions.None).Select(int.Parse);
            var uneatenItem = splitLine1.ElementAt(1);
            var amounts = line2.Split(new[] {" "}, StringSplitOptions.None).Select(int.Parse);
            var sum = amounts.Sum();
            var amountWithUneatenItem = sum - amounts.ElementAt(uneatenItem);

            var originalPaid = Convert.ToInt32(line3);
            var shouldHavePaid = amountWithUneatenItem / 2;

            if (originalPaid - shouldHavePaid == 0)
            {
                _outputWriter.WriteLine("Bon Appetit");
            }
            else
            {
                _outputWriter.WriteLine((originalPaid - shouldHavePaid).ToString());
            }
        }
    }
}