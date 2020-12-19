using AdventOfCode.D8;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using static AdventOfCode.D8.ConsoleBooter.Instructions;

namespace AdventOfCode.Tests.D8
{
    public class ConsoleBooterTests
    {
        [Fact]
        public void IsTerminated_AfterNext_WhenLast_Returns_True()
        {
            var instructions = new[] {new Instruction(Increment, 0)};
            var booter = new ConsoleBooter(instructions);
            booter.NextInstruction();

            var isTerminated = booter.IsTerminated;

            isTerminated.Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        public void Next_When_NoOperation_MovesForward(int instructionsCount, int expectedNextInstructionIndex)
        {
            var instructions = new Instruction[instructionsCount];
            instructions[0] = new Instruction(Ignore, 99);
            var consoleBooter = new ConsoleBooter(instructions);
            var expectedNextInstruction = instructions[expectedNextInstructionIndex];

            consoleBooter.NextInstruction();

            consoleBooter.CurrentInstruction.Should().BeEquivalentTo(expectedNextInstruction);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(1, 2, 1)]
        [InlineData(-1, 2, 1)]
        [InlineData(-3, 2, 1)]
        [InlineData(2, 2, 0)]
        public void Jump_JumpsToExpectedInstruction(int jumpBy, int instructionsCount, int expectedNextInstructionIndex)
        {
            var instructions = new Instruction[instructionsCount];
            instructions[0] = new Instruction(Jump, jumpBy);
            var expectedNextInstruction = instructions[expectedNextInstructionIndex];

            var consoleBooter = new ConsoleBooter(instructions);

            consoleBooter.NextInstruction();

            consoleBooter.CurrentInstruction.Should().BeEquivalentTo(expectedNextInstruction);
        }

        [Theory]
        [InlineData(1, 0, 0, 1, 1)]
        [InlineData(2, 1, 1, -2, -1)]
        public void Accumulate_MovesForward_And_Increments_Accumulator(int instructionsCount, int expectedNextInstructionIndex, int initialAccumulator, int increment, int expectedAccumulator)
        {
            var instructions = new Instruction[instructionsCount];
            instructions[0] = new Instruction(Increment, increment);
            var consoleBooter = new ConsoleBooter(instructions, initialAccumulator);
            var expectedNextInstruction = instructions[expectedNextInstructionIndex];

            consoleBooter.NextInstruction();

            using (new AssertionScope())
            {
                consoleBooter.CurrentInstruction.Should().BeEquivalentTo(expectedNextInstruction);
                consoleBooter.Accumulator.Should().Be(expectedAccumulator);
            }
        }

        [Theory]
        [InlineData(Jump, Ignore)]
        [InlineData(Ignore, Jump)]
        [InlineData(Increment, Increment)]
        public void Swap_SwapsNopWithJmp(string givenName, string expectedName)
        {
            var instruction = new [] { new Instruction(givenName, 0) };
            var booter = new ConsoleBooter(instruction);
            
            booter.SwapAt(0);

            booter.CurrentInstruction.Name.Should().Be(expectedName);
        }

        [Fact]
        public void Reset_SetsAllIsVisitedToFalse_And_ResetsAmendedInstruction_And_SetsCurrentInstructionTo0_AndSetsAccumulatorTo0()
        {
            var instructionsOriginal = new [] { new Instruction(Increment, 1), new Instruction(Ignore, 1),  };
            var booter = new ConsoleBooter(instructionsOriginal);
            booter.NextInstruction();
            booter.SwapAt(1);

            booter.Reset();

            using (new AssertionScope())
            {
                booter.Accumulator.Should().Be(0);

                booter.CurrentInstruction.IsVisited.Should().BeFalse();
                booter.CurrentInstruction.Name.Should().Be(instructionsOriginal[0].Name);

                booter.NextInstruction();
                booter.CurrentInstruction.Name.Should().Be(instructionsOriginal[1].Name);
            }
        }
    }
}
