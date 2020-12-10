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

		private static long PartOne(string[] lines)
		{
			var preambleLength = 25;
            var numbers = lines.Select(l => long.Parse(l)).ToArray();

			for (var i = preambleLength; i < numbers.Length; i++)
			{
				var number = numbers[i];
				var preamble = numbers.Skip(i - preambleLength).Take(preambleLength).ToArray();
				var valid = false;

				for (var j = 0; j < preambleLength; j++) {
					for (var k = j + 1; k < preambleLength; k++) {
						var remainder = number - preamble[j];
						if (remainder == preamble[k]) {
							valid = true;
							break;
						}
					}

					if (valid)
						break;
				}

				if (!valid)
					return numbers[i];
			}

			return 0;
		}

		private static long PartTwo(string[] lines)
		{
			var preambleLength = 25;
            var numbers = lines.Select(l => long.Parse(l)).ToArray();

			for (var i = preambleLength; i < numbers.Length; i++)
			{
				var number = numbers[i];
				var preamble = numbers.Skip(i - preambleLength).Take(preambleLength).ToArray();
				var valid = false;

				for (var j = 0; j < preambleLength; j++) {
					for (var k = j + 1; k < preambleLength; k++) {
						var remainder = number - preamble[j];
						if (remainder == preamble[k]) {
							valid = true;
							break;
						}
					}

					if (valid)
						break;
				}

				if (!valid) {
					var invalid = numbers[i];
					// Start going backwards from i and add the previous numbers
					for (var end = i - 1; end >= 0; end--)
					{
						var sum = 0L;
						for (var start = end - 1; sum < invalid; start--)
						{
							sum += numbers[start];
							// If the sum is equal to our invalid numbers, extract the numbers from the range
							if (sum == invalid)
							{
								var range = numbers.Skip(start).Take(end - start);
								var max = range.Max();
								var min = range.Min();
								return max + min;
							}
						}
					}

					// Unable to find the solution
					return 0;
				}					
			}

			return 0;
		}
	}
}
