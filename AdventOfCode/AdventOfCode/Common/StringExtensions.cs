using System;

namespace AdventOfCode.Common
{
    public static class StringExtensions
    {
        public static string[] SplitByBlankLine(this string text)
            => text.Split($"{Environment.NewLine}{Environment.NewLine}");
    }
}
