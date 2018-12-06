using AivdKerstPuzzel2018.PrePuzzle;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AivdKerstPuzzel2018
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            MainAsync(args).GetAwaiter().GetResult();

            Console.WriteLine("Application done, press enter to exit . . .");
            Console.ReadKey();
        }

        public static async Task MainAsync(string[] args)
        {
            var prepuzzle = new PrePuzzleSolver();
            prepuzzle.Go();
        }
    }
}
