using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.D7
{
    public static class Day7
    {
        public const string ShinyGold = "shiny gold";

        public static void Solve()
        {
            var bagRules = File.ReadAllText("D7/Input.txt");

            Console.WriteLine("D7P1 answer: " + Part1.Solve(bagRules));
            Console.WriteLine("D7P2 answer: " + Part2.Solve(bagRules));
        }

        public static class Part2
        {
            /// <summary>
            /// 
            /// </summary>
            public static int Solve(string bagRules)
            {
                return 0;
            }
        }

        public static class Part1
        {
            /// <summary>
            /// How many outer bags can carry a shiny gold one?
            /// </summary>
            public static int Solve(string bagRules)
            {
                var rules = bagRules
                    .Split(Environment.NewLine)
                    .Select(br => BagRules.Parse(br));

                var bags = new Bags(rules);

                return bags.CountShinyGold();
            }
        }
    }
}
