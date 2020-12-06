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
			return lines.Max(l => GetSeatId(l));
		}

		private static int PartTwo(string[] lines)
		{
			var seatIds = lines.Select(l => GetSeatId(l)).OrderBy(s => s).ToArray();
			if (seatIds.Length == 0)
				return 0;
				
			var value = 0;
			for(var i = 0; i < seatIds.Length - 1; i++)
			{
				value = seatIds[i];
				if (seatIds[i + 1] != value + 1)
					break;
			}

			return value + 1;
		}

		private static int GetSeatId(string boardingPass)
		{
			int front = 0, back = 127, left = 0, right = 7;

			foreach (var c in boardingPass)
			{
				switch (c)
				{
					case 'F':
						back -= (back - front) / 2 + 1;
						break;
					case 'B':
						front += (back - front) / 2 + 1;
						break;
					case 'L':
						right -= (right - left) / 2 + 1;
						break;
					case 'R':
						left += (right - left) / 2 + 1;
						break;
				}
			}

			var row = front;
			var column = left;

			var seatId = row * 8 + column;

			return seatId;
		}
	}
}
