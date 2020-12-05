using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using Xunit;
using static AdventOfCode.D4.Day4.Passport.Keys;

namespace AdventOfCode.Tests.Day4
{
    public class PassportTests
    {
        [Theory]
        [MemberData(nameof(PassportIsValidExpectations))]
        public void Passport_IsValid_Returns_True_When_AllMandatoryFieldsExist(D4.Day4.Passport passport, bool expectedIsValid)
        {
            var isValid = passport.IsValid();

            isValid.Should().Be(expectedIsValid);
        }

        [Theory]
        [MemberData(nameof(ExpectedParsedPasswords))]
        public void Passport_Parse_Returns_Expected(string passportInfo, D4.Day4.Passport expectedPassport)
        {
            var passport = D4.Day4.Passport.Parse(passportInfo);

            passport.Should().BeEquivalentTo(expectedPassport);
        }

        public static IEnumerable<object[]> ExpectedParsedPasswords
        {
            get
            {
                var mixedFullPassport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd" + Environment.NewLine +
                                        "byr:1937 iyr:2017 cid:147 hgt:183cm";
                var expectedMixedFullPassport = new D4.Day4.Passport(new Dictionary<string, string>
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
                yield return new object[] { mixedFullPassport, expectedMixedFullPassport };

                var justiyr = "iyr:2013";
                var justIyrPassport = new D4.Day4.Passport(new Dictionary<string, string>
                {
                    {IssueYear, "2013"}
                });
                yield return new object[] { justiyr, justIyrPassport };

                var justEcl = "ecl:amb";
                var justEclPassport = new D4.Day4.Passport(new Dictionary<string, string>
                {
                    { EyeColor, "amb"}
                });
                yield return new object[] { justEcl, justEclPassport };

                var justCid = "cid:350";
                var justcidPassport = new D4.Day4.Passport(new Dictionary<string, string>
                {
                    {CountryId, "350"}
                });
                yield return new object[] { justCid, justcidPassport };

                var justEyr = "eyr:2023";
                var justEyrPassport = new D4.Day4.Passport(new Dictionary<string, string>
                {
                    {ExpirationYear, "2023"}
                });
                yield return new object[] { justEyr, justEyrPassport };

                var justPid = "pid:028048884";
                var justPidPassport = new D4.Day4.Passport(new Dictionary<string, string>
                {
                    {PassportId, "028048884"}
                });
                yield return new object[] { justPid, justPidPassport };

                var justHcl = "hcl:#cfa07d";
                var justHclPassport = new D4.Day4.Passport(new Dictionary<string, string>
                {
                    {HairColor, "#cfa07d"}
                });
                yield return new object[] { justHcl, justHclPassport };

                var justByr = "byr:1929";
                var justByrPassport = new D4.Day4.Passport(new Dictionary<string, string>
                {
                    {BirthYear, "1929"}
                });
                yield return new object[] { justByr, justByrPassport };
            }
        }

        public static IEnumerable<object[]> PassportIsValidExpectations
        {
            get
            {
                yield return Expect("Part1/AllInfoPresent", true);
                yield return Expect("Part1/MissingHgt", false);
                yield return Expect("Part1/OptionalInfoMissing", true);
                yield return Expect("Part1/MissingCidAndByr", false);

                object[] Expect(string input, bool isValid) => new object[] { D4.Day4.Passport.Parse(Input(input)), isValid };
            }
        }

        private static string Input(string file)
        {
            return File.ReadAllText($"Input/Day4/{file}.txt");
        }

    }
}
