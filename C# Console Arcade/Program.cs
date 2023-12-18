using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using NAudio.Wave;

namespace CSharp_Console_Arcade
{
    partial class Program
    {
        public static void Main(string[] args)
        {
            musicThread = new Thread(() => PlayBackgroundMusic(BackgroundMusicPath, musicStopEvent));
            musicThread.Start();

            //Console.WriteLine("".Length);
            //FlashTriggerGame.FlashTrigger();
            WelcomeScreen2();
            MainLobby();
        }
    }


    public static class CommonUtilities
    {
        public static void RainbowFlickerMessage(string message, int left, int top)
        {
            Console.CursorVisible = false;
            ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta };
            int colorIndex = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = colors[colorIndex];
                Console.SetCursorPosition(left, top);
                Console.WriteLine(message);
                Thread.Sleep(100);
                colorIndex = (colorIndex + 1) % colors.Length;
            }

            Console.ResetColor();
        }
        public static void FlickerVanishMessage(string message, int left, int top)
        {
            ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta };
            int colorIndex = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = colors[colorIndex];
                Console.SetCursorPosition(left, top);
                Console.WriteLine(message);
                Thread.Sleep(50);
                Console.SetCursorPosition(left, top);
                Console.WriteLine(new string(' ', message.Length));
                Thread.Sleep(50);
                colorIndex = (colorIndex + 1) % colors.Length;
            }

            Console.ResetColor();
        }
    }
}
