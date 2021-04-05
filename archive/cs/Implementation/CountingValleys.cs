using Common;

namespace Implementation
{
    internal class DynamicArray : ISolveable
    {
        private readonly IOutputWriter _outputWriter;
        private readonly IInputReader _inputReader;

        public DynamicArray(IOutputWriter outputWriter, IInputReader inputReader)
        {
            _outputWriter = outputWriter;
            _inputReader = inputReader;
        }

        public void Solve()
        {
            throw new System.NotImplementedException();
        }
    }
    
    internal class CountingValleys : ISolveable
    {
        private readonly IOutputWriter _outputWriter;
        private readonly IInputReader _inputReader;

        public CountingValleys(IOutputWriter outputWriter, IInputReader inputReader)
        {
            _outputWriter = outputWriter;
            _inputReader = inputReader;
        }

        public void Solve()
        {
            var line1 = _inputReader.ReadLine();
            var line2 = _inputReader.ReadLine();

            int valleysWalked = Fix(int.Parse(line1), line2);
            
            _outputWriter.WriteLine(valleysWalked.ToString());
        }
        
        int Fix(int n, string s) 
        {
            int currLevel = 0;
            int valleysWalked = 0;
            foreach (var step in s)
            {
                int oldCurrLevel = currLevel;
                
                if (step == 'D')
                {
                    currLevel--;
                }
                else
                {
                    currLevel++;
                }

                if (oldCurrLevel < 0 && currLevel == 0)
                {
                    valleysWalked++;
                }
            }

            return valleysWalked;
        }
    }
}