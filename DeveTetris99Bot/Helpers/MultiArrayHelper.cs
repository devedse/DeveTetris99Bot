using DeveTetris99Bot.Tetris;

namespace DeveTetris99Bot.Helpers
{
    public static class MultiArrayHelper
    {
        public static bool IsValidTetrino(bool[,] input)
        {
            foreach (var tet in Tetrimino.All)
            {
                if (AreEqual(input, tet))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool AreEqual(bool[,] input, Tetrimino tet)
        {
            if (tet.RotateableArray.GetLength(1) != input.GetLength(1) || tet.RotateableArray.GetLength(0) != input.GetLength(0))
            {
                return false;
            }

            for (int y = 0; y < tet.Height; y++)
            {
                for (int x = 0; x < tet.Width; x++)
                {
                    if (input[y, x] != tet.RotateableArray[y, x])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool AllInColumnFalse(bool[,] array, int column)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, column] == true)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AllInRowFalse(bool[,] array, int row)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                if (array[row, i] == true)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool[,] TrimArray(int rowToRemove, int columnToRemove, bool[,] originalArray)
        {
            bool[,] result = new bool[originalArray.GetLength(0) - 1, originalArray.GetLength(1) - 1];

            for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
            {
                if (i == rowToRemove)
                {
                    continue;
                }

                for (int k = 0, u = 0; k < originalArray.GetLength(1); k++)
                {
                    if (k == columnToRemove)
                    {
                        continue;
                    }

                    result[j, u] = originalArray[i, k];
                    u++;
                }
                j++;
            }

            return result;
        }

        public static bool[,] TrimColumn(int columnToRemove, bool[,] originalArray)
        {
            bool[,] result = new bool[originalArray.GetLength(0), originalArray.GetLength(1) - 1];

            for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
            {

                for (int k = 0, u = 0; k < originalArray.GetLength(1); k++)
                {
                    if (k == columnToRemove)
                    {
                        continue;
                    }

                    result[j, u] = originalArray[i, k];
                    u++;
                }
                j++;
            }

            return result;
        }

        public static bool[,] TrimRow(int rowToRemove, bool[,] originalArray)
        {
            bool[,] result = new bool[originalArray.GetLength(0) - 1, originalArray.GetLength(1)];

            for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
            {
                if (i == rowToRemove)
                {
                    continue;
                }

                for (int k = 0, u = 0; k < originalArray.GetLength(1); k++)
                {
                    result[j, u] = originalArray[i, k];
                    u++;
                }
                j++;
            }

            return result;
        }
    }
}
