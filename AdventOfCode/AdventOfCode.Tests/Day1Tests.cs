using System.Collections.Generic;
using AdventOfCode.D1;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day1Tests
    {
        [Theory]
        [MemberData(nameof(ExpectedResultsD1P1))]
        public void SolveP1_Returns_Multiplied_2_Entries_SumEqualTo2020(int[] numbers, int expected)
        {
            var result = Day1.Part1.Solve(numbers, Day1.NeededSum);

            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(ExpectedResultsD1P2))]
        public void SolveP2_Returns_Multiplied_3_Entries_SumEqualTo2020(int[] numbers, int expected)
        {
            var result = Day1.Part2.Solve(numbers, Day1.NeededSum);

            result.Should().Be(expected);
        }

        public static IEnumerable<object[]> ExpectedResultsD1P1
        {
            get
            {
                // Basic scenario
                yield return new object[]
                {
                    new[] {1,9,2019,3},
                    2019
                };

                // Default given
                yield return new object[]
                {
                    new[] {1721, 979, 366, 299, 675, 1456},
                    514579
                };
            }
        }

        public static IEnumerable<object[]> ExpectedResultsD1P2
        {
            get
            {
                // Basic scenario
                yield return new object[]
                {
                    new[] {1,1,9,2018,3},
                    2018
                };

                // Default given
                yield return new object[]
                {
                    new[] {1721, 979, 366, 299, 675, 1456},
                    241861950
                };
            }
        }
    }
}
