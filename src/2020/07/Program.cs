using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
	public static class Program
	{
		public static Dictionary<string, Dictionary<string, int>> Bags;
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
			return CountBags(Bags["shiny gold"]);
		}

		private static Dictionary<string, Dictionary<string, int>> ParseBags(string[] lines)
		{
			var bagPattern = @"(?<color>.*) bags";
			var contentPattern = @"(?<amount>\d+) (?<color>[\w\s]+) bags?[,\.]";

			return lines
				.Select(x => x.Split("contain", StringSplitOptions.RemoveEmptyEntries))
				.Where(x => x.Length == 2)
				.Select(x => new
				{
					Bag = Regex.Match(x[0], bagPattern).Groups["color"].Value,
					Contents = Regex.Matches(x[1], contentPattern).ToDictionary(key => key.Groups["color"].Value, value => int.Parse(value.Groups["amount"].Value))
				})
				.ToDictionary(key => key.Bag, value => value.Contents);
		}

		private static bool ContainsBag(string content, Dictionary<string, int> bags)
		{
			// Does the bag contain content?
			if (bags.ContainsKey(content))
				return true;

			// Does one of the other bags contain the content?
			foreach (var bag in bags.Keys) {
				if (ContainsBag(content, Bags[bag]))
					return true;
			}

			// The bag doesn't contain the content
			return false;
		}

		private static int CountBags(Dictionary<string, int> bags)
		{
			var amount = 0;
			foreach(var bag in bags) {
				amount += bag.Value + bag.Value * CountBags(Bags[bag.Key]);
			}
			return amount;
		}
	}
}
