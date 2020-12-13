using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.D6;
using FluentAssertions;
using Xunit;
using static AdventOfCode.D6.Day6;

namespace AdventOfCode.Tests
{
    public class Day6Tests
    {
        [Theory]
        [MemberData(nameof(ExpectedPart2Solutions))]
        public void Part2Solve_Returns_SumOf_SharedYesses(string customsDeclarationsFormYesses, int expectedSum)
        {
            var sharedYessesSum = Part2.Solve(customsDeclarationsFormYesses);

            sharedYessesSum.Should().Be(expectedSum);
        }

        [Theory]
        [MemberData(nameof(ExcpectedGetSharedYesses))]
        public void GetSharedYesses_Returns_SumOf_DuplicateLetters_ForAllPeople(string group, int expectedSum)
        {
            int duplicatesSum = Part2.GetSharedYesses(group);

            duplicatesSum.Should().Be(expectedSum);
        }

        [Theory]
        [MemberData(nameof(ExpectedPart1Solutions))]
        public void Part1_Solve_Returns_SumOf_UniqueAnswersCounts_PerGroup(string customsDeclarationFormsYesses, int expectedUniqueYesses)
        {
            var uniqueYesses = Part1.Solve(customsDeclarationFormsYesses);

            uniqueYesses.Should().Be(expectedUniqueYesses);
        }

        [Theory]
        [MemberData(nameof(ExpectedUniqueLetters))]
        public void GetUniqueLetters_ReturnsUniqueLetters(string group, char[] expectedUniqueLetters)
        {
            var uniqueLetters = group.GetUniqueLetters();

            uniqueLetters.Should().BeEquivalentTo(expectedUniqueLetters);
        }

        public static IEnumerable<object[]> ExpectedPart2Solutions
        {
            get
            {
                yield return Expect("OnePersonA", 1);
                yield return Expect("TwoPeopleSameGroupA", 1);
                yield return Expect("TwoGroupsA", 2);
                yield return Expect("ThreeGroupsMixed", 5);
            }
        }

        public static IEnumerable<object[]> ExpectedUniqueLetters
        {
            get
            {
                yield return new object[] { "a", new []{'a'}};
                yield return new object[] { "abb", new []{'a','b'}};
            }
        }

        public static IEnumerable<object[]> ExpectedPart1Solutions
        {
            get
            {
                yield return Expect("OnePersonA", 1);
                yield return Expect("TwoGroupsA", 2);
                yield return Expect("TwoPeopleSameGroupA", 1);
                yield return Expect("ThreeGroupsMixed", 7);
            }
        }

        public static IEnumerable<object[]> ExcpectedGetSharedYesses
        {
            get
            {
                yield return new object[]{ "a", 1};
                yield return new object[] { "a" + Environment.NewLine +
                                            "a", 1 };
                yield return new object[] { "a" + Environment.NewLine +
                                            "b", 0 };
                yield return new object[] { "aa" + Environment.NewLine +
                                            "bb", 0 };
                yield return new object[] { "ab" + Environment.NewLine +
                                            "ab", 2 };
                yield return new object[] { "ab" + Environment.NewLine +
                                            "aa", 1 };
                yield return new object[] { "ab" + Environment.NewLine +
                                            "bc", 1 };
                yield return new object[] { "abc" + Environment.NewLine +
                                            "abc", 3 };
            }
        }

        static object[] Expect(string file, int expectedCount)
            => new object[] { File.ReadAllText($"Input/Day6/{file}.txt"), expectedCount };
    }
}
