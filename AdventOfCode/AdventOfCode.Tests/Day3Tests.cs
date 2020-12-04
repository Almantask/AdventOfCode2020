using System.Collections.Generic;
using System.IO;
using AdventOfCode.D3;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day3Tests
    {
        [Theory]
        [MemberData(nameof(TreesDownTheSlopeExpectations))]
        public void Part1_Solve_Returns_TreesDownTheSlope(string map, int expectedTreesInTheWay)
        {
            var treesInTheWay = Day3.Part1.Solve(map);

            treesInTheWay.Should().Be(expectedTreesInTheWay);
        }

        public static IEnumerable<object[]> TreesDownTheSlopeExpectations
        {
            get
            {
                yield return new object[] {Input("Default"), 7};
                yield return new object[] {Input("OnlyTreesButTooSmall"), 1 };
                yield return new object[] {Input("x6NoTreesDown"), 0 };
                yield return new object[] {Input("x6TreesDown"), 5 };
                yield return new object[] {Input("x7TreesDown"), 6 };
            }
        }

        private static string Input(string file)
        {
            const string baseDir = "Input/Day3";
            return File.ReadAllText($"{baseDir}/{file}.txt");
        }
    }
}
