using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.D3
{
    public static class Day3
    {
        public static void Solve()
        {
            var passwordsAndPolicies = File.ReadAllText("D3/Input.txt");

            Console.WriteLine("D3P1 answer: " + Part1.Solve(passwordsAndPolicies));
            Console.WriteLine("D3P2 answer: " + Part2.Solve(passwordsAndPolicies));
        }

        public static class Part1
        {
            const int stepsDown = 1;
            const int stepsRight = 3;

            /// <summary>
            /// Map of a mountain repeats itself to the right.
            /// It's either x- a tree.
            /// Or 0- an empty space.
            /// Descending down the slope starts from top left corner.
            /// It is done moving 3 steps right and 1 step down.
            /// Return the count of trees stepped on traversing the slope in such a way.
            /// </summary>
            /// <param name="map">Map of slope</param>
            /// <returns>Count of trees in the way</returns>
            public static int Solve(string map)
            {
                // How many times to go down?
                // - count of lines.
                var lines = map.Split(Environment.NewLine);
                var stepsToMake = map.Length / stepsDown;
                var rightTotal = 0;
                var totalTrees = 0;

                for (var downTotal = stepsDown; downTotal < stepsToMake; downTotal+= stepsDown)
                {
                    // Where will we land to the right?
                    // - map[next][totalStepsToRight % max[next].length]
                    rightTotal += stepsRight;
                    var isTree = IsDescendAtTree(lines, downTotal, rightTotal);
                    totalTrees += isTree ? 1 : 0;
                }

                return totalTrees;
            }

            private static bool IsDescendAtTree(string[] lines, int downTotal, int rightTotal)
            {
                var isOutOfWoods = downTotal >= lines.Length;
                if (isOutOfWoods) return false;

                const char tree = '#';

                var nextLine = lines[downTotal];
                var next = nextLine[rightTotal % nextLine.Length];

                return next == tree;
            }
        }

        public static class Part2
        {
            /// <summary>
            /// Map of a mountain repeats itself to the right.
            /// It's either x- a tree.
            /// Or 0- an empty space.
            /// Descending down the slope starts from top left corner.
            /// It is done moving 3 steps right and 1 step down.
            /// Return the count of trees stepped on traversing the slope in such a way.
            /// </summary>
            /// <param name="map">Map of slope</param>
            /// <returns>Count of trees in the way</returns>
            public static int Solve(string map)
            {
                return 0;
            }
        }
    }
}
