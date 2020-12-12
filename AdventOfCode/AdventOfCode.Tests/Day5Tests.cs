using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;
using static AdventOfCode.D5.Day5;

namespace AdventOfCode.Tests
{
    public class Day5Tests
    {
        [Theory]
        [MemberData(nameof(CombosWithMissingExpectation))]
        public void Part2_Solve_Given_AllPossibleCombosExceptOne_Returns_ThatOne(IEnumerable<string> binaryBoardingPassPartitions, int expectedSeat)
        {
            var missingSeat = Part2.Solve(binaryBoardingPassPartitions);

            missingSeat.Should().Be(expectedSeat);
        }

        [Fact]
        public void Part1_Solve_Returns_MaxSeatId()
        {
            string[] partitions =
            {
                "BFFFBBFRRR",
                "FFFBBBFRRR",
                "BBFFBBFRLL",
            };
            const int expectedMax = 820;

            var max = Part1.Solve(partitions);

            max.Should().Be(expectedMax);
        }

        [Theory]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        public void BoardingPass_SeatId_Returns_SumOfRowsTimesColumnsPlusColumn(string binaryPartition, int expectedSeatId)
        {
            var pass = new BoardingPass(binaryPartition);

            var seatId = pass.SeatId;

            seatId.Should().Be(expectedSeatId);
        }

        [Theory]
        [InlineData("BBBBBBBRRR", 127)]
        [InlineData("FFFFFFFRRR", 0)]
        [InlineData("BFFFFFFRRR", 64)]
        [InlineData("BFFFBBFRRR", 70)]
        [InlineData("FFFBBBFRRR", 14)]
        [InlineData("BBFFBBFRRR", 102)]
        public void BoardingPass_Row_Returns_BinaryParitionedRow(string binaryPartition, int expectedRow)
        {
            var pass = new BoardingPass(binaryPartition);

            var row = pass.Row;

            row.Should().Be(expectedRow);
        }

        [Theory]
        [InlineData("FFFFFFFLLL", 0)]
        [InlineData("BFFFBBFRRR", 7)]
        [InlineData("BBFFBBFRLL", 4)]
        [InlineData("BBFFBBFLLR", 1)]
        public void BoardingPass_Column_Returns_BinaryParitionedColumn(string binaryPartition, int expectedColumn)
        {
            var pass = new BoardingPass(binaryPartition);

            var column = pass.Column;

            column.Should().Be(expectedColumn);
        }

        public static IEnumerable<object[]> CombosWithMissingExpectation
        {
            get
            {
                var allPossiblePartitions = Enumerable.Range(0, TotalSeats)
                    .Select(sid => ToPartition(sid))
                    .ToArray();

                var first = allPossiblePartitions.First();
                var last = allPossiblePartitions.Last();
                var middle = allPossiblePartitions[allPossiblePartitions.Length / 2];

                yield return new object[]{ allPossiblePartitions.Except(new []{first, last, middle}), new BoardingPass(middle).SeatId};
                yield return new object[]{ allPossiblePartitions.Except(new []{last, middle }), new BoardingPass(middle).SeatId };
                yield return new object[]{ allPossiblePartitions.Except(new []{middle }), new BoardingPass(middle).SeatId };

                var lastInFirstRow = allPossiblePartitions[MaxCols - 1];
                var firstInSecondRow = allPossiblePartitions[MaxCols];
                yield return new object[] { allPossiblePartitions.Except(new[] { lastInFirstRow, firstInSecondRow }), new BoardingPass(firstInSecondRow).SeatId };
                yield return new object[] { allPossiblePartitions.Except(new[] { firstInSecondRow }), new BoardingPass(firstInSecondRow).SeatId };

                static string ToPartition(int seatId)
                {
                    var cols = seatId % MaxCols;
                    var rows = seatId / MaxCols;

                    var sb = new StringBuilder();
                    var divider = MaxRows / 2;
                    while (divider > 0)
                    {
                        var isF = (rows / divider) == 0;
                        rows %= divider;
                        divider /= 2;
                        sb.Append(isF ? Direction.Front : Direction.Back);
                    }

                    divider = MaxCols / 2;
                    while (divider > 0)
                    {
                        var isR = (cols / divider) == 1;
                        cols %= divider;
                        divider /= 2;
                        sb.Append(isR ? Direction.Right : Direction.Left);
                    }

                    return sb.ToString();
                }
            }
        }
    }
}
