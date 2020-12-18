using System.Collections.Generic;
using System.IO;
using AdventOfCode.D7;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.D7
{
    public class Part2Tests
    {
        [Theory]
        [MemberData(nameof(SolveExpectations))]
        public void Solve_Returns_ExpectedShinyGoldCount(string rules, int expectedShinyGoldCount)
        {
            var goldCount = Day7.Part2.Solve(rules);

            goldCount.Should().Be(expectedShinyGoldCount);
        }

        public static IEnumerable<object[]> SolveExpectations
        {
            get
            {
                yield return Expect("Empty", 0);
                yield return Expect("NestedBags", 9);
                yield return Expect("Only3", 3);
                yield return Expect("3And2", 5);

                static object[] Expect(string file, int expectedShinySum)
                {
                    return new object[]
                    {
                        File.ReadAllText($"Input/D7/P2/{file}.txt"),
                        expectedShinySum
                    };
                }
            }
        }
    }
}
