using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TreasuryChallenge.Domain
{
    public static class Archive
    {
        public static void Write(IEnumerable<string> codes)
        {
            File.WriteAllText("aleatory-file.txt", String.Join("\n", codes));
            System.Console.WriteLine($"A file with {codes.Count()} lines was generated.");
        }
    }
}
