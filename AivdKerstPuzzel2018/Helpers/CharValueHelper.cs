using System;
using System.Collections.Generic;
using System.Linq;

namespace AivdKerstPuzzel2018.Helpers
{
    public static class CharValueHelper
    {
        public static char[] CharArray = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        private static Dictionary<char, int> IntArray = CharArray.Select((t, i) => new { I = i, Char = t }).ToDictionary(t => t.Char, t => t.I + 1);

        public static char IntToChar(int i)
        {
            while (i < 0)
            {
                i += 26;
            }
            return (CharArray[i % 26]);
        }

        public static int CharToInt(char c)
        {
            if (IntArray.TryGetValue(c, out int val))
            {
                return val;
            }
            throw new InvalidOperationException($"Char {c} is not supported by the CharToInt method in the {nameof(CharValueHelper)}");
        }
    }
}
