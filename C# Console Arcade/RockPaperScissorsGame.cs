using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console_Arcade
{
    public static class RockPaperScissorsGame
    {
        public static void StartScreenRockPaperScissors()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
@"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@                                                                                                                   @@
@@ ________  ________  ________  ___  __                  ________  ________  ________  _______   ________           @@
@@|\   __  \|\   __  \|\   ____\|\  \|\  \               |\   __  \|\   __  \|\   __  \|\  ___ \ |\   __  \          @@
@@\ \  \|\  \ \  \|\  \ \  \___|\ \  \/  /|_             \ \  \|\  \ \  \|\  \ \  \|\  \ \   __/|\ \  \|\  \         @@
@@ \ \   _  _\ \  \\\  \ \  \    \ \   ___  \  ___        \ \   ____\ \   __  \ \   ____\ \  \_|/_\ \   _  _\  ___   @@
@@  \ \  \\  \\ \  \\\  \ \  \____\ \  \\ \  \|\  \        \ \  \___|\ \  \ \  \ \  \___|\ \  \_|\ \ \  \\  \||\  \  @@
@@   \ \__\\ _\\ \_______\ \_______\ \__\\ \__\ \  \        \ \__\    \ \__\ \__\ \__\    \ \_______\ \__\\ _\\ \  \ @@
@@    \|__|\|__|\|_______|\|_______|\|__| \|__|\/  /|        \|__|     \|__|\|__|\|__|     \|_______|\|__|\|__|\/  /|@@
@@                                           |\___/ /                                                        |\___/ /@@
@@                                           \|___|/                                                         \|___|/ @@
@@                                                                                                                   @@
@@                 ________  ________  ___  ________   ________  ________  ________  ________                        @@
@@                |\   ____\|\   ____\|\  \|\   ____\ |\   ____\|\   __  \|\   __  \|\   ____\                       @@
@@                \ \  \___|\ \  \___|\ \  \ \  \___|_\ \  \___|\ \  \|\  \ \  \|\  \ \  \___|_                      @@
@@                 \ \_____  \ \  \    \ \  \ \_____  \\ \_____  \ \  \\\  \ \   _  _\ \_____  \                     @@
@@                  \|____|\  \ \  \____\ \  \|____|\  \\|____|\  \ \  \\\  \ \  \\  \\|____|\  \                    @@
@@                    ____\_\  \ \_______\ \__\____\_\  \ ____\_\  \ \_______\ \__\\ _\ ____\_\  \                   @@
@@                   |\_________\|_______|\|__|\_________\\_________\|_______|\|__|\|__|\_________\                  @@
@@                   \|_________|             \|_________\|_________|                  \|_________|                  @@
@@                                                                                                                   @@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
");
            Console.SetCursorPosition(0, 24);
            Console.CursorVisible = false;
            Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                         Press 'S' to start the game or 'M' to return to the main lobby...                           ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
");

            char choice = char.ToUpper(Console.ReadKey(true).KeyChar);

            if (choice == 'S')
            {
                RockPaperScissors();
            }
            else if (choice == 'M')
            {
                Program.MainLobby();
            }
            else
            {
                CommonUtilities.RainbowFlickerMessage("Press 'S' to start the game or 'M' to return to the main lobby...", 26, 26);
                StartScreenRockPaperScissors();
            }
        }
        public static void RockPaperScissorsText()
        {
            Console.Clear();
            Console.WriteLine(
@"███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
=======================================================================================================================
                   ░█▀▄░█▀█░█▀▀░█░█░░░░░█▀█░█▀█░█▀█░█▀▀░█▀▄░░░░░█▀▀░█▀▀░▀█▀░█▀▀░█▀▀░█▀█░█▀▄░█▀▀
                   ░█▀▄░█░█░█░░░█▀▄░░░░░█▀▀░█▀█░█▀▀░█▀▀░█▀▄░░░░░▀▀█░█░░░░█░░▀▀█░▀▀█░█░█░█▀▄░▀▀█
                   ░▀░▀░▀▀▀░▀▀▀░▀░▀░░░░░▀░░░▀░▀░▀░░░▀▀▀░▀░▀░░░░░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀░▀░▀▀▀
=======================================================================================================================
███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
");
        }
        public static void RockPaperScissors()
        {
            RockPaperScissorsText();
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 45), 8);
            foreach (char c in "In Rock, Paper, Scissors, you will play against the computer in a classic hand game.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 28), 9);
            foreach (char c in "Your task is to choose either Rock, Paper, or Scissors.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 50), 10);
            foreach (char c in "The computer will also make a random choice, and the winner is determined by the following rules:")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 33), 11);
            foreach (char c in "Rock crushes Scissors, Scissors cuts Paper, and Paper covers Rock.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 27), 12);
            foreach (char c in "The game will continue for a specified number of rounds.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.SetCursorPosition(0, 24);

            Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                                              Press any key to continue...                                           ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
");
            Console.ReadKey(true);

            while (true)
            {
                RockPaperScissorsText();

                Console.CursorVisible = true;

                Console.Write("Enter the number of rounds you want to play (up to 20): ");

                if (int.TryParse(Console.ReadLine(), out int totalRounds) && totalRounds > 0 && totalRounds <= 20)
                {
                    PlayRockPaperScissors(totalRounds);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer up to 20.");
                }
            }

            static void PlayRockPaperScissors(int totalRounds)
            {
                int userWins = 0;
                int computerWins = 0;

                for (int round = 1; round <= totalRounds; round++)
                {
                    RockPaperScissorsText();

                    Console.SetCursorPosition(0, 7);
                    Console.Write(RoundAsciiArt.GetAsciiArtForRound(round));

                    Console.SetCursorPosition(10, 12);
                    Console.WriteLine($"User: {userWins}");

                    Console.SetCursorPosition(100, 12);
                    Console.WriteLine($"Computer: {computerWins}");

                    Console.SetCursorPosition((Console.WindowWidth / 2) - 22, 13);
                    Console.Write("Choose (R)ock, (P)aper, or (S)cissors: ");
                    string userChoice = GetUserChoice();

                    string[] choices = { "R", "P", "S" };
                    Random random = new Random();
                    string computerChoice = choices[random.Next(choices.Length)];

                    Console.WriteLine($@"
***********************************************************************************************************************
Your choice: {userChoice}                                                                         Computer's choice: {computerChoice}
***********************************************************************************************************************");

                    string result = DetermineWinner(userChoice, computerChoice);

                    if (result == "You win!")
                    {
                        userWins++;
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 4, 18);
                    }
                    else if (result == "Computer wins!")
                    {
                        computerWins++;
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 7, 18);
                    }
                    else if (result == "It's a tie!")
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 5, 18);
                    }
                    Console.WriteLine(result);

                    Console.SetCursorPosition(0, 23);
                    Console.CursorVisible = false;
                    Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                                Press any key to continue for thhe next round...                                     ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                    Console.ReadKey(true);
                }

                RockPaperScissorsText();

                Console.WriteLine(@"
                                 ░█▀▀░▀█▀░█▀█░█▀█░█░░░░░█▀▄░█▀▀░█▀▀░█░█░█░░░▀█▀
                                 ░█▀▀░░█░░█░█░█▀█░█░░░░░█▀▄░█▀▀░▀▀█░█░█░█░░░░█░
                                 ░▀░░░▀▀▀░▀░▀░▀░▀░▀▀▀░░░▀░▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░░▀░");
                Console.WriteLine($"User: {userWins}  Computer: {computerWins}");
                if (userWins > computerWins)
                {
                    Console.SetCursorPosition(60 - 22, 14);
                    Console.WriteLine("Congratulations! You are the overall winner!");
                    Thread.Sleep(3000);
                }
                else if (computerWins > userWins)
                {
                    Console.SetCursorPosition(30, 14);
                    Console.WriteLine("Sorry, the computer is the overall winner. Better luck next time!");
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.SetCursorPosition(60 - 20, 14);
                    Console.WriteLine("It's a tie! No overall winner this time.");
                    Thread.Sleep(3000);
                }
                Console.SetCursorPosition(0, 23);
                Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                                  Press any key to return to the main lobby...                                       ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                Console.ReadKey(true);
                Program.MainLobby();
            }

            static string GetUserChoice()
            {
                string validChoices = "RPS";
                string userChoice;

                do
                {
                    userChoice = Console.ReadKey().KeyChar.ToString().ToUpper();

                    if (!validChoices.Contains(userChoice))
                    {
                        Console.CursorVisible = false;
                        Console.SetCursorPosition(76, 13);
                        Console.Write("/b");
                        CommonUtilities.FlickerVanishMessage("Invalid choice. Please enter R, P, or S.", 76, 13);
                        Console.SetCursorPosition(76, 13);
                    }
                    Console.CursorVisible = true;
                    
                } while (!validChoices.Contains(userChoice));

                return userChoice;
            }

            static string DetermineWinner(string userChoice, string computerChoice)
            {
                if (userChoice == computerChoice)
                {
                    return "It's a tie!";
                }
                else if ((userChoice == "R" && computerChoice == "S") ||
                         (userChoice == "P" && computerChoice == "R") ||
                         (userChoice == "S" && computerChoice == "P"))
                {
                    return "You win!";
                }
                else
                {
                    return "Computer wins!";
                }
            }
        }
        public static class RoundAsciiArt
        {
            private static readonly string[] asciiArt;

            static RoundAsciiArt()
            {
                asciiArt = new string[]
                {
            @"
                                            ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀█░
                                            ░█▀▄░█░█░█░█░█░█░█░█░░░░█░
                                            ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀
            ",
            @"
                                            ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀▀▄
                                            ░█▀▄░█░█░█░█░█░█░█░█░░░▄▀░
                                            ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀
            ",
            @"
                                            ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀▀█
                                            ░█▀▄░█░█░█░█░█░█░█░█░░░░▀▄
                                            ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀░
            ",
            @"
                                            ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░█░█
                                            ░█▀▄░█░█░█░█░█░█░█░█░░░░▀█
                                            ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░░░▀
            ",
            @"
                                            ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░█▀▀
                                            ░█▀▄░█░█░█░█░█░█░█░█░░░▀▀▄
                                            ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀░
            ",
            @"
                                            ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▄▀▀
                                            ░█▀▄░█░█░█░█░█░█░█░█░░░█▀▄
                                            ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░░▀░
            ",
            @"
                                            ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀▀█
                                            ░█▀▄░█░█░█░█░█░█░█░█░░░▄▀░
                                            ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀░░
            ",
            @"
                                            ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▄▀▄
                                            ░█▀▄░█░█░█░█░█░█░█░█░░░▄▀▄
                                            ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░░▀░
            ",
            @"
                                            ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▄▀▄
                                            ░█▀▄░█░█░█░█░█░█░█░█░░░░▀█
                                            ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀░
            ",
            @"
                                           ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀█░░▄▀▄
                                           ░█▀▄░█░█░█░█░█░█░█░█░░░░█░░█/█
                                           ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░░▀░
            ",
            @"
                                           ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀█░░▀█░
                                           ░█▀▄░█░█░█░█░█░█░█░█░░░░█░░░█░
                                           ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░▀▀▀
            ",
            @"
                                           ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀█░░▀▀▄
                                           ░█▀▄░█░█░█░█░█░█░█░█░░░░█░░▄▀░
                                           ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░▀▀▀
             ",
            @"
                                           ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀█░░▀▀█
                                           ░█▀▄░█░█░█░█░█░█░█░█░░░░█░░░▀▄
                                           ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░▀▀░
            ",
            @"
                                           ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀█░░█░█
                                           ░█▀▄░█░█░█░█░█░█░█░█░░░░█░░░▀█
                                           ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░░░▀
            ",
            @"
                                           ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀█░░█▀▀
                                           ░█▀▄░█░█░█░█░█░█░█░█░░░░█░░▀▀▄
                                           ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░▀▀░
            ",
            @"
                                           ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀█░░▄▀▀
                                           ░█▀▄░█░█░█░█░█░█░█░█░░░░█░░█▀▄
                                           ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░░▀░
            ",
            @"
                                           ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀█░░▀▀█
                                           ░█▀▄░█░█░█░█░█░█░█░█░░░░█░░▄▀░
                                           ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░▀░░
            ",
            @"
                                           ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀█░░▄▀▄
                                           ░█▀▄░█░█░█░█░█░█░█░█░░░░█░░▄▀▄
                                           ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░░▀░
            ",
            @"
                                           ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀█░░▄▀▄
                                           ░█▀▄░█░█░█░█░█░█░█░█░░░░█░░░▀█
                                           ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░▀▀░
            ",
            @"
                                           ░█▀▄░█▀█░█░█░█▀█░█▀▄░░░▀▀▄░▄▀▄
                                           ░█▀▄░█░█░█░█░█░█░█░█░░░▄▀░░█/█
                                           ░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░░▀░
            "
                };
            }
            public static string GetAsciiArtForRound(int roundNumber)
            {
                if (roundNumber >= 1 && roundNumber <= asciiArt.Length)
                {
                    return asciiArt[roundNumber - 1];
                }
                else
                {
                    return "No ASCII art available for this round.";
                }
            }
        }
    }
}
