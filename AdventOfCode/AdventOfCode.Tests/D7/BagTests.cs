using System.Collections.Generic;
using AdventOfCode.D7;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.D7
{
    public class BagTests
    {
        [Theory]
        [MemberData(nameof(BagParseExpectations))]
        public void Bag_Parse_Returns_Bag_WithExpected_BagCounts(string rule, BagRules expectedBagRules)
        {
            var bag = BagRules.Parse(rule);

            bag.Should().BeEquivalentTo(expectedBagRules);
        }

        public static IEnumerable<object[]> BagParseExpectations
        {
            get
            {
                yield return new object[]
                {
                    "faded blue bags contain no other bags.",
                    new BagRules(
                        "faded blue",
                        new Dictionary<string, int>()
                    )
                };

                yield return new object[]
                {
                    "bright white bags contain 1 shiny gold bag.",
                    new BagRules(
                        "bright white",
                        new Dictionary<string, int>()
                        {
                            {"shiny gold", 1}
                        }
                    )
                };

                yield return new object[]
                {
                    "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                    new BagRules(
                        "light red",
                        new Dictionary<string, int>
                        {
                            {"bright white", 1},
                            {"muted yellow", 2},
                        }
                    )
                };
            }
        }
    }
}
