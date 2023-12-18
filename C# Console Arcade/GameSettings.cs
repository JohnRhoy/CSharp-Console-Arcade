using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console_Arcade
{
    partial class Program
    {
        public static string[] SoundtrackOptions = new string[]
        {
        "C:\\POS System C#\\C# Console Arcade\\Background Music\\feed-the-machine-classic-arcade-game-116846.mp3",
        "C:\\POS System C#\\C# Console Arcade\\Background Music\\8-bit-arcade-mode-158814.mp3",
        "C:\\POS System C#\\C# Console Arcade\\Background Music\\battle-time-178551.mp3",
        "C:\\POS System C#\\C# Console Arcade\\Background Music\\blinding-light-classic-arcade-game-116839.mp3",
        "C:\\POS System C#\\C# Console Arcade\\Background Music\\cruising-down-8bit-lane-159615.mp3",
        "C:\\POS System C#\\C# Console Arcade\\Background Music\\digital-love-127441.mp3",
        "C:\\POS System C#\\C# Console Arcade\\Background Music\\8-bit-classic-arcade-game-116832.mp3",
        "C:\\POS System C#\\C# Console Arcade\\Background Music\\skool-daze-classic-arcade-game-116825.mp3"
        };

        public static string BackgroundMusicPath { get; set; } = "C:\\POS System C#\\C# Console Arcade\\Background Music\\feed-the-machine-classic-arcade-game-116846.mp3";
        public static bool IsMusicEnabled { get; set; } = true;

        static Thread musicThread;
        static ManualResetEvent musicStopEvent = new ManualResetEvent(false);
        private static WaveOutEvent outputDevice;
        private static AudioFileReader audioFileReader;

        public static void ChangeBackgroundMusic()
        {
            GameSettingsText();
            Console.CursorVisible = true;

            Console.SetCursorPosition(0, 16);
            Console.WriteLine("Select a background music option:");

            for (int i = 0; i < SoundtrackOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}.  SoundTrack {i + 1}");
            }

            Console.WriteLine("9.  Back to Main Menu");

            Console.SetCursorPosition(55, 15);
            Console.Write("Enter Key: ");
            Console.SetCursorPosition(66, 15);

            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= SoundtrackOptions.Length)
            {
                BackgroundMusicPath = SoundtrackOptions[choice - 1];

                musicStopEvent.Set();
                musicThread.Join();

                musicStopEvent.Reset();
                musicThread = new Thread(() => PlayBackgroundMusic(BackgroundMusicPath, musicStopEvent));
                musicThread.Start();

                CommonUtilities.FlickerVanishMessage("Background music changed successfully!", 41, 25);
                MainLobby();
            }
            else if (choice == 9)
            {
                ShowSettingsMenu();
            }
            else
            {
                CommonUtilities.FlickerVanishMessage("Invalid choice", 66, 15);
                ChangeBackgroundMusic();
            }
        }

        public static void ToggleMusic()
        {
            try
            {
                IsMusicEnabled = !IsMusicEnabled;

                if (IsMusicEnabled)
                {
                    if (musicThread == null || !musicThread.IsAlive)
                    {
                        musicStopEvent.Reset();
                        musicThread = new Thread(() => PlayBackgroundMusic(BackgroundMusicPath, musicStopEvent));
                        musicThread.Start();
                        CommonUtilities.FlickerVanishMessage("Background music turned on successfully!", 45, 25);
                    }
                }
                else
                {
                    if (musicThread != null && musicThread.IsAlive)
                    {
                        musicStopEvent.Set(); 
                        musicThread.Join();   
                        musicThread = null;
                    }

                    CommonUtilities.FlickerVanishMessage("Background music turned off successfully!", 45, 25);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void PlayBackgroundMusic(string audioFile, ManualResetEvent stopEvent)
        {
            try
            {
                while (!stopEvent.WaitOne(0))
                {
                    using (var outputDeviceLocal = new WaveOutEvent())
                    using (var audioFileReaderLocal = new AudioFileReader(audioFile))
                    {
                        outputDeviceLocal.Init(audioFileReaderLocal);
                        outputDeviceLocal.Play();

                        while (outputDeviceLocal.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(1000);
                            if (stopEvent.WaitOne(0)) break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void ShowSettingsMenu()
        {
            GameSettingsText();
            Console.SetCursorPosition(0, 16);

            string musicStatus = IsMusicEnabled ? "Turn Off Music" : "Turn On Music";
            Console.WriteLine($"1. Change Background Music");
            Console.WriteLine($"2. {musicStatus}");
            Console.WriteLine("3. Back to Main Lobby");

            char choice;

            do
            {
                Console.CursorVisible = false;
                choice = Console.ReadKey(true).KeyChar;

                switch (choice)
                {
                    case '1':
                        ChangeBackgroundMusic();
                        break;
                    case '2':
                        ToggleMusic();
                        ShowSettingsMenu();
                        break;
                    case '3':
                        Program.MainLobby();
                        break;
                    default:
                        CommonUtilities.FlickerVanishMessage("Invalid Option. Please try again.", 44, 15);
                        break;
                }
            } while (choice != '1');
        }

        public static void GameSettingsText()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(
@"███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                              █▀▀░█▀█░█▀█░█▀▀░█▀█░█░░░█▀▀░░░█▀█░█▀▄░█▀▀░█▀█░█▀▄░█▀▀
                             ░█░░░█░█░█░█░▀▀█░█░█░█░░░█▀▀░░░█▀█░█▀▄░█░░░█▀█░█░█░█▀▀
                             ░▀▀▀░▀▀▀░▀░▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░░░▀░▀░▀░▀░▀▀▀░▀░▀░▀▀░░▀▀▀

        ██████╗  █████╗ ███╗   ███╗███████╗    ███████╗███████╗████████╗████████╗██╗███╗   ██╗ ██████╗ ███████╗
       ██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔════╝██╔════╝╚══██╔══╝╚══██╔══╝██║████╗  ██║██╔════╝ ██╔════╝
       ██║  ███╗███████║██╔████╔██║█████╗      ███████╗█████╗     ██║      ██║   ██║██╔██╗ ██║██║  ███╗███████╗
       ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ╚════██║██╔══╝     ██║      ██║   ██║██║╚██╗██║██║   ██║╚════██║
       ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ███████║███████╗   ██║      ██║   ██║██║ ╚████║╚██████╔╝███████║
        ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝    ╚══════╝╚══════╝   ╚═╝      ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝                                                                                                   
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████");
        }
    }
}
