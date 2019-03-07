using System.Text;

namespace DeveTetris99Bot.Tetris
{
    public class Tetrimino
    {
        public static Tetrimino T { get; } = new Tetrimino(".x.\n" + "xxx");
        public static Tetrimino O { get; } = new Tetrimino("xx\n" + "xx");
        public static Tetrimino J { get; } = new Tetrimino("x..\n" + "xxx");
        public static Tetrimino S { get; } = new Tetrimino(".xx\n" + "xx.");
        public static Tetrimino I { get; } = new Tetrimino("xxxx");
        public static Tetrimino Z { get; } = new Tetrimino("xx.\n" + ".xx");
        public static Tetrimino L { get; } = new Tetrimino("..x\n" + "xxx");


        public bool[,] TetriminoArray { get; }

        public int Height => TetriminoArray.GetLength(0);
        public int Width => TetriminoArray.GetLength(1);

        public Tetrimino(bool[,] tetriminoArray)
        {
            TetriminoArray = tetriminoArray;
        }

        public Tetrimino(string s)
        {
            string[] splitted = s.Split('\n');
            TetriminoArray = new bool[splitted.Length, splitted[0].Length];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    TetriminoArray[y, x] = splitted[y][x] == 'x';
                }
            }
        }

        public Tetrimino RotateCW()
        {
            bool[,] newB = new bool[Width, Height];

            for (int newY = 0; newY < Width; newY++)
            {
                for (int newX = 0; newX < Height; newX++)
                {
                    newB[newY, newX] = TetriminoArray[Height - newX - 1, newY];
                }
            }
            return new Tetrimino(newB);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (TetriminoArray[y, x])
                    {
                        sb.Append('x');
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            var other = obj as Tetrimino;

            if (other == null)
            {
                return false;
            }


            if (Width != other.Width || Height != other.Height)
            {
                return false;
            }

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (TetriminoArray[y, x] != other.TetriminoArray[y, x])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
