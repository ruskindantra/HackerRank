using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Implementation
{
    internal class ClimbingTheLeaderboard : ISolveable
    {
        private readonly IOutputWriter _outputWriter;
        private readonly IInputReader _inputReader;

        public ClimbingTheLeaderboard(IOutputWriter outputWriter, IInputReader inputReader)
        {
            _outputWriter = outputWriter;
            _inputReader = inputReader;
        }

        public void Solve()
        {
            var line1 = _inputReader.ReadLine();
            var line2 = _inputReader.ReadLine();
            var line3 = _inputReader.ReadLine();
            var line4 = _inputReader.ReadLine();
            
            var scores = line2.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var alicesScores = line4.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            var ranks = Solve(scores.ToArray(), alicesScores.ToArray());
            foreach (var rank in ranks)
            {
                _outputWriter.WriteLine(rank.ToString());
            }
        }

        private int[] Solve(int[] scores, int[] alice)
        {
            var ranks = new int[alice.Length];
            int[] array = scores.Distinct().ToArray();
            int rankIndex = 0;
            int i = array.Length - 1;
            foreach(int score in alice) 
            {
                while(i >= 0) 
                {
                    if(score >= array[i]) 
                        i--;
                    else
                    {
                        ranks[rankIndex++] = i + 2;
                        break;
                    }
                }

                if (i < 0)
                    ranks[rankIndex++] = 1;
            }

            return ranks;
        }
    }
}