using System;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.D8
{
    public class Day8 : AdventOfCodeDay<Day8.Part1, Day8.Part2>
    {
        protected override int Day => 8;

        public class Part2 : ISolution
        {
            /// <summary>
            /// Fix the loop and return the accumulator value after the program terminates.
            /// Can only replace nop with jmp and jmp with nop.
            /// </summary>
            public int Solve(string input)
            {
                var instructions = input
                    .Split(Environment.NewLine)
                    .Select(i => Instruction.Parse(i))
                    .ToArray();

                var booter = new ConsoleBooter(instructions);
                for(var i = 0; i < instructions.Length; i++)
                {
                    if (instructions[i].Name == ConsoleBooter.Instructions.Increment) continue;

                    booter.SwapAt(i);
                    if (IsLoop(booter))
                    {
                        booter.Reset();
                    }
                    else
                    {
                        return booter.Accumulator;
                    }
                }

                return -1;
            }

            private static bool IsLoop(ConsoleBooter booter)
            {
                while (!booter.CurrentInstruction.IsVisited)
                {
                    booter.NextInstruction();
                }

                return !booter.IsTerminated;
            }
        }

        /// <summary>
        /// Instructions cause a loop. When does the loop happen?
        /// </summary>
        public class Part1 : ISolution
        {
            /// <summary>
            /// Get accumulator value at first repeated instruction (loop start)
            /// </summary>
            public int Solve(string input)
            {
                var instructions = input
                    .Split(Environment.NewLine)
                    .Select(i => Instruction.Parse(i))
                    .ToArray();

                var booter = new ConsoleBooter(instructions);
                while(!booter.CurrentInstruction.IsVisited)
                {
                    booter.NextInstruction();
                }

                return booter.Accumulator;
            }
        }
    }
}
