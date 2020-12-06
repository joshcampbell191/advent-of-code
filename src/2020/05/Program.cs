using System;
using System.IO;

namespace AdventOfCode
{
	public static class Program
	{
		public static void Main()
		{
			var lines = File.ReadAllLines("input.txt");
			var numbers = lines.Select(s => int.Parse(s)).ToArray();

			var partOne = PartOne(numbers);
			if (partOne > 0)
				Console.WriteLine($"Part 1: {partOne}");
			else
				Console.WriteLine("Failed to solve Part 1");

			var partTwo = PartTwo(numbers);
			if (partTwo > 0)
				Console.WriteLine($"Part 2: {partTwo}");
			else
				Console.WriteLine("Failed to solve Part 2");
		}

		private static int PartOne(int[] numbers)
		{
            return 0;
		}

		private static int PartTwo(int[] numbers)
		{
			return 0;
		}
	}
}
