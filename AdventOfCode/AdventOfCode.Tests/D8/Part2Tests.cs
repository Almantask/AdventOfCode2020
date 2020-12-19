using System.Collections.Generic;
using System.IO;
using AdventOfCode.D8;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.D8
{
    public class Part2Tests
    {
        [Theory]
        [MemberData(nameof(SolveExpectations))]
        public void Solve_Returns_Accumulator_AtAppTermination(string input, int expectedAccumulator)
        {
            var solution = new Day8.Part2();

            var accumulator = solution.Solve(input);

            accumulator.Should().Be(expectedAccumulator);
        }

        public static IEnumerable<object[]> SolveExpectations
        {
            get
            {
                yield return Expect("1stJmpInfinite", 1);
                yield return Expect("1stNopInfinite", 3);
                yield return Expect("2ndJmpInfinite", 0);
                yield return Expect("DefaultExample", 8);

                static object[] Expect(string file, int expectedAccumulator)
                {
                    return new object[]
                    {
                        File.ReadAllText($"Input/D8/P2/{file}.txt"),
                        expectedAccumulator
                    };
                }
            }
        }
    }
}
