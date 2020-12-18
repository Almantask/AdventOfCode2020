using AdventOfCode.Common;

namespace AdventOfCode.D8
{
    public class Day8 : AdventOfCodeDay<Day8.Part1, Day8.Part2>
    {
        protected override int Day => 8;

        public static class Instructions
        {
            /// <summary>
            /// Do nothing. Ignore number after
            /// </summary>
            public const string Ignore = "nop";
            /// <summary>
            /// Jump to next instruction indicated by a number next to 
            /// </summary>
            public const string Jump = "jmp";
            /// <summary>
            /// Add to global accumulator.
            /// </summary>
            public const string Increment = "";
        }

        public class Part2 : ISolution
        {
            /// <summary>
            /// 
            /// </summary>
            public int Solve(string input)
            {
                return 0;
            }
        }

        /// <summary>
        /// Instructions cause a loop. When does the loop happen?
        /// </summary>
        public class Part1 : ISolution
        {
            /// <summary>
            /// Get first repeated instruction (loop start)
            /// </summary>
            public int Solve(string input)
            {
                return 0;
            }
        }
    }
}
