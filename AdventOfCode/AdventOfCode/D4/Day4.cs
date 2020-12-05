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

        public sealed class PassportV2 : Passport
        {
            private readonly Dictionary<string, Predicate<string>> rules = new Dictionary<string, Predicate<string>>
            {
                {Keys.BirthYear, IsOk.BirthYear},
                {Keys.IssueYear, IsOk.IssueYear},
                {Keys.ExpirationYear, IsOk.ExpirationYear},
                {Keys.Height, IsOk.Height},
                {Keys.HairColor, IsOk.HairColor},
                {Keys.EyeColor, IsOk.EyeColor},
                {Keys.PassportId, IsOk.PassportId},
                {Keys.CountryId, s => true}
            };

            public static class IsOk
            {
                public static bool BirthYear(string year) => IsNumberInRange(year, 1920, 2002);

                public static bool IssueYear(string year) => IsNumberInRange(year, 2010, 2020);

                public static bool ExpirationYear(string year) => IsNumberInRange(year, 2020, 2030);

                public static bool Height(string heightString)
                {
                    var isCm = heightString.EndsWith("cm");
                    var isIn = heightString.EndsWith("in");

                    heightString = heightString.Replace(isCm?"cm":"in", "");

                    return isCm ? IsNumberInRange(heightString, 150, 193)
                                : isIn && IsNumberInRange(heightString, 59, 76);
                }

                public static bool HairColor(string color)
                {
                    var regex = new Regex("#[0-9a-f]{6}");
                    return regex.IsMatch(color);
                }

                public static bool EyeColor(string color)
                {
                    string[] eyeColors = {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
                    return eyeColors.Contains(color);
                }

                public static bool PassportId(string id)
                {
                    return int.TryParse(id, out _) &&
                           id.Length == 9;
                }

                private static bool IsNumberInRange(string input, int min, int max)
                {
                    var isNumber = float.TryParse(input, out var number);
                    return isNumber && number >= min && number <= max;
                }
            }

            public PassportV2(IReadOnlyDictionary<string, string> info) : base(info)
            {
            }

            public override bool IsValid() => base.IsValid() && 
                                              Info.All(kvp => rules[kvp.Key](kvp.Value));

            public new static PassportV2 Parse(string passportInfo)
                => new PassportV2(Passport.Parse(passportInfo).Info);
        }

        public class Passport
        {
            public static class Keys
            {
                public static readonly int MandatoryCount;
                public static readonly string[] Optionals;

                public const string EyeColor = "ecl";
                public const string BirthYear = "byr";
                public const string HairColor = "hcl";
                public const string PassportId = "pid";
                public const string ExpirationYear = "eyr";
                public const string CountryId = "cid";
                public const string IssueYear = "iyr";
                public const string Height = "hgt";

                static Keys()
                {
                    Optionals = new []{CountryId};
                    MandatoryCount = 8 - Optionals.Length;
                }
            };

            private static char[] passportDelimeters = {' ', '\r', '\n'};

            public readonly IReadOnlyDictionary<string, string> Info;

            public Passport(IReadOnlyDictionary<string, string> info)
            {
                Info = info;
            }

            public static Passport Parse(string passportInfo)
            {
                const char infoDelimiter = ':';
                var infoParts = passportInfo.Split(passportDelimeters, StringSplitOptions.RemoveEmptyEntries);
                var infoDic = infoParts
                    .Select(p => p.Split(infoDelimiter))
                    .ToDictionary(p => p[0], p => p[1]);

                var passport = new Passport(infoDic);
                return passport;
            }

            public virtual bool IsValid() => Info
                .Where(kvp => !Keys.Optionals.Contains(kvp.Key))
                .Count() == Keys.MandatoryCount;
        }
    }
}
