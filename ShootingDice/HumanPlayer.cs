using System;
namespace ShootingDice
{
    // TODO: Complete this class

    // A player the prompts the user to enter a number for a roll
    public class HumanPlayer : Player
    {
        public override int Roll()
        {
            // Prompts the user to choose their dice roll
            Console.WriteLine("Please enter your desired roll");
            int result = Int32.Parse(Console.ReadLine());
            return result;
        }
    }
}