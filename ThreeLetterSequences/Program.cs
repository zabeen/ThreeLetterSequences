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
            CreateDictionary();

            string input = File.ReadAllText("SampleText.txt");
            List<string> keys = dict.Keys.ToList();

            foreach (string key in keys)
            {
                Regex regex = new Regex(key, RegexOptions.IgnoreCase);
                dict[key] = regex.Matches(input).Count;
                Console.Write("...");
            }

            Console.WriteLine(string.Join(", ", dict.Where(d => d.Value == 63).Select(d => d.Key).ToList()));

            Console.ReadLine();
        }


        static void CreateDictionary()
        {
            for (char c1 = 'a'; c1 <= 'z'; c1++)
            {
                for (char c2 = 'a'; c2 <= 'z'; c2++)
                {
                    for (char c3 = 'a'; c3 <= 'z'; c3++)
                    {
                        string tls = c1.ToString() + c2.ToString() + c3.ToString();
                        dict.Add(tls, 0);
                    }
                }          
            }

        }
    }
}
