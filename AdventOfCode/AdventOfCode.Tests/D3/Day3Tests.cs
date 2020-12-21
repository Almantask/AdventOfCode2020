using System.Collections.Generic;
using System.IO;
using AdventOfCode.D3;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.D3
{
    public class Day3Tests
    {
        [Theory]
        [MemberData(nameof(Part1TreesDownTheSlopeExpectations))]
        public void Part1_Solve_Returns_TreesDownTheSlope(string map, int expectedTreesInTheWay)
        {
            var treesInTheWay = Day3.Part1.Solve(map, new Day3.Step(3,1));

            treesInTheWay.Should().Be(expectedTreesInTheWay);
        }

        [Theory]
        [MemberData(nameof(Part2TreesDownTheSlopeExpectations))]
        public void Part2_Solve_Returns_TreesDownTheSlope(string map, int expectedTreesInTheWay)
        {
            var treesInTheWay = Day3.Part2.Solve(map);

            treesInTheWay.Should().Be(expectedTreesInTheWay);
        }

        [Theory]
        [MemberData(nameof(ProductExpectations))]
        public void Product_Returns_MultipliedNumbers(int[] numbers, long expectedProduct)
        {
            var product = numbers.Product(i => i);

            product.Should().Be(expectedProduct);
        }


        public static IEnumerable<object[]> Part1TreesDownTheSlopeExpectations
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

        public static IEnumerable<object[]> Part2TreesDownTheSlopeExpectations
        {
            get
            {
                yield return new object[] { Input("Default"), 336 };
                yield return new object[] { Input("OnlyTreesButTooSmall"), 0 };
                yield return new object[] { Input("x6NoTreesDown"), 0 };
                yield return new object[] { Input("x6TreesDown"), 1250 };
                yield return new object[] { Input("x7TreesDown"), 3888 };
            }
        }

        public static IEnumerable<object[]> ProductExpectations
        {
            get
            {
                yield return new object[]{new []{2,3}, 6};
                yield return new object[] { new[] { 2, 3, 4, 5 }, 120 };
                yield return new object[] { new[] { int.MaxValue, 2 }, (long)int.MaxValue * 2 };
                yield return new object[]{new []{1,0}, 0};
                yield return new object[]{new []{2}, 2};
            }
        }

        private static string Input(string file)
        {
            return File.ReadAllText($"Input/D3/{file}.txt");
        }
    }
}
