using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.D1
{
    public class Day1
    {
        public const int NeededSum = 2020;

        public static void Solve()
        {
            var numbers = File.ReadAllLines("D1/Input.txt")
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine("D1P1 answer: " + Part1.Solve(numbers, NeededSum));
            Console.WriteLine("D1P2 answer: " + Part2.Solve(numbers, NeededSum));
        }

        public static class Part1
        {
            /// <summary>
            /// find the two entries that sum to 2020 and then multiply those two numbers together
            /// </summary>
            public static int Solve(int[] numbers, int neededSum)
            {
                for (var index = 0; index < numbers.Length; index++)
                {
                    int a = numbers[index];
                    for (var index2 = index; index2 < numbers.Length; index2++)
                    {
                        var b = numbers[index2];
                        if (a + b == neededSum) return a * b;
                    }
                }

                return -1;
            }
        }

        public static class Part2
        {
            /// <summary>
            /// find the three entries that sum to 2020 and then multiply those three numbers together
            /// </summary>
            public static int Solve(int[] numbers, int neededSum)
            {
                foreach (var number in numbers)
                {
                    var result = Part1.Solve(numbers, neededSum - number);
                    if (result != -1) return result * number;
                }

                return -1;
            }
        }
    }
}
