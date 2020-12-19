using AdventOfCode.D8;
using FluentAssertions;
using Xunit;
using static AdventOfCode.D8.ConsoleBooter.Instructions;

namespace AdventOfCode.Tests.D8
{
    public class InstructionTests
    {
        [Fact]
        public void Parse_Returns_WithValueAndName()
        {
            string input = $"{Jump} +1";
            var expected = new Instruction(Jump, 1);

            var instruction = Instruction.Parse(input);

            instruction.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Visit_Sets_IsVisited_ToTrue()
        {
            var instruction = new Instruction(Jump, 1);

            instruction.Visit();

            instruction.IsVisited.Should().BeTrue();
        }

        [Fact]
        public void Visit_AlreadyVisisted_KeepsVisited()
        {
            var instruction = new Instruction(Jump, 1);
            instruction.Visit();

            instruction.Visit();

            instruction.IsVisited.Should().BeTrue();
        }

        [Theory]
        [InlineData(Jump, Ignore)]
        [InlineData(Ignore, Jump)]
        [InlineData(Increment, Increment)]
        public void Swap_TurnsJmpToNop_AndViceVersa(string givenName, string expectedName)
        {
            var instruction = new Instruction(givenName, 0);

            instruction.Swap();

            instruction.Name.Should().Be(expectedName);
        }

        [Fact]
        public void Reset_Sets_IsVisited_ToFalse()
        {
            var instruction = new Instruction("", 0);
            instruction.Visit();

            instruction.Reset();

            instruction.IsVisited.Should().BeFalse();
        }
    }
}
