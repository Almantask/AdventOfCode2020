using System.Collections.Generic;
using AdventOfCode.D7;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.D7
{
    public class BagsTests
    {
        // Multiple roots
        // Is root? - mentioned once
        // New Tree6
        [Theory]
        [MemberData(nameof(CountShinyGoldExpectations))]
        public void CountShinyGold_Returns_ShineyGoldBagsCount(Bags bags, int expectedGold)
        {
            var shinyGold = bags.CountShinyGold();

            shinyGold.Should().Be(expectedGold);
        }

        public static IEnumerable<object[]> CountShinyGoldExpectations
        {
            get
            {
                yield return new object[]
                {
                    new Bags(
                        new []
                        {
                            new BagRules("a", new Dictionary<string, int>
                            {
                                {"b",1}
                            })
                        }),
                    0
                };

                yield return new object[]
                {
                    new Bags(
                        new []
                        {
                            new BagRules("a", new Dictionary<string, int>
                            {
                                {Day7.ShinyGold,1}
                            })
                        }),
                    1
                };

                yield return new object[]
                {
                    new Bags(
                        new []
                        {
                            new BagRules("a", new Dictionary<string, int>
                            {
                                {Day7.ShinyGold,1}
                            }),
                            new BagRules("b", new Dictionary<string, int>
                            {
                                {Day7.ShinyGold,1}
                            })
                        }),
                    2
                };


                yield return new object[]
                {
                    new Bags(
                        new []
                        {
                            new BagRules("a", new Dictionary<string, int>
                            {
                                {Day7.ShinyGold,1}
                            }),
                            new BagRules("b", new Dictionary<string, int>
                            {
                                {"a",1}
                            })
                        }),
                    2
                };

                yield return new object[]
                {
                    new Bags(
                        new []
                        {
                            new BagRules("a", new Dictionary<string, int>
                            {
                                {"b",1}
                            }),
                            new BagRules("b", new Dictionary<string, int>())
                        }),
                    0
                };
            }
        }
    }
}
