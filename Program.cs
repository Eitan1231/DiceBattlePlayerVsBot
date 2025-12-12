using System;
using System.Threading;

namespace Dice_game
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            Random random = new Random();
            int count = 1;
            int totalEarningsPlayer1 = 0;
            int totalEarningsBot = 0;
            do
            {
                Console.WriteLine("Welcome to the Dice Game!");
                Console.WriteLine("Enter your bet:");
                int bit_player1 = int.Parse(Console.ReadLine());
                int bit_bot = random.Next(1, 100);

                Console.WriteLine($"The player 1 bet: {bit_player1} $");
                Console.WriteLine($"Bot bet: {bit_bot} $");
                Console.WriteLine($"Your number of games: {count}");
                Console.WriteLine("You are Player 1, and you are playing against the bot.");
                Console.WriteLine("--------------------------");

                int totalPot = bit_player1 + bit_bot;
                int[] player1 = new int[8];
                int[] bot = new int[8];

                for (int i = 0; i < player1.Length; i++)
                {
                    Console.WriteLine($"Round {i + 1}:");
                    Thread.Sleep(1000);

                    player1[i] = RollDice();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Player 1 rolled: {player1[i]}");
                    Thread.Sleep(1000);

                    bot[i] = RollDice();
                    Console.ForegroundColor = ConsoleColor.Cyan; 
                    Console.WriteLine($"Bot rolled: {bot[i]}");
                    Thread.Sleep(1000);

                    Console.ResetColor();
                    Console.WriteLine("--------------------");
                }

                int sumPlayer1 = CalculateSum(player1);
                int sumBot = CalculateSum(bot);
                int avgPlayer1 = sumPlayer1 / player1.Length;
                int avgBot = sumBot / bot.Length;

                Console.WriteLine("--------------------");
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.WriteLine($"Total sum of Player 1: {sumPlayer1}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan; 
                Console.WriteLine($"Total sum of Bot: {sumBot}");
                Console.ResetColor();
                Console.WriteLine("----------------------------");
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.WriteLine($"Average of Player 1: {avgPlayer1}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan; 
                Console.WriteLine($"Average of Bot: {avgBot}");
                Console.ResetColor();
                Console.WriteLine("-------------------------------");

                if (sumPlayer1 > sumBot)
                {
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.WriteLine("Player 1 wins!");
                    Console.WriteLine($"Player 1 wins the pot: {totalPot} coins!");
                    totalEarningsPlayer1 += totalPot;
                }
                else if (sumBot > sumPlayer1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; 
                    Console.WriteLine("The bot wins!");
                    Console.WriteLine($"The bot wins the pot: {totalPot} coins!");
                    totalEarningsBot += totalPot;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; 
                    Console.WriteLine("It's a tie! The pot remains unclaimed.");
                    Console.ResetColor();
                }

                Console.WriteLine("---------------------------");

                string botChoice = (random.Next(0, 2) == 0) ? "Rematch" : "Cannot play right now";
                Console.WriteLine($"Bot says: \"{botChoice}\"");

                if (botChoice == "Cannot play right now")
                {
                    Console.WriteLine("The bot doesn't want to play again. Game Over!");
                    Console.WriteLine($"Total earnings of Player 1: {totalEarningsPlayer1} coins");
                    Console.WriteLine($"Total earnings of Bot: {totalEarningsBot} coins");
                    break;
                }

                Console.Write("Would you like to play again? (Y = Yes, N = No): ");
                userInput = Console.ReadLine().ToUpper();

                if (userInput == "Y")
                {
                    count++;
                    Console.Clear();
                }

            } while (userInput.ToUpper() == "Y");

            Console.WriteLine("Thanks for playing! Bye!");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"The number of games you played: {count}");
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine($"Final earnings of Player 1: {totalEarningsPlayer1} coins");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan; 
            Console.WriteLine($"Final earnings of Bot: {totalEarningsBot} coins");
            Console.ResetColor();
            Console.ReadKey();
        }

        static int RollDice()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        static int CalculateSum(int[] array)
        {
            int sum = 0;
            foreach (int number in array)
            {
                sum += number;
            }
            return sum;
        }
    }
}
