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
            
//            var scoresList = scores.ToList();
//            scoresList.AddRange(alice);
//
//            scores = scoresList.ToArray();
//            
//            var dictionaryScores = new Dictionary<int, int>();
//            foreach (var score in scores)
//            {
//                if (!dictionaryScores.ContainsKey(score))
//                {
//                    dictionaryScores.Add(score, 0);
//                }
//                dictionaryScores[score]++;
//            }
//
//            for (var i = 0; i < alice.Length; i++)
//            {
//                var alicesScore = alice[i];
//                var scoresGreaterThanAlice = dictionaryScores.Count(d => d.Key > alicesScore);
//                var scoresMatchingAlice = dictionaryScores[alicesScore];
//
//                ranks[i] = scoresGreaterThanAlice + scoresMatchingAlice;
//            }
            

//            var distinctScores = scores.Distinct();
//
//            for (var i = 0; i < alice.Length; i++)
//            {
//                var alicesScore = alice[i];
//                var scoresGreaterThanAlice = distinctScores.Where(d => d >= alicesScore);
//                
//                //check if alice's scores match and how many
//                var matchedScores = scores.Count(d => d == alicesScore);
//                if (matchedScores > 0)
//                {
//                    ranks[i] = scoresGreaterThanAlice.Count();
//                }
//                else
//                {
//                    ranks[i] = (scoresGreaterThanAlice.Count() + 1);
//                }
//            }

            int rankIndex = alice.Length - 1;
            int rank = 1;
            int startIndex = -1;

            bool scoreLeftOver = false;
            int? lastScoreChecked = null;
            for (int i = alice.Length - 1; i >= 0; i--)
            {
                scoreLeftOver = false;
                
                var aliceScore = alice[i];

                do
                {
                    startIndex++;

                    if (startIndex >= scores.Length)
                    {
                        scoreLeftOver = true;
                        break;
                    }
                    
                    var score = scores[startIndex];

                    if (score == lastScoreChecked)
                    {
                        continue;
                    }
                    else
                    {
                        lastScoreChecked = score;
                    }
                    
                    if (aliceScore < score)
                    {    
                        rank++;
                        scoreLeftOver = true;
                        continue;
                    }

                    if (aliceScore >= score)
                    {
                        ranks[rankIndex--] = rank++;
                        break;
                    }

                } while (startIndex < scores.Length - 1);
            }

            if (scoreLeftOver)
            {
                ranks[rankIndex] = rank;
            }

            return ranks;
        }
    }
}