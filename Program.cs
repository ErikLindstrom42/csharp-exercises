using System;

namespace Intro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}! I'm glad to meet you. What is your last name?");
            string lastName = Console.ReadLine();
            Console.WriteLine($"So {lastName}, {name}. Got it.");
        }
    }
}