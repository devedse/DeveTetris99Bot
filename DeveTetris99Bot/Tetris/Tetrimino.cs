using DeveTetris99Bot.Helpers;
using System.Text;

namespace DeveTetris99Bot.Tetris
{
    public class Tetrimino
    {
        public static Tetrimino T { get; } = new Tetrimino(".x.\n" + "xxx\n" + "...");
        public static Tetrimino O { get; } = new Tetrimino("xx\n" + "xx");
        public static Tetrimino J { get; } = new Tetrimino("x..\n" + "xxx\n" + "...");
        public static Tetrimino S { get; } = new Tetrimino(".xx\n" + "xx.\n" + "...");
        public static Tetrimino I { get; } = new Tetrimino("....\n" + "xxxx\n" + "....\n" + "....");
        public static Tetrimino Z { get; } = new Tetrimino("xx.\n" + ".xx\n" + "...");
        public static Tetrimino L { get; } = new Tetrimino("..x\n" + "xxx\n" + "...");

        public static Tetrimino[] All { get; } = new Tetrimino[] { T, O, J, S, I, Z, L };

        public bool[,] RotateableArray { get; }
        public bool[,] TetriminoArray { get; private set; }

        public int DeductedLeftRows { get; private set; }

        public int Height => TetriminoArray.GetLength(0);
        public int Width => TetriminoArray.GetLength(1);

        public Tetrimino(bool[,] rotateAbleArray)
        {
            RotateableArray = rotateAbleArray;
            InitTetriminoArray();
        }

        private void InitTetriminoArray()
        {
            if (RotateableArray.GetLength(0) != RotateableArray.GetLength(1))
            {
                throw new System.Exception("Rotateable array should be square");
            }

            var temp = RotateableArray;


            while (MultiArrayHelper.AllInColumnFalse(temp, 0))
            {
                temp = MultiArrayHelper.TrimColumn(0, temp);
                DeductedLeftRows++;
            }

            while (MultiArrayHelper.AllInRowFalse(temp, 0))
            {
                temp = MultiArrayHelper.TrimRow(0, temp);
            }

            while (MultiArrayHelper.AllInColumnFalse(temp, temp.GetLength(1) - 1))
            {
                temp = MultiArrayHelper.TrimColumn(temp.GetLength(1) - 1, temp);
            }

            while (MultiArrayHelper.AllInRowFalse(temp, temp.GetLength(0) - 1))
            {
                temp = MultiArrayHelper.TrimRow(temp.GetLength(0) - 1, temp);
            }

            TetriminoArray = temp;
        }



        public Tetrimino(string s)
        {
            string[] splitted = s.Split('\n');
            var tetriminoArray = new bool[splitted.Length, splitted[0].Length];
            for (int y = 0; y < splitted.Length; y++)
            {
                for (int x = 0; x < splitted[0].Length; x++)
                {
                    tetriminoArray[y, x] = splitted[y][x] == 'x';
                }
            }
            RotateableArray = tetriminoArray;
            InitTetriminoArray();
        }

        public Tetrimino RotateCW()
        {
            //bool[,] newB = new bool[Width, Height];

            //for (int newY = 0; newY < Width; newY++)
            //{
            //    for (int newX = 0; newX < Height; newX++)
            //    {
            //        newB[newY, newX] = TetriminoArray[Height - newX - 1, newY];
            //    }
            //}
            //return new Tetrimino(newB);

            int heightHere = RotateableArray.GetLength(0);
            int widthHere = RotateableArray.GetLength(1);

            bool[,] newB = new bool[widthHere, heightHere];

            for (int newY = 0; newY < widthHere; newY++)
            {
                for (int newX = 0; newX < heightHere; newX++)
                {
                    newB[newY, newX] = RotateableArray[heightHere - newX - 1, newY];
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

        public string ToStringRotateable()
        {
            var sb = new StringBuilder();

            for (int y = 0; y < RotateableArray.GetLength(0); y++)
            {
                for (int x = 0; x < RotateableArray.GetLength(1); x++)
                {
                    if (RotateableArray[y, x])
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
