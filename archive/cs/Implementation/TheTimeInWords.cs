using System;
using Common;

namespace Implementation
{
    internal class TheTimeInWords : ISolveable
    {
        private readonly IOutputWriter _outputWriter;
        private readonly IInputReader _inputReader;
        
        public TheTimeInWords(IOutputWriter outputWriter, IInputReader inputReader)
        {
            _outputWriter = outputWriter;
            _inputReader = inputReader;
        }

        public void Solve()
        {
            var line1 = _inputReader.ReadLine();
            var line2 = _inputReader.ReadLine();

            int hour = int.Parse(line1);
            int minutes = int.Parse(line2);

            var inWords = Solve(hour, minutes);
            _outputWriter.WriteLine(inWords);
        }

        private string Solve(int h, int m)
        {
            if (m == 0)
            {
                return NumberToWords(h) + " o' clock";
            }

            if (m == 30)
                return "half past " + NumberToWords(h);

            var tweakedMinutes = m;
            if (m > 30)
            {
                tweakedMinutes = 60 - m;
                if (h == 12)
                {
                    h = 0;
                }
            }

            string minuteWord = NumberToWords(tweakedMinutes) + " minute" + (tweakedMinutes != 1 ? "s " : " ");
            if (m == 15 || m == 45)
            {
                minuteWord = $"quarter ";
            }
            
            return minuteWord +
                   (m <= 30 ? "past " : "to ") + 
                   (m <= 30 ? NumberToWords(h) : NumberToWords(h + 1));
        }

        
        private string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}