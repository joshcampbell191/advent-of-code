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

		private static long PartOne(string[] lines)
		{
			return TreesEncountered(lines, 3, 1);
		}

		private static long PartTwo(string[] lines)
		{
			var slopeOne = TreesEncountered(lines, 1, 1);
			var slopeTwo = TreesEncountered(lines, 3, 1);
			var slopeThree = TreesEncountered(lines, 5, 1);
			var slopeFour = TreesEncountered(lines, 7, 1);
			var slopeFive = TreesEncountered(lines, 1, 2);

			return slopeOne * slopeTwo * slopeThree * slopeFour * slopeFive;
		}

		private static long TreesEncountered(string[] lines, int right, int down)
		{
			var treesEncountered = 0L;
			var index = 0;

			for (var i = 0; i < lines.Length; i += down)
			{
				var line = lines[i];
				var length = line.Length;
				index = index % length;

				if (line[index] == '#')
					treesEncountered++;

				index += right;
			}

			return treesEncountered;
		}
    }
}
