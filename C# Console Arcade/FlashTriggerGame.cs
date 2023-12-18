using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console_Arcade
{
    public static class FlashTriggerGame
    {
        public static void StartScreenFlashTrigger()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(
@"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%                                                                                                                   %%
%%      _  __)\____________________________________/7_               ________________                ______          %%
%%     (//   )))))                                   `\||            ___  ____/___  /______ ____________  /_         %%
%%      /   (((((                                      )`             __  /_    __  / _  __ `/__  ___/__  __ \       %%
%%     (______________________________________________/               _  __/    _  /  / /_/ / _(__  ) _  / / /       %%
%%      \   ________ ______________________________/                  /_/       /_/   \__,_/  /____/  /_/ /_/        %%
%%       ) /#######/ )\  /     )/                                                                                    %%
%%      / /##(\)##/ /  \(     //              ________        _____                                                  %%
%%     / /#######( (\______.ad`               ___  __/___________(_)_______ ________ ______ ________                 %%
%%    / /#########) )------``                 __  /   __  ___/__  / __  __ `/__  __ `/_  _ \__  ___/                 %%
%%   / /#########/ /                          _  /    _  /    _  /  _  /_/ / _  /_/ / /  __/_  /                     %%
%%  / /###(/)###/ /                           /_/     /_/     /_/   _\__, /  _\__, /  \___/ /_/                      %%
%% ( (#########/ (                                                  /____/   /____/                                  %%
%%  \____/_______\)                                                                                                  %%
%%                                                                                                                   %%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
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
                FlashTrigger();
            }
            else if (choice == 'M')
            {
                Program.MainLobby();
            }
            else
            {
                CommonUtilities.RainbowFlickerMessage("Press 'S' to start the game or 'M' to return to the main lobby...", 26, 26);
                StartScreenFlashTrigger();
            }
        }

        public static void FlashTriggerText()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(
@"████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                                  ░█▀▀░█░░░█▀█░█▀▀░█░█░░░▀█▀░█▀▄░▀█▀░█▀▀░█▀▀░█▀▀░█▀▄
                                  ░█▀▀░█░░░█▀█░▀▀█░█▀█░░░░█░░█▀▄░░█░░█░█░█░█░█▀▀░█▀▄
                                  ░▀░░░▀▀▀░▀░▀░▀▀▀░▀░▀░░░░▀░░▀░▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀░▀
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
");
        }

        public static void FlashTriggerInstructions()
        {
            FlashTriggerText();

            Console.SetCursorPosition(15, 8);
            foreach (char c in "This game is a battle of reflexes, test your reaction time and beat the enemy in a flash!")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(19, 9);
            foreach (char c in "When prompted, hit the spacebar as fast as you can. Your goal is to react quickly!")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(22, 10);
            foreach (char c in "Draw too early without the prompt and the enemy will seize the opportunity.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(42, 11);
            foreach (char c in "Draw too late and it's instant death.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(19, 12);
            foreach (char c in "Challenge yourself and engage in an epic duel to see who has the quickest draw.")
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
        public static void FlashTrigger()
        {
            FlashTriggerInstructions();
            FlashTriggerText();

            const string menu = @"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
║                                              Choose Your Opponent:                                                  ║
║                                       [1] Very Easy....1500 milliseconds                                            ║
║                                          [2] Easy....1000 milliseconds                                              ║
║                                          [3] Medium...500 milliseconds                                              ║
║                                          [4] Hard.....250 milliseconds                                              ║
║                                          [5] Flash....125 milliseconds                                              ║
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝

	";

            const string wait =
@"╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                       _O                                   O_                                       ║
║                                      |/|_              Wait               _|\|                                      ║
║                                      /\                                     /\                                      ║
║                                     /  |                                   |  \                                     ║
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
	";

            const string fire = 
@"╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                       _O              XXXXXXXX             O_                                       ║
║                                      |/|_             X FIRE X            _|\|                                      ║
║                                      /\               XXXXXXXX              /\                                      ║
║                                     /  |                                   |  \                                     ║
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
    ";

            const string loseTooSlow = 
@"╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                             > ╗__O                                  ║
║                                    //                   Too Slow                / \                                 ║
║                                   O/__/\                You Lose               /\                                   ║
║                                        \                                      |  \                                  ║
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
    ";

            const string loseTooFast =
@"╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
║                                                                                                                    ║
║                                                                                                                    ║
║                                                                                                                    ║
║                                                                                                                    ║
║                                                                                                                    ║
║                                                                                                                    ║
║                                                                                                                    ║
║                                                                                                                    ║
║                                                        Too Fast            > ╗__O                                  ║
║                                   //                  You Missed               / \                                 ║
║                                  O/__/\                You Lose               /\                                   ║
║                                       \                                      |  \                                  ║
║████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
    ";

            const string win =
@"╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                                                                                                     ║
║                                     O__╔ <                                                                          ║
║                                    / \                                           \\                                 ║
║                                      /\                  You Win               /\__\O                               ║
║                                     /  |                                       /                                    ║
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
    ";

            while (true)
            {
                FlashTriggerText();

                Console.WriteLine(menu);
                TimeSpan? requiredReactionTime = null;
                while (requiredReactionTime is null)
                {
                    Console.CursorVisible = false;
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1 or ConsoleKey.NumPad1: requiredReactionTime = TimeSpan.FromMilliseconds(1500); break;
                        case ConsoleKey.D2 or ConsoleKey.NumPad2: requiredReactionTime = TimeSpan.FromMilliseconds(1000); break;
                        case ConsoleKey.D3 or ConsoleKey.NumPad3: requiredReactionTime = TimeSpan.FromMilliseconds(0500); break;
                        case ConsoleKey.D4 or ConsoleKey.NumPad4: requiredReactionTime = TimeSpan.FromMilliseconds(0250); break;
                        case ConsoleKey.D5 or ConsoleKey.NumPad4: requiredReactionTime = TimeSpan.FromMilliseconds(0125); break;
                        case ConsoleKey.Escape: Program.MainLobby(); break;
                    }
                }
                FlashTriggerText();

                TimeSpan signal = TimeSpan.FromMilliseconds(new Random().Next(5000, 25000));
                Console.WriteLine(wait);
                Stopwatch stopwatch = new();
                stopwatch.Restart();
                bool tooFast = false;

                while (stopwatch.Elapsed < signal && !tooFast)
                {
                    if (Console.KeyAvailable)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.L:
                            case ConsoleKey.Spacebar:
                                tooFast = true;
                                break;
                        }
                    }
                }

                FlashTriggerText();

                Console.CursorVisible = false;
                Console.WriteLine(fire);
                stopwatch.Restart();
                bool tooSlow = true;
                TimeSpan reactionTime = default;
                while (!tooFast && stopwatch.Elapsed < requiredReactionTime && tooSlow)
                {
                    if (Console.KeyAvailable)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.L:
                            case ConsoleKey.Spacebar:
                                tooSlow = false;
                                reactionTime = stopwatch.Elapsed;
                                break;
                        }
                    }
                }

                FlashTriggerText();

                Console.WriteLine(
                    tooFast ? loseTooFast :
                    tooSlow ? loseTooSlow :
                    $"{win}{Environment.NewLine}  Reaction Time: {reactionTime.TotalMilliseconds} milliseconds");
                Console.SetCursorPosition(0, 23);
                Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                         Press [Enter] to play again, Press Escape to return to the Main Lobby                       ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
");
                Console.CursorVisible = false;
                GetEnterOrEscape:
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter: break;
                    case ConsoleKey.Escape: Program.MainLobby(); break;
                    default: goto GetEnterOrEscape;
                }
            }
        }
    }
}
