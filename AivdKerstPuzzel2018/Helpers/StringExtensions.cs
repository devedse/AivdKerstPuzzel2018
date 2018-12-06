using System;
using System.Linq;

namespace AivdKerstPuzzel2018.Helpers
{
    public static class StringExtensions
    {
        public static string ReverseString(this string str)
        {
            return new string(str.Reverse().ToArray());
        }
    }
}
