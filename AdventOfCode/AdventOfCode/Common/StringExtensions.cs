using System;
using System.Linq;

namespace AdventOfCode.Common
{
    public static class StringExtensions
    {
        public static string[] SplitByBlankLine(this string text)
            => text.Split($"{Environment.NewLine}{Environment.NewLine}");

        public static long[] ToNumbersSplitByLineL(this string text)
        {
            var numbers = text
                .Split(Environment.NewLine)
                .Select(long.Parse)
                .ToArray();

            return numbers;
        }

        public static int[] ToNumbersSplitByLineI(this string text)
        {
            var numbers = text
                .Split(Environment.NewLine)
                .Select(int.Parse)
                .ToArray();

            return numbers;
        }
    }
}
