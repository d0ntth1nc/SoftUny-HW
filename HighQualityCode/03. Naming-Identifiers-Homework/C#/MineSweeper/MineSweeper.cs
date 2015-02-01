using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    public class MineSweeper
    {
        private static void PrintChart(List<Rating> scores)
        {
            Console.WriteLine("\nTo4KI:");
            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, scores[i].PlayerName, scores[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void MakeTurn(char[,] gameField, char[,] bombsField, int row, int column)
        {
            char bombsCount = GetNearlyBombsCount(bombsField, row, column);
            bombsField[row, column] = bombsCount;
            gameField[row, column] = bombsCount;
        }

        private static void PrintField(char[,] gameField)
        {
            int rowsCount = gameField.GetLength(0);
            int columnsCount = gameField.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rowsCount; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < columnsCount; col++)
                {
                    Console.Write(string.Format("{0} ", gameField[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] gameField = new char[boardRows, boardColumns];
            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    gameField[row, col] = '?';
                }
            }

            return gameField;
        }

        private static char[,] CreateBombsField()
        {
            const int ROWS_COUNT = 5;
            const int COLS_COUNT = 10;

            char[,] bombsField = new char[ROWS_COUNT, COLS_COUNT];
            for (int row = 0; row < ROWS_COUNT; row++)
            {
                for (int col = 0; col < COLS_COUNT; col++)
                {
                    bombsField[row, col] = '-';
                }
            }

            List<int> randomValues = new List<int>();
            Random random = new Random();
            while (randomValues.Count < 15)
            {
                int randomVal = random.Next(50);
                if (!randomValues.Contains(randomVal))
                {
                    randomValues.Add(randomVal);
                }
            }

            foreach (int randomVal in randomValues)
            {
                int row = randomVal / COLS_COUNT;
                int col = randomVal % COLS_COUNT;
                if (col == 0 && randomVal != 0)
                {
                    row--;
                    col = COLS_COUNT;
                }
                else
                {
                    col++;
                }

                bombsField[row, col - 1] = '*';
            }

            return bombsField;
        }

        private static void InitGameField(char[,] gameField)
        {
            int rowsCount = gameField.GetLength(0);
            int colsCount = gameField.GetLength(1);

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    if (gameField[row, col] != '*')
                    {
                        char bombsCount = GetNearlyBombsCount(gameField, row, col);
                        gameField[row, col] = bombsCount;
                    }
                }
            }
        }

        private static char GetNearlyBombsCount(char[,] field, int row, int column)
        {
            int bombsCount = 0;
            int rowsCount = field.GetLength(0);
            int colsCount = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, column] == '*')
                {
                    bombsCount++;
                }
            }

            if (row + 1 < rowsCount)
            {
                if (field[row + 1, column] == '*')
                {
                    bombsCount++;
                }
            }

            if (column - 1 >= 0)
            {
                if (field[row, column - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if (column + 1 < colsCount)
            {
                if (field[row, column + 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (field[row - 1, column - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < colsCount))
            {
                if (field[row - 1, column + 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row + 1 < rowsCount) && (column - 1 >= 0))
            {
                if (field[row + 1, column - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row + 1 < rowsCount) && (column + 1 < colsCount))
            {
                if (field[row + 1, column + 1] == '*')
                {
                    bombsCount++;
                }
            }

            return char.Parse(bombsCount.ToString());
        }

        private static void Main(string[] args)
        {
            const int MAX_MOVES = 35;

            char[,] gameField = CreateGameField();
            char[,] bombsField = CreateBombsField();

            int counter = 0;
            bool hasBombBlown = false;
            List<Rating> bestPlayers = new List<Rating>(6);
            int row = 0;
            int col = 0;

            bool firstFlag = true;
            bool secondFlag = false;

            string command = String.Empty;
            do
            {
                if (firstFlag)
                {
                    Console.WriteLine(
                        "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki."
                        + " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintField(gameField);
                    firstFlag = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= gameField.GetLength(0) &&
                        col <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintChart(bestPlayers);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        bombsField = CreateBombsField();
                        PrintField(gameField);
                        hasBombBlown = false;
                        firstFlag = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombsField[row, col] != '*')
                        {
                            if (bombsField[row, col] == '-')
                            {
                                MakeTurn(gameField, bombsField, row, col);
                                counter++;
                            }

                            if (MAX_MOVES == counter)
                            {
                                secondFlag = true;
                            }
                            else
                            {
                                PrintField(gameField);
                            }
                        }
                        else
                        {
                            hasBombBlown = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (hasBombBlown)
                {
                    PrintField(bombsField);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", counter);
                    string nickName = Console.ReadLine();
                    var playerRating = new Rating(nickName, counter);
                    if (bestPlayers.Count < 5)
                    {
                        bestPlayers.Add(playerRating);
                    }
                    else
                    {
                        for (int i = 0; i < bestPlayers.Count; i++)
                        {
                            if (bestPlayers[i].Score < playerRating.Score)
                            {
                                bestPlayers.Insert(i, playerRating);
                                bestPlayers.RemoveAt(bestPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    bestPlayers.Sort((rating1, rating2) => rating2.PlayerName.CompareTo(rating1.PlayerName));
                    bestPlayers.Sort((rating1, rating2) => rating2.Score.CompareTo(rating1.Score));
                    PrintChart(bestPlayers);

                    gameField = CreateGameField();
                    bombsField = CreateBombsField();
                    counter = 0;
                    hasBombBlown = false;
                    firstFlag = true;
                }

                if (secondFlag)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintField(bombsField);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string nickName = Console.ReadLine();
                    var rating = new Rating(nickName, counter);
                    bestPlayers.Add(rating);
                    PrintChart(bestPlayers);
                    gameField = CreateGameField();
                    bombsField = CreateBombsField();
                    counter = 0;
                    secondFlag = false;
                    firstFlag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }
    }
}