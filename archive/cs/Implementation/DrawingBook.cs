using System;
using Common;

namespace Implementation
{
    internal class DrawingBook : ISolveable
    {
        private readonly IOutputWriter _outputWriter;
        private readonly IInputReader _inputReader;
        
        public DrawingBook(IOutputWriter outputWriter, IInputReader inputReader)
        {
            _outputWriter = outputWriter;
            _inputReader = inputReader;
        }

        public void Solve()
        {
            var line1 = _inputReader.ReadLine();
            var line2 = _inputReader.ReadLine();

            int numberOfPages = int.Parse(line1);
            int pageToGetTo = int.Parse(line2);

            var pagesTurned = Solve(numberOfPages, pageToGetTo);

            _outputWriter.WriteLine(pagesTurned.ToString());
        }

        private int Solve(int n, int p)
        {
            int currFirstPage = 1;
            int currLastPage = n % 2 == 0 ? n + 1 : n;

            int pagesTurnedFromFront = 0;
            int pagesTurnedFromBack = 0;

            do
            {
                var pageReached = currFirstPage == p || currLastPage == p ||
                                  (currFirstPage - 1) == p || (currLastPage - 1) == p;

                if (pageReached)
                    break;

                pagesTurnedFromFront++;
                pagesTurnedFromBack++;

                currFirstPage += 2;
                currLastPage -= 2;
            } while (true);

            return Math.Min(pagesTurnedFromFront, pagesTurnedFromBack);
        }
    }
}