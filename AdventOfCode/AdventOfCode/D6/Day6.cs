using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.D6
{
    public static class Day6
    {
        public static void Solve()
        {
            var customsDeclarationFormsYesses = File.ReadAllText("D6/Input.txt");

            Console.WriteLine("D6P1 answer: " + Part1.Solve(customsDeclarationFormsYesses));
            Console.WriteLine("D6P2 answer: " + Part2.Solve(customsDeclarationFormsYesses));
        }

        public static class Part2
        {
            /// <summary>
            /// Sum all the yesses where all people answered correct (in the group)
            /// </summary>
            public static int Solve(string customsDeclarationFormsYesses)
            {
                return customsDeclarationFormsYesses
                    .SplitByBlankLine()
                    .Select(cdf => GetSharedYesses(cdf))
                    .Sum();
            }

            public static int GetSharedYesses(string group)
            {
                return group
                    .Split(Environment.NewLine)
                    .Select(w => w.ToImmutableHashSet())
                    .Intersect()
                    .Count;
            }
        }

        public static class Part1
        {
            /// <summary>
            /// Sum all the yesses where either person answered correct (in the group)
            /// </summary>
            public static int Solve(string customsDeclarationFormsYesses)
            {
                return customsDeclarationFormsYesses
                    .SplitByBlankLine()
                    .Select(cdf => cdf.GetUniqueLetters().Count)
                    .Sum();
            }
        }

        /// <summary>
        /// Gets unique letters ignoring end of line symbols.
        /// </summary>
        public static ImmutableHashSet<char> GetUniqueLetters(this string words)
            => words
                .ToImmutableHashSet()
                .Except(new []{'\r', '\n'});

        private static ImmutableHashSet<char> Intersect(this IEnumerable<ImmutableHashSet<char>> sets)
        {
            var intersection = sets.First();
            foreach (var set in sets)
            {
                intersection = intersection.Intersect(set);
            }

            return intersection;
        }
    }
}
