using System.IO;
using FluentAssertions;
using Xunit;
using static AdventOfCode.D4.Day4.PassportV2.IsOk;

namespace AdventOfCode.Tests.Day4
{
    public class PassportV2IsValidTests
    {
        [Theory]
        [InlineData("1919", false)]
        [InlineData("1920", true)]
        [InlineData("2002", true)]
        [InlineData("2003", false)]
        public void BirthYear_Returns_Is_Between_1920_2002(string year, bool expectedIsValid)
        {
            bool isvalid = BirthYear(year);

            isvalid.Should().Be(expectedIsValid);
        }

        [Theory]
        [InlineData("2009", false)]
        [InlineData("2010", true)]
        [InlineData("2020", true)]
        [InlineData("2021", false)]
        public void IssueYear_Returns_Is_Between_2010_2020(string year, bool expectedIsValid)
        {
            bool isvalid = IssueYear(year);

            isvalid.Should().Be(expectedIsValid);
        }

        [Theory]
        [InlineData("2019", false)]
        [InlineData("2020", true)]
        [InlineData("2030", true)]
        [InlineData("2031", false)]
        public void ExpirationYear_Returns_Is_Between_2020_2030(string year, bool expectedIsValid)
        {
            bool isvalid = ExpirationYear(year);

            isvalid.Should().Be(expectedIsValid);
        }

        [Theory]
        [InlineData("acm", false)]
        [InlineData("ain", false)]
        [InlineData("150cmin", false)]
        [InlineData("in", false)]
        [InlineData("cm", false)]
        [InlineData("149cm", false)]
        [InlineData("150cm", true)]
        [InlineData("193cm", true)]
        [InlineData("194cm", false)]
        [InlineData("58in", false)]
        [InlineData("59in", true)]
        [InlineData("76in", true)]
        [InlineData("77in", false)]
        [InlineData("70.6in", true)]
        public void Height_Returns_Is_NumberFollowedBy_cm_or_in(string height, bool expectedIsValid)
        {
            bool isvalid = Height(height);

            isvalid.Should().Be(expectedIsValid);
        }

        [Theory]
        [InlineData("#012345", true)]
        [InlineData("#678910", true)]
        [InlineData("#abcdef", true)]
        [InlineData("#0465fa", true)]
        [InlineData("#bcdefg", false)]
        [InlineData("#00000", false)]
        [InlineData("0000000", false)]
        public void HairColor_Returns_Is_Tag_FollowedBy_exactly6_numbers_or_a_through_f(string color, bool expectedIsValid)
        {
            bool isvalid = HairColor(color);

            isvalid.Should().Be(expectedIsValid);
        }

        [Theory]
        [InlineData("amb", true)]
        [InlineData("blu", true)]
        [InlineData("brn", true)]
        [InlineData("gry", true)]
        [InlineData("grn", true)]
        [InlineData("hzl", true)]
        [InlineData("oth", true)]
        [InlineData("abc", false)]
        [InlineData("amboth", false)]
        [InlineData("bam", false)]
        public void EyeColor_Returns_Is_Either_amb_blu_brn_gry_grn_hzl_oth(string color, bool expectedIsValid)
        {
            bool isvalid = EyeColor(color);

            isvalid.Should().Be(expectedIsValid);
        }

        [Theory]
        [InlineData("123456789", true)]
        [InlineData("012345678", true)]
        [InlineData("-12345678", false)]
        [InlineData("000000001", true)]
        [InlineData("0123456789", false)]
        [InlineData("1", false)]
        public void PassportId_Returns_Is_9DigitNumber(string passport, bool expectedIsValid)
        {
            bool isvalid = PassportId(passport);

            isvalid.Should().Be(expectedIsValid);
        }

        private static string Input(string file)
        {
            return File.ReadAllText($"Input/Day4/{file}.txt");
        }
    }
}
