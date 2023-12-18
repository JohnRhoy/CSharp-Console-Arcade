using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static CSharp_Console_Arcade.T2048Game.Direction;

namespace CSharp_Console_Arcade
{
    public class T2048Game
    {

        public static void StartScreen2048()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(
@"22222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
20                                                                                                                   48
20                222222222222222         000000000            444444444       888888888                             48
20               2:::::::::::::::22     00:::::::::00         4::::::::4     88:::::::::88                           48
20               2::::::222222:::::2  00:::::::::::::00      4:::::::::4   88:::::::::::::88                         48
20               2222222     2:::::2 0:::::::000:::::::0    4::::44::::4  8::::::88888::::::8                        48
20                           2:::::2 0::::::0   0::::::0   4::::4 4::::4  8:::::8     8:::::8                        48
20                           2:::::2 0:::::0     0:::::0  4::::4  4::::4  8:::::8     8:::::8                        48
20                        2222::::2  0:::::0     0:::::0 4::::4   4::::4   8:::::88888:::::8                         48
20                   22222::::::22   0:::::0 000 0:::::04::::444444::::444  8:::::::::::::8                          48
20                 22::::::::222     0:::::0 000 0:::::04::::::::::::::::4 8:::::88888:::::8                         48
20                2:::::22222        0:::::0     0:::::04444444444:::::4448:::::8     8:::::8                        48
20               2:::::2             0:::::0     0:::::0          4::::4  8:::::8     8:::::8                        48
20               2:::::2             0::::::0   0::::::0          4::::4  8:::::8     8:::::8                        48
20               2:::::2       2222220:::::::000:::::::0          4::::4  8::::::88888::::::8                        48
20               2::::::2222222:::::2 00:::::::::::::00         44::::::44 88:::::::::::::88                         48
20               2::::::::::::::::::2   00:::::::::00           4::::::::4   88:::::::::88                           48
20               22222222222222222222     000000000             4444444444     888888888                             48
20                                                                                                                   48
44444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444
88888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
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
                T2048();
            }
            else if (choice == 'M')
            {
                Program.MainLobby();
            }
            else
            {
                CommonUtilities.RainbowFlickerMessage("Press 'S' to start the game or 'M' to return to the main lobby...", 26, 26);
                StartScreen2048();
            }
        }

        public static void T2048Instructions()
        {
            T2048Text();

            Console.SetCursorPosition(42, 8);
            foreach (char c in "Welcome to the classic game of 2048!!")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(32, 9);
            foreach (char c in "Use arrow keys (Up, Down, Left, Right) to move the tiles.") 
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(36, 10);
            foreach (char c in "Tiles with the same number merge when they touch.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(42, 11);
            foreach (char c in "Your goal is to reach the 2048 tile.")
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(39, 12);
            foreach (char c in "The game ends when no valid moves are left.")
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

        public static void T2048Text()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(
@"███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                                                  ░▀▀▄░▄▀▄░█░█░▄▀▄
                                                  ░▄▀░░█/█░░▀█░▄▀▄
                                                  ░▀▀▀░░▀░░░░▀░░▀░
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████");
        }

        public static void T2048()
        {
            T2048Instructions();
            ConsoleColor[] Colors =
            {
    ConsoleColor.DarkBlue,
    ConsoleColor.DarkGreen,
    ConsoleColor.DarkCyan,
    ConsoleColor.DarkRed,
    ConsoleColor.DarkMagenta,
    ConsoleColor.DarkYellow,
    ConsoleColor.Blue,
    ConsoleColor.Red,
    ConsoleColor.Magenta,
            };

            try
            {
                Console.CursorVisible = false;

                int gridSize = ChooseGridSize();

                while (true)
                {
                NewBoard:
                    T2048Text();
                    int?[,] board = new int?[gridSize, gridSize];
                    int score = 0;
                    while (true)
                    {
                        bool IsNull((int X, int Y) point) => board[point.X, point.Y] is null;
                        int nullCount = BoardValues(board).Count(IsNull);
                        if (nullCount is 0)
                        {
                            goto GameOver;
                        }
                        int index = Random.Shared.Next(0, nullCount);
                        var (x, y) = BoardValues(board).Where(IsNull).ElementAt(index);
                        board[x, y] = Random.Shared.Next(10) < 9 ? 2 : 4;
                        score += 2;

                        if (!TryUpdate((int?[,])board.Clone(), ref score, Up) &&
                            !TryUpdate((int?[,])board.Clone(), ref score, Down) &&
                            !TryUpdate((int?[,])board.Clone(), ref score, Left) &&
                            !TryUpdate((int?[,])board.Clone(), ref score, Right))
                        {
                            goto GameOver;
                        }

                        Render(board, score);
                        Direction direction;
                    GetDirection:
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.UpArrow: direction = Up; break;
                            case ConsoleKey.DownArrow: direction = Down; break;
                            case ConsoleKey.LeftArrow: direction = Left; break;
                            case ConsoleKey.RightArrow: direction = Right; break;
                            case ConsoleKey.End: goto NewBoard;
                            case ConsoleKey.Escape: goto Close;
                            default: goto GetDirection;
                        }
                        if (!TryUpdate(board, ref score, direction))
                        {
                            goto GetDirection;
                        }
                    }
                GameOver:
                    Render(board, score);
                    Console.SetCursorPosition(54, 23);
                    Console.WriteLine("Game Over...");
                    Console.SetCursorPosition(25, 24);
                    Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                       Press [Enter] to play again or [Escape] to return to the main lobby...                        ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
");
                    
                GetInput:
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter: goto NewBoard;
                        case ConsoleKey.Escape: goto Close;
                        default: CommonUtilities.RainbowFlickerMessage("Press [Enter] to play again or [Escape] to return to the main lobby...", 24, 26); goto GetInput;
                    }
                }
            Close:
                Program.MainLobby();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Thread.Sleep(2000);
                Program.MainLobby();
            }

            bool TryUpdate(int?[,] board, ref int score, Direction direction)
            {
                (int X, int Y) Adjacent(int x, int y) =>
                    direction switch
                    {
                        Up => (x + 1, y),
                        Down => (x - 1, y),
                        Left => (x, y - 1),
                        Right => (x, y + 1),
                        _ => throw new NotImplementedException(),
                    };

                (int X, int Y) Map(int x, int y) =>
                    direction switch
                    {
                        Up => (board.GetLength(0) - x - 1, y),
                        Down => (x, y),
                        Left => (x, y),
                        Right => (x, board.GetLength(1) - y - 1),
                        _ => throw new NotImplementedException(),
                    };

                bool[,] locked = new bool[board.GetLength(0), board.GetLength(1)];

                bool update = false;

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        var (tempi, tempj) = Map(i, j);
                        if (board[tempi, tempj] is null)
                        {
                            continue;
                        }
                    KeepChecking:
                        var (adji, adjj) = Adjacent(tempi, tempj);
                        if (adji < 0 || adji >= board.GetLength(0) ||
                            adjj < 0 || adjj >= board.GetLength(1) ||
                            locked[adji, adjj])
                        {
                            continue;
                        }
                        else if (board[adji, adjj] is null)
                        {
                            board[adji, adjj] = board[tempi, tempj];
                            board[tempi, tempj] = null;
                            update = true;
                            tempi = adji;
                            tempj = adjj;
                            goto KeepChecking;
                        }
                        else if (board[adji, adjj] == board[tempi, tempj])
                        {
                            board[adji, adjj] += board[tempi, tempj];
                            score += board[adji, adjj]!.Value;
                            board[tempi, tempj] = null;
                            update = true;
                            locked[adji, adjj] = true;
                        }
                    }
                }
                return update;
            }

            IEnumerable<(int, int)> BoardValues(int?[,] board)
            {
                for (int i = board.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        yield return (i, j);
                    }
                }
            }

            ConsoleColor GetColor(int? value) =>
                    value is null
                        ? ConsoleColor.DarkGray
                        : Colors[(value.Value / 2 - 1) % Colors.Length];

            void Render(int?[,] board, int score)
            {
                int horizontal = board.GetLength(0) * 8;
                string horizontalBar = new('═', horizontal);
                string horizontalSpace = new(' ', horizontal);

                int boardStartX = (120 - horizontal) / 2;
                int boardStartY = (30 - (board.GetLength(1) * 2 + 5)) / 2;

                Console.SetCursorPosition(boardStartX, boardStartY);
                Console.SetCursorPosition(boardStartX, 10);
                Console.WriteLine($"╔{horizontalBar}╗");
                Console.SetCursorPosition(boardStartX, Console.CursorTop);
                Console.WriteLine($"║{horizontalSpace}║");

                for (int i = board.GetLength(1) - 1; i >= 0; i--)
                {
                    Console.SetCursorPosition(boardStartX, Console.CursorTop);
                    Console.Write("║");

                    for (int j = 0; j < board.GetLength(0); j++)
                    {
                        Console.Write("  ");
                        ConsoleColor background = Console.BackgroundColor;
                        Console.BackgroundColor = GetColor(board[i, j]);
                        Console.Write(string.Format("{0,4}", board[i, j]));
                        Console.BackgroundColor = background;
                        Console.Write("  ");
                    }

                    Console.WriteLine("║");
                    Console.SetCursorPosition(boardStartX, Console.CursorTop);
                    Console.WriteLine($"║{horizontalSpace}║");
                }

                Console.SetCursorPosition(boardStartX, Console.CursorTop);
                Console.WriteLine($"╚{horizontalBar}╝");
                Console.SetCursorPosition(55, 8);
                Console.WriteLine($"Score: {score}");
            }
        }

        private static int ChooseGridSize()
        {
            T2048Text();
            Console.SetCursorPosition(0, 9);
            Console.WriteLine(
@"╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
║                                              Choose The Grid Size:                                                  ║
║                                                                                                                     ║
║                                                    [1] 4 x 4                                                        ║
║                                                    [2] 5 x 5                                                        ║
║                                                    [3] 6 x 6                                                        ║
║                                                                                                                     ║
║█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
");

            int gridSize;
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        gridSize = 4;
                        break;
                    case ConsoleKey.D2:
                        gridSize = 5;
                        break;
                    case ConsoleKey.D3:
                        gridSize = 6;
                        break;
                    default:
                        CommonUtilities.FlickerVanishMessage("Please choose a valid Grid Size", 45, 8);
                        continue;
                }
                break;
            } while (true);

            return gridSize;
        }

        public enum Direction
{
            Up = 1,
            Down = 2,
            Left = 3,
            Right = 4,
        }
    }
}
