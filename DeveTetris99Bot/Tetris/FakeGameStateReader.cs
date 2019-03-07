using DeveTetris99Bot.Config;
using DeveTetris99Bot.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace DeveTetris99Bot.Tetris
{
    public class FakeGameState : IGameStateReader, IKeyPresser
    {
        private int cur = 0;
        private Board board;

        private List<Tetrimino> nextBlocks;
        private TetriminoWithPosition curBlockWithPos;
        private Tetrimino inStash;

        public FakeGameState()
        {
            board = new Board(TetrisConstants.BoardWidth, TetrisConstants.BoardHeight);

            RedetectBlocks();
        }

        private void RedetectBlocks()
        {
            var viableBlocks = InfinoListo().Skip(cur).Take(6).ToList();

            curBlockWithPos = new TetriminoWithPosition(viableBlocks.First(), 0, 4);
            nextBlocks = viableBlocks.Skip(1).ToList();
        }

        public GameState ReadGameState()
        {
            var gameState = new GameState(board, curBlockWithPos, nextBlocks, inStash);

            return gameState;
        }

        public void NextBlock()
        {
            cur++;
        }

        private IEnumerable<Tetrimino> InfinoListo()
        {
            while (true)
            {
                var list = Tetrimino.All.Randomize();
                foreach (var item in list)
                {
                    yield return item;
                }
            }
        }

        public void MakeMove(List<Move> moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case Move.Left:
                        curBlockWithPos.LeftCol--;
                        break;
                    case Move.Right:
                        curBlockWithPos.LeftCol++;
                        break;
                    case Move.Drop:
                        var result = board.drop(curBlockWithPos.Tetrimino, curBlockWithPos.LeftCol);
                        board = result.Board;
                        cur++;
                        RedetectBlocks();
                        break;
                    case Move.Stash:
                        var tmp = inStash;
                        inStash = curBlockWithPos.Tetrimino;
                        if (tmp == null)
                        {
                            cur++;
                            RedetectBlocks();
                        }
                        else
                        {
                            curBlockWithPos = new TetriminoWithPosition(tmp, 0, 4);
                        }
                        break;
                    case Move.Rotate_CW:
                        curBlockWithPos.Tetrimino = curBlockWithPos.Tetrimino.RotateCW();
                        break;
                    case Move.Rotate_CWW:
                        curBlockWithPos.Tetrimino = curBlockWithPos.Tetrimino.RotateCW();
                        curBlockWithPos.Tetrimino = curBlockWithPos.Tetrimino.RotateCW();
                        curBlockWithPos.Tetrimino = curBlockWithPos.Tetrimino.RotateCW();
                        break;
                    case Move.Enter:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
