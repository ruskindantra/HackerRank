using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Implementation
{
    internal class SockMerchant : ISolveable
    {
        private readonly IOutputWriter _outputWriter;
        private readonly IInputReader _inputReader;
        
        public SockMerchant(IOutputWriter outputWriter, IInputReader inputReader)
        {
            _outputWriter = outputWriter;
            _inputReader = inputReader;
        }

        public void Solve()
        {
            string line1 = _inputReader.ReadLine();
            string line2 = _inputReader.ReadLine();

            var sockColours = line2.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            
            var items = new Dictionary<int, int>();
            int pairs = 0;
            for (int i = 0; i < sockColours.Count(); i++)
            {
                var sockColour = sockColours.ElementAt(i);
                if (items.ContainsKey(sockColour))
                {
                    items.Remove(sockColour);
                    pairs++;
                }
                else
                {
                    items.Add(sockColour, sockColour);                    
                }
            }
            _outputWriter.WriteLine(pairs.ToString());
        }
    }
}