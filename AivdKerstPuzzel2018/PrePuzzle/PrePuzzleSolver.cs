﻿using AivdKerstPuzzel2018.DictStuff;
using AivdKerstPuzzel2018.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AivdKerstPuzzel2018.PrePuzzle
{
    public class PrePuzzleSolver
    {
        private readonly List<int> sumList;
        private readonly List<int> productList;

        public PrePuzzleSolver()
        {
            sumList = new List<int>()
            {
                22,
                67,
                59,
                56,
                77,
                72,
                30,
                67
            };

            productList = new List<int>()
            {
                216,
                67200,
                24840,
                21450,
                122892,
                95760,
                3150,
                61560
            };
        }

        public void Go()
        {
            var grid = new Gridje<int>(5, 8);





            var data = new List<List<string>>
            {
               new List<string>() { "aachi" },
               new List<string>() { "alntt", "bdttu" },
               new List<string>() { "aelrw", "afitw" },
               new List<string>() { "aemov", "afkmy" },
               new List<string>() { "ansuv" },
               new List<string>() { "anrst", "aopsu" },
               new List<string>() { "cceen" },
               new List<string>() { "airst" },
            };

            var combinations = data.Aggregate(1, (x, y) => x * y.Count);

            var numberListBase = new List<int>()
            {
                0, 0, 0,
                1,
                2, 2,
                1, 1,
                2, 3, 4, 5,
                5, 5,
                6, 6, 6,
                7, 7, 7, 7, 7,
                6, 6,
                5, 4,
                4, 4,
                3, 3, 3,
                2, 1, 0,
                0, 1, 2, 3, 4, 5
            };

            //var numberListBase = new List<int>()
            //{
            //    0, 0, 0,
            //    1,
            //    2, 2,
            //    1, 1,
            //    2, 3, 3, 4, 4, 5,
            //    5, 5,
            //    6, 6, 6,
            //    7, 7, 7, 7, 7,
            //    6, 6,
            //    5, 4,
            //    4,
            //    3, 3,
            //    2, 1, 0,
            //    0, 1, 2, 3, 4, 5
            //};

            //numberListBase.Reverse();

            var allWorlds = DictReader.ReadDict("Dutch").Concat(DictReader.ReadDict("Voornamen")).ToArray();
            //allWorlds = allWorlds.Select(t => t.ReverseString()).ToArray();
            //var blah = allWorlds.Where(t => t.Contains("a") && t.Contains("i") && t.Contains("r") && t.Contains("s") && t.Contains("t")).ToList();

            var corrects = new List<string>()
            {
                "acht",
                //"van",
                //"scenarist",
                //"massa",
                //"",
                //"wens",
                //"opeens",
            };

            var filtered = new HashSet<string>();

            for (int i = 0; i < combinations; i++)
            {
                Console.WriteLine($"Attempt: {i}");

                var part1 = GetLijst(data, i);
                var part2 = ToCharList(part1);
                var numberListToWorkWith = numberListBase.ToList();

                for (int zz = 0; zz < corrects.Count + 1; zz++)
                {
                    bool foundhere = false;

                    for (int y = 0; y < allWorlds.Length; y++)
                    {
                        var theDataToWorkWith = Clone(part2);
                        var curWord = allWorlds[y];



                        bool completed = true;
                        for (int z = 0; z < curWord.Length; z++)
                        {
                            var nr = numberListToWorkWith[z];
                            var curChar = curWord[z];
                            if (theDataToWorkWith[nr].Contains(curChar))
                            {
                                theDataToWorkWith[nr].Remove(curChar);


                            }
                            else
                            {
                                completed = false;
                                break;
                            }
                        }

                        if (completed)
                        {
                            if (zz >= corrects.Count)
                            {
                                Console.WriteLine($"Cycle: {zz}, Potential: {curWord}");
                                filtered.Add(curWord);
                            }

                            if (zz < corrects.Count)
                            {
                                if (curWord == corrects[zz])
                                {
                                    part2 = theDataToWorkWith;
                                    numberListToWorkWith = numberListToWorkWith.Skip(curWord.Length).ToList();
                                    foundhere = true;

                                    //if (zz == 0)
                                    //{
                                    //    AddToChars(part2, 8);
                                    //}
                                }
                            }
                        }
                    }

                    if (!foundhere)
                    {
                        break;
                    }
                    Console.WriteLine();
                }



                //LogList(part2);



                Console.WriteLine();
            }

            Console.WriteLine("Filtered:");
            foreach (var word in filtered.OrderBy(t => t.Length).ThenBy(t => t))
            {
                //word = word.ReverseString();
                Console.WriteLine(word);
            }
        }

        public void AddToChars(List<List<char>> list, int amount)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var curList = list[i];
                for (int y = 0; y < curList.Count; y++)
                {
                    var curChar = curList[y];
                    var charAsInt = CharValueHelper.CharToInt(curChar);
                    charAsInt += amount;
                    var newChar = CharValueHelper.IntToChar(charAsInt);
                    curList[y] = newChar;
                }
            }
        }

        public void LogList(List<List<char>> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                var str = new string(input[i].ToArray());
                Console.WriteLine($"{i}: {str}");
            }
        }

        public List<List<char>> Clone(List<List<char>> input)
        {
            return input.Select(t => t.ToList()).ToList();
        }

        public List<List<char>> ToCharList(List<string> input)
        {
            return input.Select(t => t.Select(z => z).ToList()).ToList();
        }

        public List<string> GetLijst(List<List<string>> input, int aaa)
        {
            var bitWise = new BitArray(new int[] { aaa });

            var theNew = new List<string>();

            int counter = 0;
            for (int i = 0; i < input.Count; i++)
            {
                var cur = input[i];
                if (cur.Count > 1)
                {
                    if (!bitWise[counter])
                    {
                        theNew.Add(cur[0]);
                    }
                    else
                    {
                        theNew.Add(cur[1]);
                    }
                    counter++;
                }
                else
                {
                    theNew.Add(cur[0]);
                }
            }

            return theNew;
        }
    }
}
