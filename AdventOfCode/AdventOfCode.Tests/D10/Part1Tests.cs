using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AdventOfCode.D10;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.D10
{
    public class Part1Tests
    {
        [Theory]
        [MemberData(nameof(SolveExpectations))]
        public void Solve_Returns_SumOf_1jAnd2jDifferences(string input, long expectedSum)
        {
            var solution = new Day10.Part1();

            // diff 1j * diff 3j
            var sum = solution.Solve(input);

            sum.Should().Be(expectedSum);
        }

        public static IEnumerable<object[]> SolveExpectations
        {
            get
            {
                yield return Expect("DefaultExample1", 35);
                yield return Expect("DefaultExample2", 220);

                object[] Expect(string file, long expectedSum)
                {
                    return new object[]
                    {
                        File.ReadAllText($"Input/D10/P1/{file}.txt"),
                        expectedSum
                    };
                }
            }
        }
    }
}
