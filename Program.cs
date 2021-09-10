using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TreasuryChallenge.Domain;
using TreasuryChallenge.Utils;

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

            var codes = Code.GetRandomStrings(ALLOWED_CHARS, QTY_CHARACTERS_CODE, inputInt);
            Archive.Write(codes);

            t.Stop();
            System.Console.WriteLine(t.ElapsedMilliseconds);
        }
    }
}