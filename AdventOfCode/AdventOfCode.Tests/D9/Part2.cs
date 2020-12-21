using System.Collections.Generic;
using System.IO;
using AdventOfCode.D9;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AdventOfCode.Tests.D9
{
    public class Part2
    {
        [Theory]
        [MemberData(nameof(SolveExpectations))]
        public void Solve_Returns_NumberWhichIsNotASumOf2TillPreamble(int preamble, string input, long expectedOddOne)
        {
            var solution = new Day9.Part2(preamble);

            var oddOne = solution.Solve(input);

            oddOne.Should().Be(expectedOddOne);
        }

        [Theory]
        [MemberData(nameof(TryGetNumbersOfSumExpectations))]
        public void TryGetNumbersOfSum_Returns_True_IfCanBeSummed_And_NumbersOfSum(long neededNumber, long[] numbers, bool expectedIsSummable, long[] expectedSummedNumbers)
        {
            var isSummable = Day9.TryGetNumbersOfSum(neededNumber, numbers, out var summedNumbers);

            using (new AssertionScope())
            {
                isSummable.Should().Be(expectedIsSummable);
                summedNumbers.Should().BeEquivalentTo(expectedSummedNumbers);
            }
        }

        public static IEnumerable<object[]> TryGetNumbersOfSumExpectations
        {
            get
            {
                yield return Expect(2, new long[] {1, 1, 2}, true, new long[]{1,1});
                yield return Expect(3, new long[] {1, 1, 3}, false, null);
                yield return Expect(5, new long[] {2, 1, 3, 5}, false, null);
                yield return Expect(5, new long[] {1, 1, 3, 5}, true, new long[]{1,1,3});
                yield return Expect(5, new long[] {0, 1, 1, 2, 5}, false, null);
                yield return Expect(5, new long[] {1, 0, 1, 3, 5, 6}, true, new long[]{1, 0, 1, 3});
                yield return Expect(6, new long[] {1, 0, 1, 3, 5, 6}, false, null);
                yield return Expect(6, new long[] {1, 2, 3, 6, 3}, true, new long[]{1,2,3});

                static object[] Expect(long neededNumber, long[] numbers, bool isSummable, long[] sumNumbers)
                    => new object[] { neededNumber, numbers, isSummable, sumNumbers };
            }
        }

        public static IEnumerable<object[]> SolveExpectations
        {
            get
            {
                yield return Expect(2, "2sAnd1sAnd3sAnd6", 4);
                yield return Expect(3, "All1sAnd3", 2);
                yield return Expect(5, "DefaultExample", 62);

                static object[] Expect(int preamble, string file, long expectedOddOne)
                {
                    return new object[]
                    {
                        preamble,
                        File.ReadAllText($"Input/D9/P2/{file}.txt"),
                        expectedOddOne
                    };
                }
            }
        }
    }
}
