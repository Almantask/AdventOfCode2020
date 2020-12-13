using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.D4
{
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
                Optionals = new[] { CountryId };
                MandatoryCount = 8 - Optionals.Length;
            }
        };

        private static char[] passportDelimeters = { ' ', '\r', '\n' };

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
