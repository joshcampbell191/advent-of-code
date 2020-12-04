using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode
{
	public class Passport
	{
		public int? BirthYear { get; set; }
		public int? IssueYear { get; set; }
		public int? ExpirationYear { get; set; }
		public string Height { get; set; }
		public string HairColor { get; set; }
		public string EyeColor { get; set; }
		public string PassportId { get; set; }
		public string CountryId { get; set; }

		public bool IsValid()
		{
			return BirthYear.HasValue &&
				IssueYear.HasValue &&
				ExpirationYear.HasValue &&
				!string.IsNullOrEmpty(Height) &&
				!string.IsNullOrEmpty(HairColor) &&
				!string.IsNullOrEmpty(EyeColor) &&
				!string.IsNullOrEmpty(PassportId);
		}
	}

    public static class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
			var passports = ParsePassports(lines);

            var partOne = PartOne(passports);
            if (partOne > 0)
                Console.WriteLine($"Part 1: {partOne}");
            else
                Console.WriteLine("Failed to solve Part 1");

            var partTwo = PartTwo(passports);
            if (partTwo > 0)
                Console.WriteLine($"Part 2: {partTwo}");
            else
                Console.WriteLine("Failed to solve Part 2");
        }

		private static int PartOne(Passport[] passports)
		{
			return passports.Count(p => p.IsValid());
		}

		private static int PartTwo(Passport[] passports)
		{
			return 0;
		}

		private static Passport[] ParsePassports(string[] lines)
		{
			var passports = new List<Passport>();

			int? birthYear = null, issueYear = null, expirationYear = null;
			string height = "", hairColor = "", eyeColor = "", passportId = "", countryId = "";

			foreach(var line in lines)
			{
				if (string.IsNullOrEmpty(line))
				{
					passports.Add(new Passport {
						BirthYear = birthYear,
						IssueYear = issueYear,
						ExpirationYear = expirationYear,
						Height = height,
						HairColor = hairColor,
						EyeColor = eyeColor,
						PassportId = passportId,
						CountryId = countryId
					});

					birthYear = issueYear = expirationYear = null;
					height = hairColor = eyeColor = passportId = countryId = "";

					continue;
				}

				var properties = line.Split(" ");
				foreach (var property in properties)
				{
					var field = property.Split(":");
					if (field.Length != 2)
						continue;

					var name = field[0];
					var value = field[1];

					switch(name)
					{
						case "byr":
							birthYear = int.Parse(value);
							break;
						case "iyr":
							issueYear = int.Parse(value);
							break;
						case "eyr":
							expirationYear = int.Parse(value);
							break;
						case "hgt":
							height = value;
							break;
						case "hcl":
							hairColor = value;
							break;
						case "ecl":
							eyeColor = value;
							break;
						case "pid":
							passportId = value;
							break;
						case "cid":
							countryId = value;
							break;
					}
				}
			}

			return passports.ToArray();
		}
    }
}
