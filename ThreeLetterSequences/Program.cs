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
        static Dictionary<string, int> _dict = new Dictionary<string, int>();
        static string _input = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Reading file...");
            ReadInFile("SampleText.txt");

            Console.WriteLine("Creating dictionary...");
            CreateDictionary(3);

            int val = GetTLSCount();

            Console.WriteLine($"\nTLSs with count {val}:\n" + string.Join(", ", _dict.Where(d => d.Value == val).Select(d => d.Key).ToList()));
            Console.WriteLine("\n10 most common TLSs:\n" + string.Join("\n", _dict.OrderByDescending(d => d.Value).Take(10).Select(d => $"{d.Key} - {d.Value}").ToList()));

            Console.ReadLine();
        }

        static void ReadInFile(string filePath)
        {
            _input = File.ReadAllText(filePath);
        }

        static void CreateDictionary(int tlsLength, string str = "")
        {
            if (str.Length == tlsLength)
            {
                _dict.Add(str, new Regex(str, RegexOptions.IgnoreCase).Matches(_input).Count);
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

        static int GetTLSCount()
        {
            string value = "";
            int val = 0;

            do
            {
                Console.Write("Return TLSs with count of: ");
                value = Console.ReadLine();

            }
            while (!int.TryParse(value, out val));

            return val;
        }
    }
}
