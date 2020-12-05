using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.D4
{
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

                heightString = heightString.Replace(isCm ? "cm" : "in", "");

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
                string[] eyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                return eyeColors.Contains(color);
            }

            public static bool PassportId(string id)
            {
                return uint.TryParse(id, out _) &&
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
}
