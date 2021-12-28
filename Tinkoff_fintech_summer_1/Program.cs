using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinkoff_fintech_summer_1
{
    internal class Program
    {

        static string shaflWords(string word)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; ++i)
            {
                if (keyValuePairs.ContainsKey(word[i])) ++keyValuePairs[word[i]];
                else keyValuePairs.Add(word[i], 1);
            }

            foreach(KeyValuePair<char, int> el in keyValuePairs)
            {
                if (el.Value != 2) return "No";
            }

            return "Yes";
        }
        static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());

            string[] words = new string[size];

            for (int i = 0; i < size; ++i)
            {
                words[i] = Console.ReadLine();
            }

            for (int i = 0; i < size; ++i)
            {
                Console.WriteLine(Program.shaflWords(words[i]));
            }

            Console.ReadKey();
        }
    }
}
