using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Boyer_Moore_Algorithm
{
    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            var infoTuple = new (TimeSpan TimeSpan, string PatternLenth, string numOfIt)[2500];
            var timer = new Stopwatch();
            for (int i = 1; i <= 50; i++)
            {
                var txt = File.ReadAllLines(i + "test.txt");
                for (int j = 0; j < 50; j++)
                {
                    var k = rand.Next(10, 40);
                    string pat = txt[j].Substring(k, rand.Next(1, 50 - k));
                    Console.Write("Pattern = " + pat);

                    var value1 = txt[j].ToCharArray();
                    var value2 = pat.ToCharArray();

                    timer.Reset();
                    timer.Start();
                    Search(value1, value2, out var num);
                    timer.Stop();
                    Console.Write(timer.Elapsed + "\r\n");

                    infoTuple[j + (i - 1) * 50] = (timer.Elapsed, pat.Length.ToString(), num.ToString());
                }
            }
            File.Delete("result.txt");
            File.AppendAllLines("result.txt", infoTuple.Select(x => $"{x.TimeSpan.TotalMilliseconds}\t{x.PatternLenth}\t{x.numOfIt}"));

            Console.WriteLine("Э" + infoTuple.Select(x => x.ToString()));
            Console.ReadKey();
        }

        static int NO_OF_CHARS = 256;

        static int Max(int a, int b) { return (a > b) ? a : b; }

        static void BadCharHeuristic(char[] str, int size, int[] badchar)
        {
            int i;
 
            for (i = 0; i < NO_OF_CHARS; i++)
                badchar[i] = -1;

            for (i = 0; i < size; i++)
                badchar[str[i]] = i;
        }

        static void Search(char[] txt, char[] pat, out int numOfIt)
        {
            numOfIt = 0;
            int m = pat.Length;
            int n = txt.Length;

            int[] badchar = new int[NO_OF_CHARS];

            BadCharHeuristic(pat, m, badchar);

            int s = 0;

            while (s <= (n - m))
            {
                int j = m - 1;

                while (j >= 0 && pat[j] == txt[s + j])
                {
                    j--;
                    numOfIt++;
                }

                if (j < 0)
                {
                    //Console.Write("\tPatterns occur at shift = " + s + "\t");

                    s += (s + m < n) ? m - badchar[txt[s + m]] : 1;
                    numOfIt++;

                }
                else
                {
                    s += Max(1, j - badchar[txt[s + j]]);
                    numOfIt++;
                }
                numOfIt++;
            }
        }
    }
}
