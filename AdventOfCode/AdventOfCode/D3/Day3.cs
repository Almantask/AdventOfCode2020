using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.D3
{
    public static class Day3
    {
        public static void Solve()
        {
            var passwordsAndPolicies = File.ReadAllText("D3/Input.txt");

            Console.WriteLine("D3P1 answer: " + Part1.Solve(passwordsAndPolicies, new Step(3,1)));
            Console.WriteLine("D3P2 answer: " + Part2.Solve(passwordsAndPolicies));
        }

        public static class Part1
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
            public static int Solve(string map, Step step)
            {
                // How many times to go down?
                // - count of lines.
                var lines = map.Split(Environment.NewLine);
                var stepsToMake = map.Length / step.Down;
                var rightTotal = 0;
                var totalTrees = 0;

                for (var downTotal = step.Down; downTotal < stepsToMake; downTotal+= step.Down)
                {
                    // Where will we land to the right?
                    // - map[next][totalStepsToRight % max[next].length]
                    rightTotal += step.Right;
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
            /// It is done moving x steps right and y step down.
            /// The combos are: {1,1}, {3,1}, {5,1}, {7,1}, {1,2}.
            /// Return the count of trees stepped on traversing the slope in each a way multiplied.
            /// </summary>
            /// <param name="map">Map of slope</param>
            /// <returns>Count of trees in the way</returns>
            public static long Solve(string map)
            {
                Step[] stepCombos =
                {
                    new Step(1, 1),
                    new Step(3, 1),
                    new Step(5, 1),
                    new Step(7, 1),
                    new Step(1, 2),
                };

                return stepCombos.Product(s => Part1.Solve(map, s));
            }
        }

        public readonly struct Step
        {
            public readonly int Right;
            public readonly int Down;

            public Step(int right, int down)
            {
                Right = right;
                Down = down;
            }
        }

        public static long Product<T>(this IEnumerable<T> numbers, Func<T, int> output)
        {
            return numbers.Aggregate<T, long>(1, (res, val) => res * output(val));
        }
    }
}
