using System.IO;

namespace AivdKerstPuzzel2018.DictStuff
{
    public static class DictReader
    {
        public static string[] ReadDict(string language)
        {
            var dutchWords = File.ReadAllLines($"Dictionaries/{language}.dic");
            return dutchWords;
        }
    }
}
