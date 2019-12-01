using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    public static class Program
    {
        static void Main(string[] args)
        {
            const string inputPath = @"./Resources/Input.txt";
            var input = ReadInput(inputPath).ToList();
            GetFuelRequiredByModules(input);
            GetTotalFuelRequired(input);
        }

        private static IEnumerable<int> ReadInput(string path)
        {
            return File.ReadAllLines(path).Select(int.Parse);
        }

        private static void GetFuelRequiredByModules(IEnumerable<int> masses)
        {
            var fuel = masses.Select(x => (int) Math.Floor((decimal)(x / 3)) - 2).Sum();
            Console.WriteLine($"Fuel required for modules: {fuel}");
        }

        private static void GetTotalFuelRequired(IEnumerable<int> masses)
        {
            var totalFuel = 0;
            foreach (var mass in masses)
            {
                decimal tempMass = mass;
                while (Math.Floor(tempMass / 3) - 2 > 0)
                {
                    tempMass = Math.Floor(tempMass / 3) - 2;
                    totalFuel += (int)tempMass;
                }
            }
            Console.WriteLine($"Total Fuel required for mass {totalFuel}");
        }
    }
}