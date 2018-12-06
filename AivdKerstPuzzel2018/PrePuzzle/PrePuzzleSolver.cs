using AivdKerstPuzzel2018.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AivdKerstPuzzel2018.PrePuzzle
{
    public class PrePuzzleSolver
    {
        private List<int> sumList;
        private List<int> productList;

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
        }
    }
}
