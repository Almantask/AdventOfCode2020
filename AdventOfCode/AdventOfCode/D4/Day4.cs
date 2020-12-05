using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.D4
{
    public static class Day4
    {
        public static void Solve()
        {
            var passwordsAndPolicies = File.ReadAllText("D4/Input.txt");

            Console.WriteLine("D4P1 answer: " + Part1.Solve(passwordsAndPolicies));
            Console.WriteLine("D4P2 answer: " + Part2.Solve(passwordsAndPolicies));
        }

        public static class Part1
        {
            /// <summary>
            /// Count invalid passports within a text input.
            /// </summary>
            /// <param name="passports">Double newline separated passports.</param>
            /// <returns>Count of valid passports.</returns>
            public static int Solve(string passports)
            {
                var passportsArray = passports.Split(Environment.NewLine + Environment.NewLine);
                return passportsArray.Count(p => Passport.Parse(p).IsValid());
            }
        }

        public static class Part2
        {
            /// <summary>
            /// Count invalid passports within a text input.
            /// </summary>
            /// <param name="passports">Double newline separated passports.</param>
            /// <returns>Count of valid passports.</returns>
            public static int Solve(string passports)
            {
                var passportsArray = passports.Split(Environment.NewLine + Environment.NewLine);
                return passportsArray.Count(p => PassportV2.Parse(p).IsValid());
            }
        }
    }
}
