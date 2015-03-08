using System;

namespace RotatingWalkInMatrix
{
    public class RotatingWalkInMatrix
    {
        private static readonly Position StartPosition = new Position(0, 0);
        private static readonly Direction[] Directions = new Direction[]
        {
            new Direction(1, 1), // Top left to bottom right
            new Direction(1, 0), // Top to bottom
            new Direction(1, -1), // Top right to bottom left
            new Direction(0, -1), // Right to left
            new Direction(-1, -1), // Bottom right to top left
            new Direction(-1, 0), // Bottom to top
            new Direction(-1, 1), // Bottom left to top right
            new Direction(0, 1), // Left to right
        };

        public static void RotateWalkInMatrix(int[,] matrix)
        {
            var currentPosition = StartPosition;
            int currentDirection = 0;

            for (int step = 1; step <= matrix.GetLength(0) * matrix.GetLength(1); step++)
            {
                matrix[currentPosition.Y, currentPosition.X] = step;

                Position nextPosition = null;
                int nextDirection = currentDirection;

                // Check all 8 directions
                for (int i = 0; i < Directions.Length; i++, nextDirection++)
                {
                    if (nextDirection == Directions.Length)
                    {
                        nextDirection = 0;
                    }

                    int nextYPos = currentPosition.Y + Directions[nextDirection].Y;
                    int nextXPos = currentPosition.X + Directions[nextDirection].X;
                    bool canMoveTo =
                        nextYPos >= 0 && nextYPos < matrix.GetLength(0) &&
                        nextXPos >= 0 && nextXPos < matrix.GetLength(1) &&
                        matrix[nextYPos, nextXPos] == 0;

                    if (canMoveTo)
                    {
                        nextPosition = new Position(nextYPos, nextXPos);
                        currentDirection = nextDirection;
                        break;
                    }
                }

                if (nextPosition == null)
                {
                    currentPosition = FindMostTopLeftEmptyCell(matrix);
                    currentDirection = 0;
                }
                else
                {
                    currentPosition = nextPosition;
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static Position FindMostTopLeftEmptyCell(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        return new Position(row, col);
                    }
                }
            }

            return null;
        }

        private static void Main(string[] args)
        {
            int matrixSize = 0;
            do
            {
                Console.Write("Enter matrix size [1...100]: ");
                int selectedSize = int.Parse(Console.ReadLine());

                if (selectedSize >= 1 && selectedSize <= 100)
                {
                    matrixSize = selectedSize;
                }
                else
                {
                    Console.WriteLine("Please enter number between 1 and 100 inclusive!");
                }
            } while (matrixSize == 0);

            int[,] matrix = new int[matrixSize, matrixSize];
            RotateWalkInMatrix(matrix);
            PrintMatrix(matrix);
        }
    }
}