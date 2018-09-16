using System;

namespace cs.Common
{
    public class ConsoleReader
    {
        /// <summary>
        /// Reads a given number of rows from the console
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public string[] Read(int rows)
        {
            var input = new string[rows];

            for (int i = 0; i < rows; i++)
            {
                input[i] = Console.ReadLine();
            }
            return input;
        }
    }
}