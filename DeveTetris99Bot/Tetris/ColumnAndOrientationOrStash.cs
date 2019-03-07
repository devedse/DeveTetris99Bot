namespace DeveTetris99Bot.Tetris
{
    public class ColumnAndOrientationOrStash
    {
        public bool Stash { get; }
        public int Column { get; }
        public Tetrimino Tetrimino { get; }

        public ColumnAndOrientationOrStash(int column, Tetrimino tetrimino)
        {
            Stash = false;
            Column = column;
            Tetrimino = tetrimino;
        }

        public ColumnAndOrientationOrStash(bool stash)
        {
            Stash = stash;
            Column = -1;
            Tetrimino = null;
        }

        public override string ToString()
        {
            return $"ColumnAndOrientation(Column={Column},Stash={Stash},Tetrimino={Tetrimino})";
        }
    }
}
