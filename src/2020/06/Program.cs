using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	public static class Program
	{
		public static void Main()
		{
			var text = File.ReadAllText("input.txt");
			var groups = text.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

			var partOne = PartOne(groups);
			if (partOne > 0)
				Console.WriteLine($"Part 1: {partOne}");
			else
				Console.WriteLine("Failed to solve Part 1");

			var partTwo = PartTwo(groups);
			if (partTwo > 0)
				Console.WriteLine($"Part 2: {partTwo}");
			else
				Console.WriteLine("Failed to solve Part 2");
		}

		private static int PartOne(string[] groups)
		{
			var questions = new HashSet<char>();
			var groupsCount = 0;

			foreach(var group in groups)
			{
				var answers = group.Split("\n", StringSplitOptions.RemoveEmptyEntries);
				foreach(var answer in answers)
				{
					foreach(var question in answer)
						questions.Add(question);
				}
				groupsCount += questions.Count;
				questions.Clear();
			}

            return groupsCount;
		}

		private static int PartTwo(string[] groups)
		{
			var groupsCount = 0;

			foreach(var group in groups)
			{
				var answers = group.Split("\n", StringSplitOptions.RemoveEmptyEntries);
				var answer = answers.First();

				foreach(var question in answer)
				{
					if (answers.All(a => a.Contains(question)))
						groupsCount++;
				}
			}

			return groupsCount;
		}
	}
}
