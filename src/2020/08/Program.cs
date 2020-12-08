using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AdventOfCode
{
	public class Instruction
	{
		public string Operation;
		public int Value;
	}

	public static class Program
	{
		public static void Main()
		{
			var lines = File.ReadAllLines("input.txt");
			var instructions = ParseInstructions(lines);

			var partOne = PartOne(instructions);
			if (partOne > 0)
				Console.WriteLine($"Part 1: {partOne}");
			else
				Console.WriteLine("Failed to solve Part 1");

			var partTwo = PartTwo(instructions);
			if (partTwo > 0)
				Console.WriteLine($"Part 2: {partTwo}");
			else
				Console.WriteLine("Failed to solve Part 2");
		}

		private static int PartOne(Instruction[] instructions)
		{
			var accumulator = 0;
			var index = 0;
			var history = new Queue<Instruction>();

			while (true)
			{
				var instruction = instructions[index];

				if (history.Contains(instruction))
					break;

				history.Enqueue(instruction);

				switch(instruction.Operation)
				{
					case "acc":
						accumulator += instruction.Value;
						break;
					case "jmp":
						index += instruction.Value;
						continue;
					case "nop":
						break;
				}

				index++;
			}

            return accumulator;
		}

		private static int PartTwo(Instruction[] instructions)
		{
			return 0;
		}

		private static Instruction[] ParseInstructions(string[] lines)
		{
			var pattern = @"(?<operation>.*) (?<value>[+-]\d+)";
			var instructions = new List<Instruction>();

			foreach(var line in lines)
			{
				if (!Regex.IsMatch(line, pattern))
					continue;

				var match = Regex.Match(line, pattern);
				var instruction = new Instruction {
					Operation = match.Groups["operation"].Value,
					Value = int.Parse(match.Groups["value"].Value)
				};
				instructions.Add(instruction);
			}

			return instructions.ToArray();
		}
	}
}
