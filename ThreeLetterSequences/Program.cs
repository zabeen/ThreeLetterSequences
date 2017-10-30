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
        static Dictionary<string, int> _tlsDict = new Dictionary<string, int>();
        static string _fileContents = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Reading file...");
            ImportFileContentsAsString("SampleText.txt");

            Console.WriteLine("Creating dictionary...");
            CreateTLSDictionary(3);

            int matchCount = GetIntFromUser("Return TLSs with count of: ");
            Console.WriteLine($"\nTLSs with count {matchCount}:\n" + string.Join(", ", _tlsDict.Where(d => d.Value == matchCount).Select(d => d.Key).ToList()));

            int topTLS = GetIntFromUser("\nHow many of the most common TLSs do you wish to see? ");
            Console.WriteLine($"\nThe {topTLS} most common TLSs:\n" + string.Join("\n", _tlsDict.OrderByDescending(d => d.Value).Take(topTLS).Select(d => $"{d.Key} - {d.Value}").ToList()));

            Console.ReadLine();
        }

        static void ImportFileContentsAsString(string filePath)
        {
            // read in file and convert to lowercase
            _fileContents = File.ReadAllText(filePath).ToLower();

            // remove all non-alphabet chars from string
            Regex regex = new Regex("[^a-z]");
            _fileContents = regex.Replace(_fileContents, "");
        }

        static void CreateTLSDictionary(int tlsLength, string str = "")
        {
            // if str length has reached required TLS length, then add it to the dict, along with its match count
            if (str.Length == tlsLength)
            {
                _tlsDict.Add(str, new Regex(str, RegexOptions.IgnoreCase).Matches(_fileContents).Count);
                return;
            }
            else // iterate through a-z, and call this method recursively, passing in extended str
            { 
                for (char c = 'a'; c <= 'z'; c++)
                {
                    CreateTLSDictionary(tlsLength, str + c.ToString());
                }
            }
        }

        static int GetIntFromUser(string msg)
        {
            string value = "";
            int val = 0;

            do
            {
                Console.Write(msg);
                value = Console.ReadLine();

            }
            while (!int.TryParse(value, out val));

            return val;
        }
    }
}
