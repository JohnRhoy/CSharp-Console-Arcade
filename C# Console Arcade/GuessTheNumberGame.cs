using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp_Console_Arcade
{
    public static class GuessTheNumberGame
    {
        public static void StartScreenGuessTheNumber()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
@"&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
&&&                                                                                                                 &&&
&&&             $$$$$$\                                                $$$$$$$$\ $$\                                &&&
&&&            $$  __$$\                                               \__$$  __|$$ |                               &&&
&&&            $$ /  \__|$$\   $$\  $$$$$$\   $$$$$$$\  $$$$$$$\          $$ |   $$$$$$$\   $$$$$$\                 &&&
&&&            $$ |$$$$\ $$ |  $$ |$$  __$$\ $$  _____|$$  _____|         $$ |   $$  __$$\ $$  __$$\                &&&
&&&            $$ |\_$$ |$$ |  $$ |$$$$$$$$ |\$$$$$$\  \$$$$$$\           $$ |   $$ |  $$ |$$$$$$$$ |               &&&
&&&            $$ |  $$ |$$ |  $$ |$$   ____| \____$$\  \____$$\          $$ |   $$ |  $$ |$$   ____|               &&&
&&&            \$$$$$$  |\$$$$$$  |\$$$$$$$\ $$$$$$$  |$$$$$$$  |         $$ |   $$ |  $$ |\$$$$$$$\                &&&
&&&             \______/  \______/  \_______|\_______/ \_______/          \__|   \__|  \__| \_______|               &&&
&&&                                                                                                                 &&&
&&&                          $$\   $$\                         $$\                                                  &&&
&&&                          $$$\  $$ |                        $$ |                                                 &&&
&&&                          $$$$\ $$ |$$\   $$\ $$$$$$\$$$$\  $$$$$$$\   $$$$$$\   $$$$$$\                         &&&
&&&                          $$ $$\$$ |$$ |  $$ |$$  _$$  _$$\ $$  __$$\ $$  __$$\ $$  __$$\                        &&&
&&&                          $$ \$$$$ |$$ |  $$ |$$ / $$ / $$ |$$ |  $$ |$$$$$$$$ |$$ |  \__|                       &&&
&&&                          $$ |\$$$ |$$ |  $$ |$$ | $$ | $$ |$$ |  $$ |$$   ____|$$ |                             &&&
&&&                          $$ |\$$$ |$$ |  $$ |$$ | $$ | $$ |$$ |  $$ |$$   ____|$$ |                             &&&
&&&                          $$ | \$$ |\$$$$$$  |$$ | $$ | $$ |$$$$$$$  |\$$$$$$$\ $$ |                             &&&
&&&                          \__|  \__| \______/ \__| \__| \__|\_______/  \_______|\__|                             &&&
&&&                                                                                                                 &&&
&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                         Press 'S' to start the game or 'M' to return to the main lobby...                           ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
");
            Console.CursorVisible = false;

            char choice = char.ToUpper(Console.ReadKey(true).KeyChar);

            if (choice == 'S')
            {
                GuessTheNumber();
            }
            else if (choice == 'M')
            {
                Program.MainLobby();
            }
            else
            {
                CommonUtilities.RainbowFlickerMessage("Press 'S' to start the game or 'M' to return to the main lobby...", 26, 26);
                StartScreenGuessTheNumber();
            }
        }
        public static void GuessTheNumberText()
        {
            Console.Clear();
            Console.WriteLine(@"
=======================================================================================================================
=======================================================================================================================
                          ░█▀▀░█░█░█▀▀░█▀▀░█▀▀░░░▀█▀░█░█░█▀▀░░░█▀█░█░█░█▄█░█▀▄░█▀▀░█▀▄
                          ░█░█░█░█░█▀▀░▀▀█░▀▀█░░░░█░░█▀█░█▀▀░░░█░█░█░█░█░█░█▀▄░█▀▀░█▀▄
                          ░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░░░░▀░░▀░▀░▀▀▀░░░▀░▀░▀▀▀░▀░▀░▀▀░░▀▀▀░▀░▀
=======================================================================================================================
=======================================================================================================================
");
        }
        public static void GuessTheNumber()
        {
            GuessTheNumberText();
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 45), 8);
            foreach (char c in "In Guess the Number, the computer will randomly choose a number between a specified range.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 32), 9);
            foreach (char c in "Your task is to guess the correct number within the given range.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 50), 10);
            foreach (char c in "After each guess, the computer will provide feedback on whether the actual number is higher or lower.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 33), 11);
            foreach (char c in "You have a limited number of attempts to guess the correct number.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.SetCursorPosition(0, 23);

            Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                                              Press any key to continue...                                           ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
");
            Console.SetCursorPosition(75, 15);
            Console.ReadKey(true);

            char difficultyChoice;
            int maxNumber = 0;
            int maxAttempts = 0;
            int attempts = 0;

            difficultyChoice = char.ToUpper(Console.ReadKey(true).KeyChar);

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                GuessTheNumberText();

                Console.WriteLine("Choose a difficulty level:");
                Console.WriteLine("1. Very Easy ~ 10 attempts for range 1-50");
                Console.WriteLine("2. Easy ~ 10 attempts for range 1-100");
                Console.WriteLine("3. Intermediate ~ 8 attempts for range 1-100");
                Console.WriteLine("4. Challenging ~ 8 attempts for range 1-150 ");
                Console.WriteLine("5. Advance ~ 8 attempts for range 1-200");
                Console.WriteLine("6. Expert ~ 10 attempts for range 1-300");
                Console.WriteLine("7. Master ~ 8 attempts for range 1-300");
                Console.WriteLine("8. Impossible ~ 9 attempts for range 1-1000");

                difficultyChoice = char.ToUpper(Console.ReadKey(true).KeyChar);

                switch (difficultyChoice)
                {
                    case '1':
                        maxNumber = 50;
                        maxAttempts = 10;
                        break;
                    case '2':
                        maxNumber = 100;
                        maxAttempts = 10;
                        break;
                    case '3':
                        maxNumber = 100;
                        maxAttempts = 8;
                        break;
                    case '4':
                        maxNumber = 150;
                        maxAttempts = 8;
                        break;
                    case '5':
                        maxNumber = 200;
                        maxAttempts = 8;
                        break;
                    case '6':
                        maxNumber = 300;
                        maxAttempts = 10;
                        break;
                    case '7':
                        maxNumber = 300;
                        maxAttempts = 8;
                        break;
                    case '8':
                        maxNumber = 1000;
                        maxAttempts = 9;
                        break;
                    default:
                        CommonUtilities.RainbowFlickerMessage("Invalid Difficulty Level", ((Console.WindowWidth / 2) - 11), 8);
                        Console.Clear();
                        break;
                }

            } while (!char.IsDigit(difficultyChoice) || difficultyChoice < '1' || difficultyChoice > '8');

            Random random = new Random();
            int targetNumber = random.Next(1, maxNumber + 1);

            Console.CursorVisible = true;
            GuessTheNumberText();
            Console.WriteLine($"Game Difficulty: {difficultyChoice}");
            Console.WriteLine($"Guess the random number between 1 and {maxNumber}");

            while (attempts < maxAttempts)
            {
                Console.Write("Enter your guess: ");
                int guessPromptLeft = Console.CursorLeft;
                int guessPromptTop = Console.CursorTop;

                if (int.TryParse(Console.ReadLine(), out int userGuess))
                {
                    attempts++;

                    if (userGuess == targetNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Congratulations! You guessed the correct number {targetNumber} in {attempts} attempts.");
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(guessPromptLeft, guessPromptTop);
                        Console.WriteLine($"Incorrect! {userGuess} is {(userGuess < targetNumber ? "Too low" : "Too high")}. Attempts remaining: {maxAttempts - attempts}");
                    }
                }
                else
                {
                    Console.SetCursorPosition(guessPromptLeft, guessPromptTop);
                    CommonUtilities.RainbowFlickerMessage("Please enter a valid number", guessPromptLeft, guessPromptTop);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }

            if (attempts == maxAttempts)
            {
                Console.WriteLine($"Sorry, you couldn't guess the number in {maxAttempts} attempts. The correct number was {targetNumber}.");
                Thread.Sleep(3000);
            }
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 23);
            Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                                  Press any key to return to the main lobby...                                       ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ReadKey(true);
            Program.MainLobby();
        }
    }
}
