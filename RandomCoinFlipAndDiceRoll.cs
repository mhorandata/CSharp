using System;

namespace Testing2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            // Coin flip
            string[] coinSides = { "Heads", "Tails" };
            int coinIndex = random.Next(coinSides.Length);
            string coinResult = coinSides[coinIndex];
            Console.WriteLine("Coin flip result: " + coinResult);

            // Dice roll
            int diceRoll = random.Next(1, 7); // Generate a random number between 1 and 6
            Console.WriteLine("Dice roll result: " + diceRoll);

            Console.ReadKey();
        }
    }
}
