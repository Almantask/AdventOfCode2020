using System.Collections.Generic;
using System.IO;
using AdventOfCode.D9;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.D9
{
    public class Part1
    {
        [Theory]
        [MemberData(nameof(SolveExpectations))]
        public void Solve_Returns_NumberWhichIsNotASumOf2TillPreamble(int preamble, string input, long expectedOddOne)
        {
            var solution = new Day9.Part1(preamble);

            var oddOne = solution.Solve(input);

            oddOne.Should().Be(expectedOddOne);
        }

        [Theory]
        [MemberData(nameof(IsSumOf2NumbersBeforeExpectations))]
        public void IsSumOf2NumbersBefore_Returns_WhetherAnyTwoNumbersUntilPreamble_MakesUpAWantedSum(int neededNumberIndex, long[] numbers, int preamble, bool expectedIsSumOf2Previous)
        {
            var isSumOf2Before = Day9.IsSumOf2NumbersBefore(neededNumberIndex, numbers, preamble);

            isSumOf2Before.Should().Be(expectedIsSumOf2Previous);
        }

        public static IEnumerable<object[]> IsSumOf2NumbersBeforeExpectations
        {
            get
            {
                yield return Expect(2, new long[] {1, 1, 2}, 2, true);
                yield return Expect(2, new long[] {1, 1, 3}, 2, false);
                yield return Expect(3, new long[] {2, 1, 3, 5}, 3, true);
                yield return Expect(3, new long[] {1, 1, 3, 5}, 3, false);
                yield return Expect(3, new long[] {0, 1, 1, 2, 5}, 3, true);
                yield return Expect(3, new long[] {0, 1, 1, 3, 5}, 3, false);
                yield return Expect(3, new long[] {1, 2, 3, 6, 3}, 2, false);

                static object[] Expect(int neededNumberIndex, long[] numbers, int preamble, bool isSumOf2Previous)
                    => new object[] {neededNumberIndex, numbers, preamble, isSumOf2Previous};
            }
        }

        public static IEnumerable<object[]> SolveExpectations
        {
            get
            {
                yield return Expect(2, "2sAnd1sAnd3sAnd6", 6);
                yield return Expect(3, "All1s", 1);
                yield return Expect(5, "DefaultExample", 127);

                static object[] Expect(int preamble, string file, int expectedOddOne)
                {
                    return new object[]
                    {
                        preamble,
                        File.ReadAllText($"Input/D9/P1/{file}.txt"),
                        expectedOddOne
                    };
                }
            }
        }
    }
}
