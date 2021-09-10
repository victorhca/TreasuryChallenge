using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace TreasuryChallenge
{
    class Program
    {
        private const int QTY_CHARACTERS_CODE = 7;
        private const string ALLOWED_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static void Main(string[] args)
        {
            int inputInt = 0;
            string inputStr;
            do
            {
                Console.WriteLine("Tell me the number of lines do you need and press enter.");
                inputStr = Console.ReadLine();
                Console.Clear();

            } while (!Int32.TryParse(inputStr, out inputInt) || inputInt <= 0);

            var t = Stopwatch.StartNew();

            Write(inputInt);

            t.Stop();
            System.Console.WriteLine(t.ElapsedMilliseconds);
        }

        static void Write(int lines)
        {
            var strings = GetRandomStrings(ALLOWED_CHARS, QTY_CHARACTERS_CODE, lines);
            File.WriteAllText("aleatory-file.txt", String.Join("\n", strings));
            System.Console.WriteLine($"A file with {strings.Count()} lines was generated.");
        }

        private static IEnumerable<string> GetRandomStrings(
            string allowedChars,
            int length,
            int lines)
        {
            var rng = new Random();
            char[] chars = new char[length + 1];
            int setLength = allowedChars.Length;
            char letter;
            while (lines-- > 0)
            {
                for (int i = 0; i < length; ++i)
                {
                    do
                    {
                        letter = allowedChars[rng.Next(setLength)];
                    } while (i == 0 ? chars[i] == letter : chars[i - 1] == letter);

                    chars[i] = letter;
                }
                yield return new string(chars, 0, length);
            }
        }
    }
}