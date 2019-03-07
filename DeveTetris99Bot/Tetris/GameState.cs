using System.Collections.Generic;

namespace DeveTetris99Bot.Tetris
{
    public class GameState
    {
        public Board Board { get; }
        public List<Tetrimino> NextTetriminoes { get; }
        public TetriminoWithPosition FallingTetrimino { get; }
        public Tetrimino TetriminoInStash { get; }

        public GameState(Board board, TetriminoWithPosition fallingTetrimino, List<Tetrimino> nextTetriminoes, Tetrimino tetriminoInStash)
        {
            Board = board;
            NextTetriminoes = nextTetriminoes;
            FallingTetrimino = fallingTetrimino;
            TetriminoInStash = tetriminoInStash;
        }
    }
}
