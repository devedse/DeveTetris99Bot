using System;
using System.Collections.Generic;

namespace DeveTetris99Bot.Tetris.Logic
{
    public class Evaluator
    {
        public static int MaxHeight = 4;

        public EvaluationState GetEvaluation(Board board, List<int> linesCleared, bool lineInStash)
        {
            int badCnt = 0;
            int w = board.Width;
            for (int col = 0; col < w; col++)
            {
                bool found = false;
                for (int row = 0; row < board.Height; row++)
                {
                    if (board.BoardArray[row, col])
                    {
                        found = true;
                    }
                    else
                    {
                        if (found)
                        {
                            badCnt++;
                        }
                    }
                }
            }
            int flatRate = 0;
            for (int i = 0; i < w - 2; i++)
            {
                int diff = Math.Abs(board.GetTopRowInColumn(i) - board.GetTopRowInColumn(i + 1));
                flatRate += diff;
            }
            int holeCnt = 0;
            for (int i = 0; i < w - 1; i++)
            {
                int left = i == 0 ? 999 : board.GetColumnHeight(i - 1);
                int mid = board.GetColumnHeight(i);
                int right = board.GetColumnHeight(i + 1);
                if (mid < Math.Min(left, right) - 2)
                {
                    holeCnt++;
                }
            }
            bool virtualHole = board.GetColumnHeight(w - 2) < board.GetColumnHeight(w - 3) - 2;
            int nonTetrisLinesCleared = 0;
            int tetrisLinesCleared = 0;
            foreach (var v in linesCleared)
            {
                if (v != 0 && v != 4)
                {
                    nonTetrisLinesCleared++;
                }
                else if (v == 4)
                {
                    tetrisLinesCleared++;
                }
            }
            int lastColumnHeight = board.GetColumnHeight(w - 1);
            int maxColumnHeight = 0;
            for (int i = 0; i < w; i++)
            {
                maxColumnHeight = Math.Max(maxColumnHeight, board.GetColumnHeight(i));
            }
            return new EvaluationState(badCnt, flatRate, nonTetrisLinesCleared, tetrisLinesCleared, lastColumnHeight, holeCnt, virtualHole, maxColumnHeight > board.Height - MaxHeight, lineInStash);

        }
    }
}
