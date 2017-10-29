using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ThreeLetterSequences
{
    class Program
    {
        static Dictionary<string, int> dict = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            Console.Write("Value: ");
            string value = Console.ReadLine();
            int val = 0;

            if (!int.TryParse(value, out val))
            {
                Console.WriteLine("Error, must provide int.");
                Console.ReadLine();
                return;
            }

            CreateDictionary(3);

            string input = File.ReadAllText("SampleText.txt");
            List<string> keys = dict.Keys.ToList();

            foreach (string key in keys)
            {
                Regex regex = new Regex(key, RegexOptions.IgnoreCase);
                dict[key] = regex.Matches(input).Count;
                Console.Write(".");
            }

            Console.WriteLine($"\nTLSs with count {value}:\n" + string.Join(", ", dict.Where(d => d.Value == val).Select(d => d.Key).ToList()));

            Console.WriteLine("\n10 most common TLSs:\n" + string.Join("\n", dict.OrderByDescending(d => d.Value).Take(10).Select(d => $"{d.Key} - {d.Value}").ToList()));

            Console.ReadLine();
        }


        static void CreateDictionary(int tlsLength, string str = "")
        {
            if (str.Length == tlsLength)
            {
                dict.Add(str, 0);
                return;
            }
            else
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    CreateDictionary(tlsLength, str + c.ToString());
                }
            }
        }
    }
}
