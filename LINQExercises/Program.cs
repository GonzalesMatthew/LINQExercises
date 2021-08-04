using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 2, 9, 3, 3, 800, 38, 15, 800, 19, 15, 5, 38, 282 };
            Console.WriteLine($"Original collections { String.Join(',', numbers)}");

            // Sorting operations --
            // OrderBy, OrderByDescending, and Reverse

            // must use System.Linq namespace
            var orderedNumbers = numbers.OrderBy(num => num);
            Console.WriteLine($"Ordered numbers { String.Join(',', orderedNumbers)}");

            // desc order
            var orderedbyDescNumbers = numbers.OrderByDescending(num => num);
            Console.WriteLine($"Descending order { String.Join(',', orderedbyDescNumbers)}");
            
                
            //  note that .Reverse() does not have a return type, so you can't store it in a variable
            numbers.Reverse();
            Console.WriteLine($"Reversed numbers { String.Join(',', numbers)}");


            // Aggregate Methods ---
            // Max, Sum, Min, Average, Count

            // max
            var maxNumber = numbers.Max();
            Console.WriteLine($"Max value using .Max: {maxNumber}");

            // sum
            var sumOfNumbers = numbers.Sum();
            Console.WriteLine($"Sum of collection using .Sum: {sumOfNumbers}");

            // min
            var minNumber = numbers.Min();
            Console.WriteLine($"Smallest number with .Min: {minNumber}");

            // average
            var avgNumber = numbers.Average();
            Console.WriteLine($"Average of collection using .Average: {avgNumber}");

            // count
            var countOfNumbers = numbers.Count();
            Console.WriteLine($"Use .Count to count all elements: {countOfNumbers}");

            //`Where` is like array.filter, returns a new collection
            // filtering data
            var biggerNumbers = numbers.Where(x => x > 20);
            Console.WriteLine($"Applying .Where to filter for > 20:  { String.Join(',', biggerNumbers)}");


            //`Select` is like Array.map, returns a new collection of IEnumerable<T>
            // Transforming data
            var bigNumbersAgain = numbers.Select(num => num + 12);
            Console.WriteLine($"Applying .Select to add 12 to each: { String.Join(',', bigNumbersAgain)}");

            // grab first number in collection
            var firstNumber = numbers.First();
            Console.WriteLine($"Use .First to get the first element in collection: {firstNumber}");

            // grab last number in collection
            var lastNumber = numbers.Last();

            //Find First item matching a .Where
            var firstMatchingNumber = numbers.Where(num => num > 9).First();
            //another way to do the same: use a predicate inside of .First()
            var firstMatchingNumberAgain = numbers.First(num => num > 9);


            // Quantifier Operations  --
            // returns a boolean -- so used in conjunction with other operations
            // All, Any, Contains:

            //All
            var allNumbers = numbers.All(c => c % 2 == 0); // tests if all numbers are even -> false
            Console.WriteLine(allNumbers);

            //Any
            var anyNumbers = numbers.Any(c => c < 5); // tests for any number less than five -> true
            Console.WriteLine(anyNumbers);

            //Contains
            var containsNumbers = numbers.Contains(2) || numbers.Contains(8);  // tests if 2 or 8 is contained in collection -> true
            Console.WriteLine(containsNumbers);


            // Make another list for next example:
            var badNumbers = new List<int>() { 19, 15, 3, 9 };


            // exclude elements with .Except
            var onlyGoodNumbers = numbers.Except(badNumbers);
            Console.WriteLine($"Use .Except to exclude elements: {onlyGoodNumbers}");

            // grab distinct values
            var uniqueNumbers = numbers.Distinct();
            Console.WriteLine($"Use .Distinct to keep unique elements: {uniqueNumbers}");

            // Take, Concat, Skip
            //Take specific number of elements from the beginning
            // Concat join with something else
            // Skip skips specific number of elements from the beginning
            var firstThreeNumbersAndTheSixth = numbers.Take(3).Concat(numbers.Skip(5));
            Console.WriteLine($"firstThreeNumbersAndThenSixth: {firstThreeNumbersAndTheSixth}");

            var animals = new List<Animal> {
                new Animal {
                    Type = "Pikachu",
                    HeightInInches = 15,
                    WeightInPounds = 15,
                },
                new Animal {
                    Type = "Charizard",
                    HeightInInches = 88,
                    WeightInPounds = 260,
                },
                new Animal {
                    Type = "Bulbasaur",
                    HeightInInches = 18,
                    WeightInPounds = 20,
                },
                new Animal {
                    Type = "Squirtle",
                    HeightInInches = 15,
                    WeightInPounds = 19,
                },
                new Animal {
                    Type = "Clafairy",
                    HeightInInches = 15,
                    WeightInPounds = 19,
                },
            };
            //find animals starting with 'c'
            var animalsThatStartWithC = animals.Where(animal => animal.Type.ToLower().StartsWith("c"));
            foreach (var animal in animalsThatStartWithC)
            {
                Console.WriteLine(animal.Type);
            }
            //group a collection by a given key (based on a function)
            var groupAnimals = animals.GroupBy(animal => animal.Type.First());
            foreach (var animalGroup in groupAnimals)
            {
                Console.WriteLine($"Animals that start with {animalGroup.Key }");

                foreach (var animal in animalGroup)
                {
                    Console.WriteLine(animal.Type);
                }
            }
        }
    }
}
