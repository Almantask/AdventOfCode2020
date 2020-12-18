using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.D4;
using FluentAssertions;
using Xunit;
using static AdventOfCode.D4.Passport.Keys;

namespace AdventOfCode.Tests.D4
{
    public class V2PasswordTests
    {
        [Fact]
        public void Parse_Returns_SameAsV1()
        {
            var mixedFullPassport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd" + Environment.NewLine +
                                    "byr:1937 iyr:2017 cid:147 hgt:183cm";
            var expectedMixedFullPassport = new PassportV2(new Dictionary<string, string>
                {
                    { EyeColor, "gry" },
                    { PassportId, "860033327" },
                    { ExpirationYear, "2020" },
                    { HairColor, "#fffffd" },
                    { BirthYear, "1937" },
                    { IssueYear, "2017" },
                    { CountryId, "147" },
                    { Height, "183cm" }
                }
            );

            var actual = PassportV2.Parse(mixedFullPassport);

            actual.Should().BeEquivalentTo(expectedMixedFullPassport);
        }

        [Theory]
        [MemberData(nameof(PassportV2IsValidExpectations))]
        public void IsValid_Returns_True_When_AllMandatoryFieldsExist(Passport passport, bool expectedIsValid)
        {
            var isValid = passport.IsValid();

            isValid.Should().Be(expectedIsValid);
        }

        public static IEnumerable<object[]> PassportV2IsValidExpectations
        {
            get
            {
                yield return Expect("Part2/Invalid1", false);
                yield return Expect("Part2/Invalid2", false);
                yield return Expect("Part2/Invalid3", false);
                yield return Expect("Part2/Invalid4", false);
                yield return Expect("Part2/Valid1", true);
                yield return Expect("Part2/Valid2", true);
                yield return Expect("Part2/Valid3", true);
                yield return Expect("Part2/Valid4", true);

                object[] Expect(string input, bool isValid) => new object[] { PassportV2.Parse(Input(input)), isValid };
            }
        }

        private static string Input(string file)
        {
            return File.ReadAllText($"Input/D4/{file}.txt");
        }
    }
}
