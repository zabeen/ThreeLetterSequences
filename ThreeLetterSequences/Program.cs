using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ThreeLetterSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("SampleText.txt");
            int counter = 0;

            for (int i = 0; i <  input.Length; i++)
            {
                if (input[i] == 't' && input[i + 1] == 'r' && input[i + 2] == 'a')
                    counter++;
            }

            Console.WriteLine(counter);
            Console.ReadLine();
        }
    }
}
