using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Program
    {
        private const string PATTERN = @"(?<first>\d+)-(?<second>\d+) (?<char>[a-z]): (?<password>.*)";

        public static void Main()
        {
            var lines = File.ReadAllLines("input.txt");

            var partOne = PartOne(lines);
            if (partOne > 0)
            {
                Console.WriteLine($"Part 1: {partOne}");
            }
            else
            {
                Console.WriteLine("Failed to solve Part 1");
            }

            var partTwo = PartTwo(lines);
            if (partTwo > 0)
            {
                Console.WriteLine($"Part 2: {partTwo}");
            }
            else
            {
                Console.WriteLine("Failed to solve Part 2");
            }
        }

        private static int PartOne(string[] lines)
        {
            var valid = 0;
            foreach (var line in lines)
            {
                var match = Regex.Match(line, PATTERN);

                if (match is null)
                    continue;

                var min = int.Parse(match.Groups["first"].Value);
                var max = int.Parse(match.Groups["second"].Value);
                var character = char.Parse(match.Groups["char"].Value);
                var password = match.Groups["password"].Value;

                var instances = password.Count(c => c == character);
                if (instances >= min && instances <= max)
                {
                    valid++;
                }
            }
            return valid;
        }

        private static int PartTwo(string[] lines)
        {
            var valid = 0;
            foreach (var line in lines)
            {
                var match = Regex.Match(line, PATTERN);

                if (match is null)
                    continue;

                var firstIndex = int.Parse(match.Groups["first"].Value);
                var secondIndex = int.Parse(match.Groups["second"].Value);
                var character = char.Parse(match.Groups["char"].Value);
                var password = match.Groups["password"].Value;

				var firstValid = password[firstIndex - 1] == character;
				var secondValid = password[secondIndex - 1] == character;

                if (firstValid != secondValid)
                {
                    valid++;
                }
            }
            return valid;
        }
    }
}
