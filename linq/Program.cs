using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };
            IEnumerable<string> LFruits = from fruit in fruits
                                          where fruit.StartsWith("L")
                                          select fruit;

            foreach (string word in LFruits)
            {
                Console.WriteLine($"{word}");
            }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

            IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0);

            foreach (int number in fourSixMultiples)
            {
                Console.WriteLine($"{number}");
            }




            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
{
    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
    "Francisco", "Tre"
};

            IEnumerable<string> descend = names.OrderByDescending(n => n);

            foreach (string word in descend)
            {
                Console.WriteLine($"{word}");
            }

            // Build a collection of these numbers sorted in ascending order
            List<int> numbers2 = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

            IEnumerable<int> sortedNumbers = numbers2.OrderBy(n => n);

            foreach (int number in sortedNumbers)
            {
                Console.WriteLine($"{number}");
            }

            // Output how many numbers are in this list
            List<int> numbersCount = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

            Console.WriteLine(numbersCount.Count());

            // How much money have we made?
            List<double> purchases = new List<double>()
{
    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
};

            Console.WriteLine(purchases.Sum());


            // What is our most expensive product?
            List<double> prices = new List<double>()
{
    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
};
            double maxNumber = prices.Max();
            Console.WriteLine($"Largest number is {maxNumber}");


            List<int> wheresSquaredo = new List<int>()
{
    66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
};
            /*
                Store each number in the following List until a perfect square
                is detected.

                Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> noSquares = new List<int>();
            //List<int> linqSquares = new List<int>();
            for (int i = 0; i < wheresSquaredo.Count(); i++)
            {
                int testValue = wheresSquaredo[i];
                if (Math.Sqrt(testValue) % 1 == 0)
                {
                    break;
                }
                noSquares.Add(testValue);

            }


            foreach (int number in noSquares)
            {
                Console.WriteLine($"{number}");
            }
            //Same as above but using linq
            List<int> linqSquares = wheresSquaredo.TakeWhile(x => !(Math.Sqrt(x) % 1 == 0)).ToList();

            Console.WriteLine("Linq NoSquares");
            foreach (int number in linqSquares)
            {
                Console.WriteLine($"{number}");
            }

            Programs.Customers();
        }


    }
}
