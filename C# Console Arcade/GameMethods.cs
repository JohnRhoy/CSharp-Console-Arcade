﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console_Arcade
{
    partial class Program
    {
        public static void WelcomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(
@"========================================================================================================================
#                                                                                                                      #
#              db   d8b   db d88888b db       .o88b.  .d88b.  .88b  d88. d88888b      d888888b  .d88b.                 #
#              88   I8I   88 88'     88      d8P  Y8 .8P  Y8. 88'YbdP`88 88'          `~~88~~' .8P  Y8.                #
#              88   I8I   88 88ooooo 88      8P      88    88 88  88  88 88ooooo         88    88    88                #
#              Y8   I8I   88 88~~~~~ 88      8b      88    88 88  88  88 88~~~~~         88    88    88                #
#              `8b d8'8b d8' 88.     88booo. Y8b  d8 `8b  d8' 88  88  88 88.             88    `8b  d8'                #
#               `8b8' `8d8'  Y88888P Y88888P  `Y88P'  `Y88P'  YP  YP  YP Y88888P         YP     `Y88P'                 #
#                                                                                                                      #
#    .o88b.  .d88b.  d8b   db .d8888.  .d88b.  db      d88888b       .d8b.  d8888b.  .o88b.  .d8b.  d8888b. d88888b    #
#   d8P  Y8 .8P  Y8. 888o  88 88'  YP .8P  Y8. 88      88'          d8' `8b 88  `8D d8P  Y8 d8' `8b 88  `8D 88'        #
#   8P      88    88 88V8o 88 `8bo.   88    88 88      88ooooo      88ooo88 88oobY' 8P      88ooo88 88   88 88ooooo    #
#   8b      88    88 88 V8o88   `Y8b. 88    88 88      88~~~~~      88~~~88 88`8b   8b      88~~~88 88   88 88~~~~~    #
#   Y8b  d8 `8b  d8' 88  V888 db   8D `8b  d8' 88booo. 88.          88   88 88 `88. Y8b  d8 88   88 88  .8D 88.        #
#    `Y88P'  `Y88P'  VP   V8P `8888Y'  `Y88P'  Y88888P Y88888P      YP   YP 88   YD  `Y88P' YP   YP Y8888D' Y88888P    #
#                                                                                                                      #
#          ┌────────────────────────────────────────────────────────────────────────────────────────────────┐          #
#          |                                                                                                |          #
#          └────────────────────────────────────────────────────────────────────────────────────────────────┘          #
#                                                                                                                      #
========================================================================================================================
");
            Console.CursorVisible = false;
            Console.SetCursorPosition(12, 17);

            for (int i = 0; i < 96; i++)
            {
                Console.Write("█");
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(0, 24);
            Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                                              Press any key to continue...                                           ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
");
            Console.ResetColor();
            Console.ReadKey(true);
        }
        public static void MainLobby()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(
@"████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
========================================================================================================================
                              █▀▀░█▀█░█▀█░█▀▀░█▀█░█░░░█▀▀░░░█▀█░█▀▄░█▀▀░█▀█░█▀▄░█▀▀
                             ░█░░░█░█░█░█░▀▀█░█░█░█░░░█▀▀░░░█▀█░█▀▄░█░░░█▀█░█░█░█▀▀
                             ░▀▀▀░▀▀▀░▀░▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░░░▀░▀░▀░▀░▀▀▀░▀░▀░▀▀░░▀▀▀

                ███╗   ███╗ █████╗ ██╗███╗   ██╗    ██╗      ██████╗ ██████╗ ██████╗ ██╗   ██╗
                ███╗  ████║██╔══██╗██║████╗  ██║    ██║     ██╔═══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝
                ██╔████╔██║███████║██║██╔██╗ ██║    ██║     ██║   ██║██████╔╝██████╔╝ ╚████╔╝ 
                ██║╚██╔╝██║██╔══██║██║██║╚██╗██║    ██║     ██║   ██║██╔══██╗██╔══██╗  ╚██╔╝  
                ██║ ╚═╝ ██║██║  ██║██║██║ ╚████║    ███████╗╚██████╔╝██████╔╝██████╔╝   ██║   
                ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝    ╚══════╝ ╚═════╝ ╚═════╝ ╚═════╝    ╚═╝   
========================================================================================================================
████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
");
            Console.CursorVisible = true;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 20, 15);
            Console.WriteLine("Pick a game: ");

            Console.SetCursorPosition(0, 16);
            Console.WriteLine("1.  Guess The Number");
            Console.WriteLine("2.  Rock, Papers, Scissors");
            Console.WriteLine("3.  Hangman");
            Console.WriteLine("4.  Flash Trigger");
            Console.WriteLine("5.  2048");
            Console.WriteLine("6.  Game Settings");
            Console.WriteLine("7.  Credits");

            Console.SetCursorPosition((Console.WindowWidth / 2) - 7, 15);

            char gameChoice;

            do
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 7, 15);
                gameChoice = Console.ReadKey(true).KeyChar;

                switch (gameChoice)
                {
                    case '1':
                        GuessTheNumberGame.StartScreenGuessTheNumber();
                        break;
                    case '2':
                        RockPaperScissorsGame.StartScreenRockPaperScissors();
                        break;
                    case '3':
                        HangmanGame.StartScreenHangman();
                        break;
                    case '4':
                        FlashTriggerGame.StartScreenFlashTrigger();
                        break;
                    case '5':
                        T2048Game.StartScreen2048();
                        break;
                    case '6':
                        ShowSettingsMenu();
                        break;
                    case '7':
                        DisplaySpecialCredits();
                        break;
                    default:
                        CommonUtilities.FlickerVanishMessage("I'm afraid the game you entered doesn't exist", (Console.WindowWidth / 2) - 7, 15);
                        break;
                }
            } while (gameChoice != '1');
        }

        public static void DisplaySpecialCredits()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.CursorVisible = false;
            string[] creditsText = {
@"████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████

     ██████╗ ██████╗ ███╗   ██╗███████╗ ██████╗ ██╗     ███████╗     █████╗ ██████╗  ██████╗ █████╗ ██████╗ ███████╗
    ██╔════╝██╔═══██╗████╗  ██║██╔════╝██╔═══██╗██║     ██╔════╝    ██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔════╝
    ██║     ██║   ██║██╔██╗ ██║███████╗██║   ██║██║     █████╗      ███████║██████╔╝██║     ███████║██║  ██║█████╗  
    ██║     ██║   ██║██║╚██╗██║╚════██║██║   ██║██║     ██╔══╝      ██╔══██║██╔══██╗██║     ██╔══██║██║  ██║██╔══╝  
    ╚██████╗╚██████╔╝██║ ╚████║███████║╚██████╔╝███████╗███████╗    ██║  ██║██║  ██║╚██████╗██║  ██║██████╔╝███████╗
     ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝ ╚═════╝ ╚══════╝╚══════╝    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═════╝ ╚══════╝

████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████




                                 ▄████▄   ██▀███  ▓█████ ▓█████▄  ██▓▄▄▄█████▓  ██████ 
                                ▒██▀ ▀█  ▓██ ▒ ██▒▓█   ▀ ▒██▀ ██▌▓██▒▓  ██▒ ▓▒▒██    ▒ 
                                ▒▓█    ▄ ▓██ ░▄█ ▒▒███   ░██   █▌▒██▒▒ ▓██░ ▒░░ ▓██▄   
                                ▒▓▓▄ ▄██▒▒██▀▀█▄  ▒▓█  ▄ ░▓█▄   ▌░██░░ ▓██▓ ░   ▒   ██▒
                                ▒ ▓███▀ ░░██▓ ▒██▒░▒████▒░▒████▓ ░██░  ▒██▒ ░ ▒██████▒▒
                                ░ ░▒ ▒  ░░ ▒▓ ░▒▓░░░ ▒░ ░ ▒▒▓  ▒ ░▓    ▒ ░░   ▒ ▒▓▒ ▒ ░
                                  ░  ▒     ░▒ ░ ▒░ ░ ░  ░ ░ ▒  ▒  ▒ ░    ░    ░ ░▒  ░ ░
                                ░          ░░   ░    ░    ░ ░  ░  ▒ ░  ░      ░  ░  ░  
                                ░ ░         ░        ░  ░   ░     ░                 ░  
                                ░                         ░                            


",
@"
                                           █▀▀ █▀█ █▀▀ ▄▀█ ▀█▀ █▀█ █▀█
                                           █▄▄ █▀▄ ██▄ █▀█ ░█░ █▄█ █▀▄

████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
========================================================================================================================

                          ░░░░░██╗░█████╗░██╗░░██╗███╗░░██╗  ██████╗░██╗░░██╗░█████╗░██╗░░░██╗
                          ░░░░░██║██╔══██╗██║░░██║████╗░██║  ██╔══██╗██║░░██║██╔══██╗╚██╗░██╔╝
                          ░░░░░██║██║░░██║███████║██╔██╗██║  ██████╔╝███████║██║░░██║░╚████╔╝░
                          ██╗░░██║██║░░██║██╔══██║██║╚████║  ██╔══██╗██╔══██║██║░░██║░░╚██╔╝░░
                          ╚█████╔╝╚█████╔╝██║░░██║██║░╚███║  ██║░░██║██║░░██║╚█████╔╝░░░██║░░░
                          ░╚════╝░░╚════╝░╚═╝░░╚═╝╚═╝░░╚══╝  ╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░░░░╚═╝░░░

                       ██████╗░░█████╗░██████╗░░█████╗░██╗███╗░░██╗░█████╗░██╗░░░██╗██╗░░░░░░█████╗
                       ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║████╗░██║██╔══██╗██║░░░██║██║░░░░░██╔══██╗
                       ██████╔╝██║░░██║██████╔╝██║░░╚═╝██║██╔██╗██║██║░░╚═╝██║░░░██║██║░░░░░███████║
                       ██╔═══╝░██║░░██║██╔══██╗██║░░██╗██║██║╚████║██║░░██╗██║░░░██║██║░░░░░██╔══██║
                       ██║░░░░░╚█████╔╝██║░░██║╚█████╔╝██║██║░╚███║╚█████╔╝╚██████╔╝███████╗██║░░██║
                       ╚═╝░░░░░░╚════╝░╚═╝░░╚═╝░╚════╝░╚═╝╚═╝░░╚══╝░╚════╝░░╚═════╝░╚══════╝╚═╝░░╚═╝

========================================================================================================================
████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
",

@"_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
_|___|___|___|___|__████████╗██╗░░██╗░█████╗░███╗░░██╗██╗░░██╗___██╗░░░██╗░█████╗░██╗░░░██╗__|_██╗██╗|___|___|___|___|__
___|___|___|___|___|╚══██╔══╝██║░░██║██╔══██╗████╗░██║██║░██╔╝_|_╚██╗░██╔╝██╔══██╗██║░░░██║|__|██║██║__|___|___|___|___|
_|___|___|___|___|___|_██║░░░███████║███████║██╔██╗██║█████═╝|___|╚████╔╝░██║░░██║██║░░░██║__|_██║██║|___|___|___|___|__
___|___|___|___|___|___██║░░░██╔══██║██╔══██║██║╚████║██╔═██╗__|___╚██╔╝░░██║░░██║██║░░░██║|__|╚═╝╚═╝__|___|___|___|___|
_|___|___|___|___|___|_██║░░░██║░░██║██║░░██║██║░╚███║██║░╚██╗___|__██║░░░╚█████╔╝╚██████╔╝__|_██╗██╗|___|___|___|___|__
___|___|___|___|___|___╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝___|__╚═╝░░░░╚════╝░░╚═════╝_|__|╚═╝╚═╝__|___|___|___|___|
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__
___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|"
};
            foreach (string text in creditsText)
            {
                Console.Clear();
                Thread.Sleep(80);
                Console.WriteLine(text);
                Thread.Sleep(5000);
            }
            MainLobby();
        }

        public static void WelcomeScreen2()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(
@" ______________________________________________________________________________________________________________________
|   ________________________________________________________________________________________________________________   |
|  |                                ░█░█░█▀▀░█░░░█▀▀░█▀█░█▄█░█▀▀        ░▀█▀░█▀█                                    |  |
|  |                                ░█▄█░█▀▀░█░░░█░░░█░█░█░█░█▀▀         ░█░░█░█                                    |  |
|  |                                ░▀░▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀░▀░▀▀▀         ░▀░░▀▀▀                                    |  |
|  |                                                                                                                |  |
|  |              █████████     ███████    ██████   █████  █████████     ███████    █████       ██████████          |  |
|  |             ███░░░░░███  ███░░░░░███ ░░██████ ░░███  ███░░░░░███  ███░░░░░███ ░░███       ░░███░░░░░█          |  |
|  |            ███     ░░░  ███     ░░███ ░███░███ ░███ ░███    ░░░  ███     ░░███ ░███        ░███  █ ░           |  |
|  |           ░███         ░███      ░███ ░███░░███░███ ░░█████████ ░███      ░███ ░███        ░██████             |  |
|  |           ░███         ░███      ░███ ░███ ░░██████  ░░░░░░░░███░███      ░███ ░███        ░███░░█             |  |
|  |           ░░███     ███░░███     ███  ░███  ░░█████  ███    ░███░░███     ███  ░███      █ ░███ ░   █          |  |
|  |            ░░█████████  ░░░███████░   █████  ░░█████░░█████████  ░░░███████░   ███████████ ██████████          |  |
|  |             ░░░░░░░░░     ░░░░░░░    ░░░░░    ░░░░░  ░░░░░░░░░     ░░░░░░░    ░░░░░░░░░░░ ░░░░░░░░░░           |  |
|  |                   █████████   ███████████     █████████    █████████   ██████████   ██████████                 |  |
|  |                  ███░░░░░███ ░░███░░░░░███   ███░░░░░███  ███░░░░░███ ░░███░░░░███ ░░███░░░░░█                 |  |
|  |                 ░███    ░███  ░███    ░███  ███     ░░░  ░███    ░███  ░███   ░░███ ░███  █ ░                  |  |
|  |                 ░███████████  ░██████████  ░███          ░███████████  ░███    ░███ ░██████                    |  |
|  |                 ░███░░░░░███  ░███░░░░░███ ░███          ░███░░░░░███  ░███    ░███ ░███░░█                    |  |
|  |                 ░███    ░███  ░███    ░███ ░░███     ███ ░███    ░███  ░███    ███  ░███ ░   █                 |  |
|  |                 █████   █████ █████   █████ ░░█████████  █████   █████ ██████████   ██████████                 |  |
|  |                ░░░░░   ░░░░░ ░░░░░   ░░░░░   ░░░░░░░░░  ░░░░░   ░░░░░ ░░░░░░░░░░   ░░░░░░░░░░                  |  |
|  |                                                                                                                |  |
|  |       ┌────────────────────────────────────────────────────────────────────────────────────────────────┐       |  |
|  |       |                                                 JREP                                           |       |  |
|  |       └────────────────────────────────────────────────────────────────────────────────────────────────┘       |  |
|  |________________________________________________________________________________________________________________|  |
|______________________________________________________________________________________________________________________|
");
            Console.CursorVisible = false;
            Console.SetCursorPosition(12, 24);

            for (int i = 0; i < 96; i++)
            {
                Console.Write("█");
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(46, 22);
            Console.WriteLine("Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true);
        }

    }
}