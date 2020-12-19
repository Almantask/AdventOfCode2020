using System.Collections.Generic;
using System.IO;
using AdventOfCode.Common;
using AdventOfCode.D8;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.D8
{
    public class Part1Tests
    {
        [Theory]
        [MemberData(nameof(SolveExpectations))]
        public void Solve_Returns_Accumulator_AtLoopStart(string instructions, int expectedAccumulator)
        {
            var part1 = new Day8.Part1();
            
            var loopStart = part1.Solve(instructions);

            loopStart.Should().Be(expectedAccumulator);
        }

        public static IEnumerable<object[]> SolveExpectations
        {
            get
            {
                yield return Expect("AccLoopAt1", 1);
                yield return Expect("NopLoopAt1", 0);
                yield return Expect("JmpLoopAt1", 0);
                yield return Expect("LoopAt1With2", -2);
                yield return Expect("LoopAt2With2", 0);
                yield return Expect("JumpLoop", 0);
                yield return Expect("DefaultExample", 5);

                static object[] Expect(string file, int result)
                {
                    return new object[] {File.ReadAllText($"Input/D8/P1/{file}.txt"), result};
                }
            }
        }
    }
}
