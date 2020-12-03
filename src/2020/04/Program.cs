using System;
using System.IO;

namespace AdventOfCode
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var partOne = PartOne(lines);
            if (partOne > 0)
                Console.WriteLine($"Part 1: {partOne}");
            else
                Console.WriteLine("Failed to solve Part 1");

            var partTwo = PartTwo(lines);
            if (partTwo > 0)
                Console.WriteLine($"Part 2: {partTwo}");
            else
                Console.WriteLine("Failed to solve Part 2");
        }

		private static int PartOne(string[] lines)
		{
			return 0;
		}

		private static int PartTwo(string[] lines)
		{
			return 0;
		}
    }
}
