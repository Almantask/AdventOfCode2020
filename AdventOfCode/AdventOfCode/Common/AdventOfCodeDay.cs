using System;
using System.IO;

namespace AdventOfCode.Common
{
    // Other days don't use this, because I figured it out in Day8.
    public abstract class AdventOfCodeDay<TPart1, TPart2>
        where TPart1 : class, ISolution, new()
        where TPart2 : class, ISolution, new()
    {
        protected abstract int Day { get; }

        public void Solve()
        {
            var input = File.ReadAllText($"D{Day}/Input.txt");

            var part1 = new TPart1();
            var part2 = new TPart2();

            Console.WriteLine($"D{Day}P1 answer: " + part1.Solve(input));
            Console.WriteLine($"D{Day}P2 answer: " + part2.Solve(input));
        }
    }
}
