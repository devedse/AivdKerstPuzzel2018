using System.IO;

namespace AivdKerstPuzzel2018.DictStuff
{
    public static class DictReader
    {
        public static string[] ReadDict(string language)
        {
            var dutchWords = File.ReadAllLines($"Dictionaries/{language}.dic");

            var newList = new string[dutchWords.Length];
            for (int i = 0; i < dutchWords.Length; i++)
            {
                var cur = dutchWords[i];

                if (cur.Contains('/'))
                {
                    newList[i] = cur.Substring(0, cur.IndexOf('/'));
                }
                else
                {
                    newList[i] = cur;
                }
            }

            return newList;
        }
    }
}
