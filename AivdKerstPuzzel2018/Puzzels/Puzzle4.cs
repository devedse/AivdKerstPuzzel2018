using AivdKerstPuzzel2018.DictStuff;
using AivdKerstPuzzel2018.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AivdKerstPuzzel2018.Puzzels
{
    public class Puzzle4
    {
        private List<string> allWords;
        private int maxLength = 0;
        private List<string> potentials = new List<string>();
        private long countertje = 0;

        private const string expectedString = "de??m???d?w??dz?e?en?t??n??een????????d?????f";

        public Puzzle4()
        {
            allWords = DictReader.ReadDict("Dutch").Where(t => t.Length > 2).ToList();
            allWords.AddRange(allWords.ToList().Select(t => t + "e"));

            Console.WriteLine("Filtering words");
            allWords = allWords.Where(t => t.All(z => CharValueHelper.CharArray.Contains(z))).ToList();
            Console.WriteLine("Done");
        }

        public void Recurse(string inputje, bool parallel = false)
        {
            if (countertje % 10 == 0)
            {
                Console.WriteLine($"{countertje}: {inputje}");
            }
            countertje++;

            if (parallel)
            {
                Parallel.For(0, allWords.Count, (i) =>
                {
                    var wordHere = allWords[i];

                    var newStr = inputje + wordHere;
                    if (Verify(newStr))
                    {
                        Recurse(newStr);
                    }
                });
            }
            else
            {
                for (int i = 0; i < allWords.Count; i++)
                {
                    var wordHere = allWords[i];

                    var newStr = inputje + wordHere;
                    if (Verify(newStr))
                    {
                        Recurse(newStr);
                    }
                }
            }
        }

        public bool Verify(string stringsAdChars)
        {
            var blahh = new List<TimeSpan>();
            //var stringsAdChars = string.Join("", input);

            var w = Stopwatch.StartNew();

            if (stringsAdChars.Length > expectedString.Length)
            {
                return false;
            }

            for (int i = 0; i < stringsAdChars.Length; i++)
            {
                var c1 = stringsAdChars[i];
                var expected = expectedString[i];

                if (c1 == expected || expected == '?')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            blahh.Add(w.Elapsed);

            int[] v = ToIntArray(stringsAdChars);

            blahh.Add(w.Elapsed);

            bool result = true;
            result = VerifyThisValues(result, v, 3, 4, 5);
            result = VerifyThisValues(result, v, 4, 6, 7);
            result = VerifyThisValues(result, v, 5, 7, 8);

            result = VerifyThisValues(result, v, 10, 11, 12);

            result = VerifyThisValues(result, v, 15, 16, 17);

            result = VerifyThisValues(result, v, 21, 22, 23);
            result = VerifyThisValues(result, v, 22, 24, 25);
            result = VerifyThisValues(result, v, 23, 25, 26);

            result = VerifyThisValues(result, v, 30, 31, 32);
            result = VerifyThisValues(result, v, 31, 33, 34);
            result = VerifyThisValues(result, v, 32, 34, 35);
            result = VerifyThisValues(result, v, 33, 36, 37);
            result = VerifyThisValues(result, v, 34, 37, 38);
            result = VerifyThisValues(result, v, 35, 38, 39);

            result = VerifyThisValues(result, v, 42, 43, 44);

            blahh.Add(w.Elapsed);

            if (result == false)
            {
                return false;
            }

            if (stringsAdChars.Length >= maxLength)
            {
                maxLength = stringsAdChars.Length;
                potentials.Add(stringsAdChars);
                Console.WriteLine($"Potential: {stringsAdChars}");
            }

            blahh.Add(w.Elapsed);

            return true;
        }

        private static int[] ToIntArray(string stringsAdChars)
        {
            var newArray = new int[stringsAdChars.Length];
            for (int i = 0; i < stringsAdChars.Length; i++)
            {
                newArray[i] = CharValueHelper.CharToInt(stringsAdChars[i]);
            }
            return newArray;
        }

        public bool VerifyThisValues(bool preValue, int[] v, int numberTot, int number1, int number2)
        {
            if (preValue == false)
            {
                return false;
            }
            if (numberTot >= v.Length || number1 >= v.Length || number2 >= v.Length)
            {
                return true;
            }

            if (v[numberTot] == v[number1] + v[number2])
            {
                return true;
            }
            return false;
        }

    }
}
