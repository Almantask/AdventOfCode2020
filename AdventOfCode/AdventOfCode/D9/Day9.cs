using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode.D9
{
    public class Day9 : AdventOfCodeDay<Day9.Part1, Day9.Part2>
    {
        protected override int Day => 9;

        public class Part1 : ISolution
        {
            private readonly int _preamble;

            public Part1():this(25) {}
            public Part1(int preamble) => _preamble = preamble;

            /// <summary>
            /// Find the number that throughout preamble, is not a sum of numbers before.
            /// </summary>
            public long Solve(string input)
            {
                var numbers = input.ToNumbersSplitByLine();
                return Solve(numbers);
            }

            public long Solve(long[] numbers)
            {
                for (int i = _preamble; i < numbers.Length; i++)
                {
                    if (!IsSumOf2NumbersBefore(i, numbers, _preamble))
                    {
                        return numbers[i];
                    }
                }

                return -1;
            }
        }

        public class Part2 : ISolution
        {
            private readonly int _preamble;

            public Part2() : this(25){}
            public Part2(int preamble) => _preamble = preamble;

            /// <summary>
            /// Finds a consequitive sequence of numbers that sums to the odd one from the sequence.
            /// Then sums min and max of that sequence.
            /// </summary>
            public long Solve(string input)
            {
                var numbers = input.ToNumbersSplitByLine();
                var oddOne = new Part1(_preamble).Solve(numbers);
                TryGetNumbersOfSum(oddOne, numbers, out var summedNumbers);

                return summedNumbers.Min() + summedNumbers.Max();
            }
        }

        /// <summary>
        /// Is number pointing at checked number index a result of adding any two numbers before it,
        /// but not more before than a preamble? 
        /// </summary>
        /// <param name="checkedNumberIndex">Index for a number which should have a sum of two numbers.</param>
        /// <param name="numbers">Sequence of numbers.</param>
        /// <param name="preamble">Count of numbers in a sequence will be included for finding the sum of two previous numbers.</param>
        /// <returns>True, if number at index can be made from any two numbers up until preamble.</returns>
        public static bool IsSumOf2NumbersBefore(int checkedNumberIndex, long[] numbers, int preamble)
        {
            var needed = numbers[checkedNumberIndex];
            var offset = checkedNumberIndex - preamble;
            for (var i = 0; i < preamble - 1; i++)
            {
                var first = numbers[offset + i];
                for (int j = i + 1; j < preamble; j++)
                {
                    var second = numbers[offset + j];
                    if (first + second == needed)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Get numbers that can be summed to the needed number.
        /// </summary>
        /// <param name="neededNumber">Number to which the sum of sum numbers is equal to.</param>
        /// <param name="numbers">All possible numbers.</param>
        /// <param name="sumNumbers">Summed numbers.</param>
        /// <returns>False if numbers cannot be summed to the needed number.</returns>
        public static bool TryGetNumbersOfSum(long neededNumber, long[] numbers, out long[] sumNumbers)
        {
            var result = new List<long>();
            for (int i = 0; i < numbers.Length; i++)
            {
                result.Clear();
                long sum = 0;

                // is the chunk summable?
                for (var j = i; j < numbers.Length; j++)
                {
                    var number = numbers[j];
                    if (number == neededNumber)
                    {
                        break;
                    }

                    result.Add(number);
                    
                    sum += number;
                    if (sum > neededNumber)
                    {
                        break;
                    }

                    if(sum == neededNumber)
                    {
                        sumNumbers = result.ToArray();
                        return true;
                    }
                }
            }
            
            sumNumbers = null;
            return false;
        }
    }
}
