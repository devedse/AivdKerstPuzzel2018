﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AivdKerstPuzzel2018.DictStuff
{
    public static class DictReader
    {
        public static string[] ReadDict(string language)
        {
            var dutchWords = File.ReadAllLines($"Dictionaries/{language}.dic");

            var newList = new HashSet<string>();
            for (int i = 0; i < dutchWords.Length; i++)
            {
                var cur = dutchWords[i].ToLowerInvariant();

                string toAdd;
                if (cur.Contains('/'))
                {
                    toAdd = cur.Substring(0, cur.IndexOf('/'));
                }
                else
                {
                    toAdd = cur;
                }

                if (!string.IsNullOrWhiteSpace(toAdd))
                {
                    newList.Add(toAdd);
                }
            }

            return newList.ToArray();
        }
    }
}
