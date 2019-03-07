namespace DeveTetris99Bot.Tetris.Logic
{
    public class TetrisAction
    {
        public bool Stash { get; }
        public int NewLeftCol { get; }
        public int CwRotationCnt { get; }

        public TetrisAction(int newLeftCol, int cwRotationCnt)
        {
            Stash = false;
            NewLeftCol = newLeftCol;
            CwRotationCnt = cwRotationCnt;
        }

        public TetrisAction(bool stash)
        {
            Stash = stash;
            NewLeftCol = -1;
            CwRotationCnt = -1;
        }

        public override string ToString()
        {
            return $"Action(Stash={Stash},NewLeftCol={NewLeftCol},CwRotationCnt={CwRotationCnt})";
        }
    }
}
