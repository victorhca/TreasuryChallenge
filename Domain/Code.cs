using System;
using System.Collections.Generic;
using System.Text;

namespace TreasuryChallenge.Domain
{
    public static class Code
    {
        public static IEnumerable<string> GetRandomStrings(
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
