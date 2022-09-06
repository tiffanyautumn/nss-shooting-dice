using System;
namespace ShootingDice
{
    // TODO: Complete this class

    // A player the prompts the user to enter a number for a roll
    public class HumanPlayer : Player
    {
        public override int Roll()
        {
            {
                int ret = 0;
                Console.Write("Enter your roll: ");
                while (int.TryParse(Console.ReadLine(), out ret) == false) { Console.WriteLine("\r Invalid input, try again!"); }
                return ret;
            }
        }
    }
}