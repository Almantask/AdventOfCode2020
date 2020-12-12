using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.D5
{
    public static class Day5
    {
        public const int MaxRows = 128;
        public const int MaxCols = 8;
        public const int TotalSeats = MaxRows * MaxCols;

        public static void Solve()
        {
            var boardingPassPartitions = File.ReadAllLines("D5/Input.txt");

            Console.WriteLine("D5P1 answer: " + Part1.Solve(boardingPassPartitions));
            Console.WriteLine("D5P2 answer: " + Part2.Solve(boardingPassPartitions));
        }

        public static class Direction
        {
            public const char Front = 'F';
            public const char Back = 'B';
            public const char Left = 'L';
            public const char Right = 'R';
        }

        public static class Part1
        {
            public static int Solve(IEnumerable<string> binaryBoardingPassPartitions)
            {
                return binaryBoardingPassPartitions
                    .Select(bpp => new BoardingPass(bpp).SeatId)
                    .Max();
            }
        }

        public static class Part2
        {
            public static int Solve(IEnumerable<string> binaryBoardingPassPartitions)
            {
                var rowIds = binaryBoardingPassPartitions
                    .Select(bpp => new BoardingPass(bpp).SeatId)
                    .OrderBy(id => id)
                    .ToArray();

                var start = rowIds.First();

                // Ignore first and last rows
                for (var i = MaxCols; i < rowIds.Length - MaxCols; i++)
                {
                    var currentExpected = i + start;
                    // If row id is not a sequential integer- that's our id.
                    if (rowIds[i] != currentExpected) return currentExpected;
                }

                return -1;
            }
        }

        public class BoardingPass
        {
            private readonly char[] _partition;

            public BoardingPass(string binarySpacePartitioning)
            {
                _partition = binarySpacePartitioning.ToCharArray(); ;
            }

            public int SeatId => Row * MaxCols + Column;

            public int Row
            {
                get
                {
                    var row = _partition[..MaxCols];
                    return Search(MaxRows, row, Direction.Back);
                }
            }

            public int Column
            {
                get
                {
                    var columns = _partition[(MaxCols-1)..];
                    return Search(MaxCols, columns, Direction.Right);
                }
            }

            private static int Search(int leftover, char[] map, char upper)
            {
                var spot = 0;
                for (var i = 0; i < map.Length; i++)
                {
                    leftover /= 2;
                    var isUpper = map[i] == upper;
                    spot += leftover * (isUpper ? 1 : 0);
                }

                return spot;
            }
        }
    }
}