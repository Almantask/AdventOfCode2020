using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.D10
{
    public class Day10 : AdventOfCodeDay<Day10.Part1, Day10.Part2>
    {
        protected override int Day => 10;

        public class Part1 : ISolution
        {
            public long Solve(string input)
            {
                var adapters = new ChainedAdapters(input.ToNumbersSplitByLineI());

                return adapters.Count1jJumps() * adapters.Count3jJumps();
            }
        }

        public class Part2 : ISolution
        {
            public long Solve(string input)
            {
                return 0;
            }
        }

        public class ChainedAdapters
        {
            private const int YourDeviceVoltage = 3;
            private readonly int[] _voltages;
            
            public int MaxVoltage { get; }

            public ChainedAdapters(int[] voltages)
            {
                _voltages = voltages
                    .OrderBy(v => v)
                    .ToArray();

                MaxVoltage = _voltages.Max() + YourDeviceVoltage;
            }

            public int Count1jJumps() => CountDifferences(1);

            // Your own device counts too.
            public int Count3jJumps() => CountDifferences(3) + 1;

            private int CountDifferences(int difference)
            {
                var count = (_voltages[0] == difference) ? 1 : 0;
                for (var index = 1; index < _voltages.Length; index++)
                {
                    var previous = _voltages[index-1];
                    var current = _voltages[index];

                    if (current - previous == difference)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

    }
}
