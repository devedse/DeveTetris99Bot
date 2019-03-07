namespace DeveTetris99Bot.Tetris
{
    public class DropResult
    {
        public Board Board { get; }
        public int LinesCleared { get; }

        public DropResult(Board board, int linesCleared)
        {
            Board = board;
            LinesCleared = linesCleared;
        }
    }
}
