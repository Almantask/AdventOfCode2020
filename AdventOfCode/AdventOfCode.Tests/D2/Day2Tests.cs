using AdventOfCode.D2;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.D2
{
    public class Day2Tests
    {
        [Fact]
        public void Part1_Solve_Given2Of3Valid_Returns2()
        {
            const int expectedCount = 2;
            string[] passwordAndPolciies =
            {
                "1-3 b: cdefg",
                "1-3 a: abcde",
                "2-9 c: ccccccccc"
            };

            var count = Day2.Part1.Solve(passwordAndPolciies);

            count.Should().Be(expectedCount);
        }

        [Theory]
        [InlineData("1-1 a: a", true)]
        [InlineData("1-1 a: aa", false)]
        [InlineData("1-3 a: abcde", true)]
        [InlineData("1-3 b: cdefg", false)]
        [InlineData("2-9 c: ccccccccc", true)]
        public void Part1_PasswordPolicy_IsValid_Returns_True_If_PasswordMatchesPolicy(string passwordAndPolicy, bool expectedIsValid)
        {
            var isValid = Day2.Part1.PasswordPolicy.IsValid(passwordAndPolicy);

            isValid.Should().Be(expectedIsValid);
        }

        [Fact]
        public void Part1_PasswordPolicy_Parse_Returns_Expected()
        {
            const string policy = "2-9 c: ccccccccc";
            var expectedPolicy = new Day2.Part1.PasswordPolicy(2, 9, 'c');
            var expectedPassword = "ccccccccc";

            (Day2.Part1.PasswordPolicy passwordPolicy, string password) = Day2.Part1.PasswordPolicy.Parse(policy);

            passwordPolicy.Should().BeEquivalentTo(expectedPolicy);
            password.Should().Be(expectedPassword);
        }

        [Fact]
        public void Part2_Solve_Given2Of3Valid_Returns2()
        {
            const int expectedCount = 1;
            string[] passwordAndPolciies =
            {
                "1-3 b: cdefg",
                "1-3 a: abcde",
                "2-9 c: ccccccccc"
            };

            var count = Day2.Part2.Solve(passwordAndPolciies);

            count.Should().Be(expectedCount);
        }

        [Theory]
        [InlineData("1-1 a: a", false)]
        [InlineData("1-1 a: aa", false)]
        [InlineData("1-3 a: abcde", true)]
        [InlineData("1-3 b: cdefg", false)]
        [InlineData("2-9 c: ccccccccc", false)]
        public void Part2_PasswordPolicy_IsValid_Returns_True_If_PasswordMatchesPolicy(string passwordAndPolicy, bool expectedIsValid)
        {
            var isValid = Day2.Part2.PasswordPolicy.IsValid(passwordAndPolicy);

            isValid.Should().Be(expectedIsValid);
        }

        [Fact]
        public void Part2_PasswordPolicy_Parse_Returns_Expected()
        {
            const string policy = "2-9 c: ccccccccc";
            var expectedPolicy = new Day2.Part2.PasswordPolicy(2, 9, 'c');
            var expectedPassword = "ccccccccc";

            (Day2.Part2.PasswordPolicy passwordPolicy, string password) = Day2.Part2.PasswordPolicy.Parse(policy);

            passwordPolicy.Should().BeEquivalentTo(expectedPolicy);
            password.Should().Be(expectedPassword);
        }
    }
}
