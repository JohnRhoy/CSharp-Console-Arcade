using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console_Arcade
{
    public class HangmanGame
    {
        public static void StartScreenHangman()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@"
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
XX                                                                                                                   XX
XX           ██░ ██  ▄▄▄       ███▄    █   ▄████  ███▄ ▄███▓ ▄▄▄       ███▄    █               ╔═══╗                 XX
XX          ▓██░ ██▒▒████▄     ██ ▀█   █  ██▒ ▀█▒▓██▒▀█▀ ██▒▒████▄     ██ ▀█   █               |   ║                 XX
XX          ▒██▀▀██░▒██  ▀█▄  ▓██  ▀█ ██▒▒██░▄▄▄░▓██    ▓██░▒██  ▀█▄  ▓██  ▀█ ██▒              O   ║                 XX
XX          ░▓█ ░██ ░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█  ██▓▒██    ▒██ ░██▄▄▄▄██ ▓██▒  ▐▌██▒             /|\  ║                 XX
XX          ░▓█▒░██▓ ▓█   ▓██▒▒██░   ▓██░░▒▓███▀▒▒██▒   ░██▒ ▓█   ▓██▒▒██░   ▓██░             / \  ║                 XX
XX           ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒░   ▒ ▒  ░▒   ▒ ░ ▒░   ░  ░ ▒▒   ▓▒█░░ ▒░   ▒ ▒                   ║                 XX
XX           ▒ ░▒░ ░  ▒   ▒▒ ░░ ░░   ░ ▒░  ░   ░ ░  ░      ░  ▒   ▒▒ ░░ ░░   ░ ▒░           ╔══════╩═══╗             XX
XX           ░  ░░ ░  ░   ▒      ░   ░ ░ ░ ░   ░ ░      ░     ░   ▒      ░   ░ ░            ║██████████║             XX
XX           ░  ░  ░      ░  ░         ░       ░        ░         ░  ░         ░            ╚══════════╝             XX
XX                                                                                                                   XX
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
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
                Hangman();
            }
            else if (choice == 'M')
            {
                Program.MainLobby();
            }
            else
            {
                CommonUtilities.RainbowFlickerMessage("Press 'S' to start the game or 'M' to return to the main lobby...", 26, 26);
                StartScreenHangman();
            }
        }

        public static void HangmanText()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(
@"XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                                            ░█░█░█▀█░█▀█░█▀▀░█▄█░█▀█░█▀█
                                            ░█▀█░█▀█░█░█░█░█░█░█░█▀█░█░█
                                            ░▀░▀░▀░▀░▀░▀░▀▀▀░▀░▀░▀░▀░▀░▀
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
");
        }

        public static void HangmanGameInstructions()
        {
            HangmanText();
            Console.SetCursorPosition(23, 8);
            foreach (char c in "In this game, the computer selects a secret word and you need to guess it.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(17, 9);
            foreach (char c in "You can guess one letter at a time. If the letter is in the word, it will be revealed.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(30, 10);
            foreach (char c in "Repeating a letter you've guessed before will be invalidated.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(22, 11);
            foreach (char c in "Be careful, you have a limited number of attempts to guess the entire word.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(22, 12);
            foreach (char c in "If you guess the word correctly, you win! Otherwise, the hangman gets closer.")
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
            Console.CursorVisible = false;
            Console.ReadKey(true);
        }

        public static void Hangman()
        {
            HangmanGameInstructions();

            string secretWord = ChooseWord();
            char[] guessedWord = new char[secretWord.Length];
            for (int i = 0; i < secretWord.Length; i++)
            {
                guessedWord[i] = '_';
            }

            int attempts = 7;
            string guessedLetters = "";
            int startingPosition = 60;


            while (attempts > 0)
            {
                HangmanText();
                DisplayHangman(attempts);
                DisplayWord(guessedWord, secretWord);
                DisplayGuessedLetters(guessedLetters, startingPosition);

                Console.SetCursorPosition(0, 9);
                Console.Write("Enter a letter: ");
                Console.SetCursorPosition(16, 9);
                char guess = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (char.IsLetter(guess) && !guessedLetters.Contains(guess))
                {
                    guessedLetters += guess;

                    if (secretWord.Contains(guess))
                    {
                        UpdateGuessedWord(secretWord, guessedWord, guess);
                        if (new string(guessedWord) == secretWord)
                        {
                            Console.SetCursorPosition(35, 23);
                            Console.WriteLine("Congratulations! You guessed the word: " + secretWord);
                            break;
                        }
                    }
                    else
                    {
                        CommonUtilities.RainbowFlickerMessage("Incorrect guess! Try again.", 16, 9);
                        attempts--;
                    }
                    startingPosition--;
                }
                else
                {
                    CommonUtilities.RainbowFlickerMessage("Please enter a letter you haven't guessed before.", 16, 9);
                }
            }

            if (attempts == 0)
            {
                Console.SetCursorPosition(29, 23);
                Console.WriteLine("Sorry, you ran out of attempts. The correct word was: " + secretWord);
                Thread.Sleep(4000);

                HangmanDeathAnimation();
            }

            Console.SetCursorPosition(0, 24);
            Console.CursorVisible = false;
            Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                                  Press any key to return to the main lobby...                                       ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ReadKey(true);
            Program.MainLobby();
        }

        static string ChooseWord()
        {
            string[] words = {
    "PROGRAMMING", "COMPUTER", "SOFTWARE", "DEVELOPMENT", "TECHNOLOGY",
    "KEYBOARD", "ALGORITHM", "INTERFACE", "DEBUGGING", "APPLICATION",
    "DATABASE", "ENCRYPTION", "FRAMEWORK", "VARIABLE", "FUNCTION",
    "ITERATION", "DEBUGGING", "REPOSITORY", "ARTIFICIAL", "INTELLIGENCE",
    "NETWORK", "SECURITY", "OPERATING", "SYSTEM", "MOBILE", "JAVASCRIPT",
    "INTERFACE", "VERSION", "CONTROL", "DEPLOYMENT", "JOHNRHOY"
};

            Random random = new Random();
            return words[random.Next(words.Length)];
        }

        static void DisplayHangman(int attempts)
        {
            Console.SetCursorPosition(0, 7);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                            ║
                                                            ║
                                                            ║
                                                       ███  ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");

            int remainingParts = 7 - attempts;
            Console.SetCursorPosition(56, 10);

            switch (remainingParts)
            {
                case 1:
                    Console.WriteLine("O");
                    break;
                case 2:
                    Console.WriteLine("O");
                    Console.SetCursorPosition(56, 11);
                    Console.WriteLine("|");
                    break;
                case 3:
                    Console.WriteLine("O");
                    Console.SetCursorPosition(55, 11);
                    Console.WriteLine("/|");
                    break;
                case 4:
                    Console.WriteLine("O");
                    Console.SetCursorPosition(55, 11);
                    Console.WriteLine(@"/|\");
                    break;
                case 5:
                    Console.WriteLine("O");
                    Console.SetCursorPosition(55, 11);
                    Console.WriteLine(@"/|\");
                    Console.SetCursorPosition(55, 12);
                    Console.WriteLine("/");
                    break;
                case 6:
                    Console.WriteLine("O");
                    Console.SetCursorPosition(55, 11);
                    Console.WriteLine(@"/|\");
                    Console.SetCursorPosition(55, 12);
                    Console.WriteLine(@"/ \");
                    break;
            }
        }

        static void DisplayWord(char[] guessedWord, string secretWord)
        {
            int widthPosition = 57 - secretWord.Length;
            Console.SetCursorPosition(widthPosition, 17);
            Console.Write("Word: ");
            foreach (char letter in guessedWord)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();
        }

        static void DisplayGuessedLetters(string guessedLetters, int startingPosition)
        {
            Console.SetCursorPosition(52, 18);
            Console.Write("Guessed Letters: ");

            Console.SetCursorPosition(startingPosition, 19);
            foreach (char letter in guessedLetters)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();
        }

        static void UpdateGuessedWord(string secretWord, char[] guessedWord, char guess)
        {
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == guess)
                {
                    guessedWord[i] = guess;
                }
            }
        }
        public static void HangmanDeathAnimation()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine(@"
                                               .ed"""""""" """"""$$$$be.
                                             -""           ^""""**$$$e.
                                           .""                   '$$$c
                                          /                      ""4$$b
                                         d  3                      $$$$
                                         $  *                   .$$$$$$
                                        .$  ^c           $$$$$e$$$$$$$$.
                                        d$L  4.         4$$$$$$$$$$$$$$b
                                        $$$$b ^ceeeee.  4$$ECL.F*$$$$$$$
                                        $$$$P d$$$$F $ $$$$$$$$$- $$$$$$
                                        3$$$F ""$$$$b   $""$$$$$$$  $$$$*""
                                         $$P""  ""$$b   .$ $$$$$...e$$
                                          *c    ..    $$ 3$$$$$$$$$$eF
                                            %ce""""    $$$  $$$$$$$$$$*
                                             *$e.    *** d$$$$$""L$$
                                              $$$      4J$$$$$% $$$
                                             $""'$=e....$*$$**$cz$$""
                                             $  *=%4.$ L L$ P3$$$F
                                             $   ""%*ebJLzb$e$$$$$b
                                              %..      4$$$$$$$$$$
                                               $$$e   z$$$$$$$$$$
                                                ""*$c  ""$$$$$$$P""
                                                  """"""*$$$$$$$""
");
            Console.Beep(800, 3000);
            //Thread.Sleep(3000);

            HangmanText();

            Console.CursorVisible = false;
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                       /|\  ║
                                                       / \  ║
                                                       ███  ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(2000);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                       /|\  ║
                                                       / \  ║
                                                            ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(1000);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O>  ║
                                                       /|   ║
                                                        >\  ║
                                                            ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                       /|\  ║
                                                       / \  ║
                                                            ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                       <O   ║
                                                        |\  ║
                                                       /<   ║
                                                            ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                       /|\  ║
                                                       / \  ║
                                                            ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(500);

            for (int i = 0; i < 2; i++)
            {
                HangmanText();
                Console.SetCursorPosition(4, 13);
                Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O>  ║
                                                       /|   ║
                                                        >\  ║
                                                            ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
                Thread.Sleep(500);
            }

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                       /|\  ║
                                                       / \  ║
                                                            ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(500);

            for (int i = 0; i < 3; i++)
            {
                HangmanText();
                Console.SetCursorPosition(4, 13);
                Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                       <O   ║
                                                        |\  ║
                                                       /<   ║
                                                            ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
                Thread.Sleep(500);
            }

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                       /|\  ║
                                                       / \  ║
                                                            ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(1500);

            for (int i = 0; i < 6; i++)
            {
                HangmanText();
                Console.SetCursorPosition(4, 13);
                Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                        |   ║
                                                        |   ║
                                                            ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
                Thread.Sleep(500);
            }

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                            ║
                                                        /   ║
                                                        \   ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                        '   ║
                                                            ║
                                                      |__   ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                        .   ║
                                                            ║
                                                      \__   ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                            ║
                                                        .   ║
                                                     ____   ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                        '   ║
                                                        .   ║
                                                      __    ║
                                                    /╔══════╩═══╗
                                                     ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                        .   ║
                                                            ║
                                                      _ '   ║
                                                    /╔══════╩═══╗
                                                   | ║██████████║
                                                     ╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                            ║
                                                        '   ║
                                                        _   ║
                                                    /╔══════╩═══╗
                                                    |║██████████║
                                                  __ ╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                        '   ║
                                                        .   ║
                                                            ║
                                                     ╔══════╩═══╗
                                                    |║██████████║
                                                  __/╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                            ║
                                                        '   ║
                                                        .   ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                  __/╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                            ║
                                                        .   ║
                                                        _   ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                  __/╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                        '   ║
                                                            ║
                                                       _    ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                  __/╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                            ║
                                                        '   ║
                                                       _    ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                  __/╚══════════╝
");
            Thread.Sleep(500);

            HangmanText();
            Console.SetCursorPosition(4, 13);
            Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                            ║
                                                            ║
                                                      _ .   ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                  __/╚══════════╝
");
            Thread.Sleep(500);

            for (int i = 0; i < 2; i++)
            {
                HangmanText();
                Console.SetCursorPosition(4, 13);
                Console.WriteLine(@"
                                                        ╔═══╗
                                                        |   ║
                                                        O   ║
                                                            ║
                                                            ║
                                                        _   ║
                                                     ╔══════╩═══╗
                                                     ║██████████║
                                                  __/╚══════════╝
");
                Thread.Sleep(500);
            }

        }
    }
}
