using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var numbers = lines.Select(s => int.Parse(s)).ToArray();

            var found = false;
            var first = 0;
            var second = 0;
            var third = 0;

            for(var i = 0; i < numbers.Length; i++) {
                first = numbers[i];

                for (var j = 0; j < numbers.Length; j++) {
                    if (i == j)
                        continue;

                    second = numbers[j];

                    for (var k = 0; k < numbers.Length; k++) {
                        if (i == k || j == k)
                            continue;

                        third = numbers[k];

                        var sum = first + second + third;
                        found = sum == 2020;

                        if (found)
                            break;
                    }

                    if (found)
                        break;
                }

                if (found)
                    break;
            }

            Console.WriteLine($"First: {first}");
            Console.WriteLine($"Second: {second}");
            Console.WriteLine($"Third: {third}");

            if (found) {
                var value = first * second * third;
                Console.WriteLine($"Value: {value}");
            } else {
                Console.WriteLine("Value not found");
            }
        }
    }
}
