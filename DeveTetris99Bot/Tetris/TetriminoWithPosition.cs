namespace DeveTetris99Bot.Tetris
{
    public class TetriminoWithPosition
    {
        public Tetrimino Tetrimino { get; set; }
        public int TopRow { get; set; }
        public int LeftCol { get; set; }

        public TetriminoWithPosition(Tetrimino tetrimino, int topRow, int leftCol)
        {
            Tetrimino = tetrimino;
            TopRow = topRow;
            LeftCol = leftCol;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            var other = obj as TetriminoWithPosition;

            if (other == null)
            {
                return false;
            }

            if (LeftCol != other.LeftCol || TopRow != other.TopRow || !Tetrimino.Equals(other.Tetrimino))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int result = TopRow;
            result = 31 * result + LeftCol;
            result = 31 * result + Tetrimino.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            return $"TetriminoWithPosition(TopRow={TopRow},LeftCol={LeftCol},Tetrimino={Tetrimino})";
        }
    }
}
