using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
	public static class Program
	{
		public static void Main()
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
			var adapters = lines.Select(int.Parse).OrderBy(n => n).ToArray();
			int previous = 0, countOne = 0, countThree = 0;

			foreach(var adapter in adapters)
			{
				var difference = adapter - previous;
				switch(difference)
				{
					case 1:
						countOne++;
						break;
					case 3:
						countThree++;
						break;
				}
				previous = adapter;
			}

			// We add one for the device itself
			countThree++;

            return countOne * countThree;
		}

		private static long PartTwo(string[] lines)
		{
			var adapters = lines.Select(int.Parse).OrderBy(n => n).ToArray();
			var max = adapters.Max();
			return CountCombinations(0, max, adapters);
		}

		private static long CountCombinations(int previous, int max, int[] adapters)
		{
			var count = 0L;

			if (previous == max)
				return 1;

			var validAdapters = adapters.Where(a => a > previous && a - previous <= 3).ToArray();
			foreach(var adapter in validAdapters) {
				count += CountCombinations(adapter, max, adapters);
			}

			return count;
		}
	}
}
