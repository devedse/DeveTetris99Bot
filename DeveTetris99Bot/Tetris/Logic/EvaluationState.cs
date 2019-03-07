namespace DeveTetris99Bot.Tetris.Logic
{
    public class EvaluationState
    {
        private readonly int badCnt;
        private readonly int flatRate;
        private readonly int nonTetrisLinesCleared;
        private readonly int tetrisLinesCleared;
        private readonly int lastColumnHeight;
        private readonly int holeCnt;
        private readonly bool virtualHole;
        private readonly bool tooHigh;
        private readonly bool lineInStash;

        public EvaluationState(int badCnt, int flatRate, int nonTetrisLinesCleared, int tetrisLinesCleared, int lastColumnHeight, int holeCnt, bool virtualHole, bool tooHigh, bool lineInStash)
        {
            this.badCnt = badCnt;
            this.flatRate = flatRate;
            this.nonTetrisLinesCleared = nonTetrisLinesCleared;
            this.tetrisLinesCleared = tetrisLinesCleared;
            this.lastColumnHeight = lastColumnHeight;
            this.holeCnt = holeCnt;
            this.virtualHole = virtualHole;
            this.tooHigh = tooHigh;
            this.lineInStash = lineInStash;
        }

        public bool better(EvaluationState st)
        {
            if (st == null)
            {
                return true;
            }
            if (tooHigh != st.tooHigh)
            {
                return !tooHigh;
            }
            if (badCnt != st.badCnt)
            {
                return badCnt < st.badCnt;
            }
            if (tetrisLinesCleared != st.tetrisLinesCleared)
            {
                return tetrisLinesCleared > st.tetrisLinesCleared;
            }

            if (holeCnt != st.holeCnt)
            {
                return holeCnt < st.holeCnt;
            }

            if (badCnt == 0 && holeCnt == 0)
            {
                if (lastColumnHeight != st.lastColumnHeight)
                {
                    return lastColumnHeight < st.lastColumnHeight;
                }
                if (lastColumnHeight == 0)
                {
                    if (virtualHole != st.virtualHole)
                    {
                        return !virtualHole;
                    }
                    if (nonTetrisLinesCleared != st.nonTetrisLinesCleared)
                    {
                        return nonTetrisLinesCleared < st.nonTetrisLinesCleared;
                    }
                }
            }
            if (lineInStash != st.lineInStash)
            {
                return lineInStash;
            }
            if (flatRate != st.flatRate)
            {
                return flatRate < st.flatRate;
            }
            return false;
        }

        public override string ToString()
        {
            return $"EvaluationState(badCnt={badCnt},flatRate={flatRate},nonTetrisLinesCleared={nonTetrisLinesCleared})";
        }
    }
}
