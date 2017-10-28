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
        static void Main(string[] args)
        {
            string input = File.ReadAllText("SampleText.txt");
            Regex regex = new Regex("tra");
            Console.WriteLine(regex.Matches(input).Count);
            Console.ReadLine();
        }
    }
}
