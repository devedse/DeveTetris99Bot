using System.Collections.Generic;

namespace DeveTetris99Bot.Tetris.Logic
{
    public class BestMoveFinder
    {
        private readonly Evaluator evaluator;
        private readonly int depthLimit;

        public BestMoveFinder(int depthLimit)
        {
            evaluator = new Evaluator();
            this.depthLimit = depthLimit;
        }

        public ColumnAndOrientationOrStash FindBestMove(GameState gameState, TetriminoWithPosition tetriminoWithPosition, bool stashAllowed)
        {
            TetrisAction bestAction = FindBestAction(gameState.Board, gameState.TetriminoInStash, stashAllowed, tetriminoWithPosition.Tetrimino, gameState.NextTetriminoes, 0).Action;

            if (bestAction == null)
            {
                return null;
            }
            if (bestAction.Stash)
            {
                return new ColumnAndOrientationOrStash(true);
            }
            else
            {
                Tetrimino tetrimino = tetriminoWithPosition.Tetrimino;
                for (int i = 0; i < bestAction.CwRotationCnt; i++)
                {
                    tetrimino = tetrimino.RotateCW();
                }
                return new ColumnAndOrientationOrStash(bestAction.NewLeftCol, tetrimino);
            }
        }

        public TetrisActionWithEvaluation FindBestAction(Board board, Tetrimino tetrimino)
        {
            return FindBestAction(board, null, true, tetrimino, new List<Tetrimino>() , 0);
        }

        public TetrisActionWithEvaluation FindBestAction(Board board, Tetrimino tetriminoInStash, bool stashAllowed, Tetrimino tetrimino, List<Tetrimino> tetriminoes, int nextPosition)
        {
            return FindBestAction(board, tetriminoInStash, stashAllowed, tetrimino, tetriminoes, nextPosition, new List<int>(), 0);
        }



        public TetrisActionWithEvaluation FindBestAction(Board board, Tetrimino tetriminoInStash, bool stashAllowed, Tetrimino fallingTetrimino, List<Tetrimino> nextTetriminoes, int nextPosition, List<int> linesCleared, int depth)
        {
            EvaluationState bestState = null;
            TetrisAction bestAction = null;

            Tetrimino originalTetrimino = fallingTetrimino;
            for (int rotateCnt = 0; rotateCnt < 4; rotateCnt++)
            {
                for (int newLeftCol = 0; newLeftCol + fallingTetrimino.Width - 1 < board.Width; newLeftCol++)
                {
                    DropResult dropResult = board.drop(fallingTetrimino, newLeftCol);
                    if (dropResult == null)
                    {
                        continue;
                    }
                    Board newBoard = dropResult.Board;
                    linesCleared.Add(dropResult.LinesCleared);

                    EvaluationState curState;

                    if (nextPosition == nextTetriminoes.Count || depth == depthLimit)
                    {
                        bool lineInStash = tetriminoInStash != null && (tetriminoInStash.Width == 4 || tetriminoInStash.Height == 4);
                        curState = evaluator.GetEvaluation(newBoard, linesCleared, lineInStash);
                    }
                    else
                    {
                        curState = FindBestAction(newBoard, tetriminoInStash, true, nextTetriminoes[nextPosition], nextTetriminoes, nextPosition + 1, linesCleared, depth + 1).EvaluationState;
                    }
                    if (curState != null && curState.better(bestState))
                    {
                        bestState = curState;
                        bestAction = new TetrisAction(newLeftCol, rotateCnt);
                    }
                    linesCleared.RemoveAt(linesCleared.Count - 1);
                }
                fallingTetrimino = fallingTetrimino.RotateCW();
                if (fallingTetrimino.Equals(originalTetrimino))
                {
                    break;
                }
            }
            if (stashAllowed && (tetriminoInStash != null || nextPosition != nextTetriminoes.Count))
            {
                if (tetriminoInStash == null)
                {
                    tetriminoInStash = fallingTetrimino;
                    fallingTetrimino = nextTetriminoes[nextPosition];
                    nextPosition++;
                }
                else
                {
                    Tetrimino oldTetriminoInStash = tetriminoInStash;
                    tetriminoInStash = fallingTetrimino;
                    fallingTetrimino = oldTetriminoInStash;
                }

                EvaluationState curState = FindBestAction(board, tetriminoInStash, false, fallingTetrimino, nextTetriminoes, nextPosition, linesCleared, depth).EvaluationState;
                if (curState != null && curState.better(bestState))
                {
                    bestState = curState;
                    bestAction = new TetrisAction(true);
                }
            }
            return new TetrisActionWithEvaluation(bestAction, bestState);
        }

    }
}
