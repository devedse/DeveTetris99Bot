using System;
using System.Text;

namespace DeveTetris99Bot.Tetris
{
    public class Board
    {
        public int Width { get; }
        public int Height { get; }
        public bool[,] BoardArray { get; }
        public int Penalty { get; set; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            BoardArray = new bool[height, width];
        }

        public Board(Board board)
        {
            Width = board.Width;
            Height = board.Height;
            BoardArray = new bool[Height, Width];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    BoardArray[y, x] = board.BoardArray[y, x];
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (BoardArray[y, x])
                    {
                        if (y >= Height - Penalty)
                        {
                            sb.Append('0');
                        }
                        else
                        {
                            sb.Append('x');
                        }
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public TetriminoWithPosition ExtractFallingTetrimino()
        {
            int cnt = 0;
            int topRow = 999;
            int leftCol = 999;
            int bottomRow = 0;
            int rightCol = 0;

        fori:

            for (int i = 0; i < Height / 2; i++)
            {
                bool foundOnLine = false;
                for (int j = 0; j < Width; j++)
                {
                    if (BoardArray[i, j])
                    {
                        foundOnLine = true;
                        cnt++;
                        topRow = Math.Min(topRow, i);
                        leftCol = Math.Min(leftCol, j);
                        bottomRow = Math.Max(bottomRow, i);
                        rightCol = Math.Max(rightCol, j);
                        if (cnt == 4)
                        {
                            goto fori;
                        }
                    }
                }
                if (cnt > 0 && !foundOnLine)
                {
                    return null;
                }
            }
            if (cnt != 4)
            {
                return null;
            }
            bool[,] b = new bool[bottomRow - topRow + 1, rightCol - leftCol + 1];
            for (int i = topRow; i <= bottomRow; i++)
            {
                for (int j = leftCol; j <= rightCol; j++)
                {
                    b[i - topRow, j - leftCol] = BoardArray[i, j];
                    BoardArray[i, j] = false;
                }
            }
            return new TetriminoWithPosition(new Tetrimino(b), topRow, leftCol);
        }


        public DropResult drop(Tetrimino tetrimino, int leftCol)
        {
            int minNewTopTetriminoRow = 999;
            for (int x = 0; x < tetrimino.Width; x++)
            {
                int tetriminoBottomRow = 0;
                for (int y = tetrimino.Height - 1; y >= 0; y--)
                {
                    if (tetrimino.TetriminoArray[y, x])
                    {
                        tetriminoBottomRow = y;
                        break;
                    }
                }
                int curCol = leftCol + x;

                int boardTopRow = GetTopRowInColumn(curCol);
                int newTopTetriminoRow = boardTopRow - tetriminoBottomRow - 1;
                minNewTopTetriminoRow = Math.Min(minNewTopTetriminoRow, newTopTetriminoRow);
            }

            Board r = new Board(this);
            for (int i = 0; i < tetrimino.Height; i++)
            {
                for (int j = 0; j < tetrimino.Width; j++)
                {
                    if (tetrimino.TetriminoArray[i, j])
                    {
                        if (minNewTopTetriminoRow + i < 0)
                        {
                            return null;
                        }
                        r.BoardArray[minNewTopTetriminoRow + i, leftCol + j] = true;
                    }
                }
            }
            r.Penalty = Penalty;
            int linesCleared = r.ClearFullRows();
            return new DropResult(r, linesCleared);
        }

        public int GetTopRowInColumn(int col)
        {
            int boardTopRow = Height; // if empty column
            for (int i = 0; i < Height; i++)
            {
                if (BoardArray[i, col])
                {
                    boardTopRow = i;
                    break;
                }
            }
            return boardTopRow;
        }

        private int ClearFullRows()
        {
            bool[] full = new bool[Height];
            int linesCleared = 0;
            for (int y = 0; y < Height - Penalty; y++)
            {
                full[y] = true;
                for (int x = 0; x < Width; x++)
                {
                    if (!BoardArray[y, x])
                    {
                        full[y] = false;
                        break;
                    }
                }
                if (full[y])
                {
                    linesCleared++;
                }
            }
            for (int col = 0; col < Width; col++)
            {
                int botRow = Height - 1;
                for (int row = Height - 1; row >= 0; row--)
                {
                    if (!full[row])
                    {
                        BoardArray[botRow, col] = BoardArray[row, col];
                        botRow--;
                    }
                }
                while (botRow >= 0)
                {
                    BoardArray[botRow, col] = false;
                    botRow--;
                }
            }
            return linesCleared;
        }

        public int GetColumnHeight(int col)
        {
            return Height - GetTopRowInColumn(col);
        }
    }
}
