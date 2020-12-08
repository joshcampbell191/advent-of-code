using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
	public static class Program
	{
		public static Dictionary<string, List<string>> Bags;
		public static void Main()
		{
			var lines = File.ReadAllLines("input.txt");
			Bags = ParseBags(lines);

			var partOne = PartOne();
			if (partOne > 0)
				Console.WriteLine($"Part 1: {partOne}");
			else
				Console.WriteLine("Failed to solve Part 1");

			var partTwo = PartTwo();
			if (partTwo > 0)
				Console.WriteLine($"Part 2: {partTwo}");
			else
				Console.WriteLine("Failed to solve Part 2");
		}

		private static int PartOne()
		{
			var count = 0;

			foreach (var bag in Bags)
			{
				if (ContainsBag("shiny gold", bag.Value))
					count++;
			}

            return count;
		}

		private static int PartTwo()
		{
			return 0;
		}

		private static Dictionary<string, List<string>> ParseBags(string[] lines)
		{
			var bags = new Dictionary<string, List<string>>();
			var bagPattern = @"(?<color>.*) bags";
			var contentPattern = @"(?<amount>\d+) (?<color>[\w\s]+) bags?[,\.]";

			return lines
				.Select(x => x.Split("contain", StringSplitOptions.RemoveEmptyEntries))
				.Where(x => x.Length == 2)
				.Select(x => new
				{
					Bag = Regex.Match(x[0], bagPattern).Groups["color"].Value,
					Contents = Regex.Matches(x[1], contentPattern).Select(m => m.Groups["color"].Value).ToList()
				})
				.ToDictionary(key => key.Bag, value => value.Contents);
		}

		private static bool ContainsBag(string content, List<string> bags)
		{
			// Does the bag contain content?
			if (bags.Contains(content))
				return true;

			// Does one of the other bags contain the content?
			foreach (var bag in bags) {
				if (ContainsBag(content, Bags[bag]))
					return true;
			}

			// The bag doesn't contain the content
			return false;
		}
	}
}
