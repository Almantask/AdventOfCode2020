using System.Collections.Generic;
using System.IO;
using AdventOfCode.D7;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.D7
{
    public class Part1Tests
    {
        [Theory]
        [MemberData(nameof(SolveExpectations))]
        public void Solve_Returns_ExpectedShinyGoldCount(string rules, int expectedShinyGoldCount)
        {
            var goldCount = Day7.Part1.Solve(rules);

            goldCount.Should().Be(expectedShinyGoldCount);
        }

        public static IEnumerable<object[]> SolveExpectations
        {
            get
            {
                yield return Expect("ShinyBagCannotContain", 0);
                yield return Expect("SingleBagContainsDirectly", 1);
                yield return Expect("SingleBagContainsNested", 2);
                yield return Expect("SingleBagContainsOthersWhichCantContain", 0);
                yield return Expect("SingleBagContainsNestedAndDirect", 2);


                static object[] Expect(string file, int expectedShinyCount)
                {
                    return new object[]
                    {
                        File.ReadAllText($"Input/Day7/{file}.txt"),
                        expectedShinyCount
                    };
                }
            }
        }
    }
}
