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
			var numbers = lines.Select(s => int.Parse(s)).ToArray();

			var partOne = PartOne(numbers);
			if (partOne > 0)
			{
				Console.WriteLine($"Part 1: {partOne}");
			}
			else
			{
				Console.WriteLine("Failed to solve Part 1");
			}

			var partTwo = PartTwo(numbers);
			if (partTwo > 0)
			{
				Console.WriteLine($"Part 2: {partTwo}");
			}
			else
			{
				Console.WriteLine("Failed to solve Part 2");
			}
		}

		private static int PartOne(int[] numbers)
		{
			int first, second;

			for (var i = 0; i < numbers.Length; i++)
			{
				first = numbers[i];

				for (var j = 0; j < numbers.Length; j++)
				{
					if (i == j)
						continue;

					second = numbers[j];

					var sum = first + second;
					if (sum == 2020)
						return first * second;
				}
			}

			return 0;
		}

		private static int PartTwo(int[] numbers)
		{
			int first, second, third;

			for (var i = 0; i < numbers.Length; i++)
			{
				first = numbers[i];

				for (var j = 0; j < numbers.Length; j++)
				{
					if (i == j)
						continue;

					second = numbers[j];

					for (var k = 0; k < numbers.Length; k++)
					{
						if (i == k || j == k)
							continue;

						third = numbers[k];

						var sum = first + second + third;
						if (sum == 2020)
							return first * second * third;
					}
				}
			}

			return 0;
		}
	}
}
