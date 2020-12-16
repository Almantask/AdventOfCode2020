using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Xunit;
using static AdventOfCode.D4.Day4;

namespace AdventOfCode.Tests.D4
{
    public class Part2Tests
    {
        [Theory]
        [MemberData(nameof(Part2SolveExpectations))]
        public void Part2_Solve_Returns_ValidPassportsCount(string passports, int expectedValidCount)
        {
            var validCount = Part2.Solve(passports);

            validCount.Should().Be(expectedValidCount);
        }

        public static IEnumerable<object[]> Part2SolveExpectations
        {
            get
            {
                yield return Expect("Part2/0Valid", 0);
                yield return Expect("Part2/1Valid", 1);
                yield return Expect("Part2/2Valid", 2);

                object[] Expect(string input, int isValidCount) => new object[] { Input(input), isValidCount };
            }
        }

        private static string Input(string file)
        {
            return File.ReadAllText($"Input/Day4/{file}.txt");
        }
    }
}
