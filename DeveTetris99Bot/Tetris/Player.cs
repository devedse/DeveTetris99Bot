using DeveTetris99Bot.Config;
using DeveTetris99Bot.Tetris.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace DeveTetris99Bot.Tetris
{
    public class Player
    {
        private readonly IGameStateReader gameStateReader;
        private readonly IKeyPresser keyPresser;
        private readonly BestMoveFinder bestMoveFinder;

        private readonly GameState previousState;
        private readonly Panel drawPanel;
        private ColumnAndOrientationOrStash target;
        private bool stashAllowed;

        public Player(Panel drawPanel)
        {
            var fakeGame = new FakeGameState();
            gameStateReader = fakeGame;
            keyPresser = fakeGame;
            bestMoveFinder = new BestMoveFinder(1);

            previousState = null;

            target = null;
            stashAllowed = true;
            this.drawPanel = drawPanel;
        }

        public void Play()
        {
            while (true)
            {
                Thread.Sleep(1);
                var gameState = gameStateReader.ReadGameState();

                var g = drawPanel.CreateGraphics();
                g.Clear(Color.Black);
                for (int y = 0; y < gameState.Board.Height; y++)
                {
                    for (int x = 0; x < gameState.Board.Width; x++)
                    {
                        bool shouldDraw = gameState.Board.BoardArray[y, x];
                        if (shouldDraw)
                        {
                            g.FillRectangle(Brushes.Red, x * TetrisConstants.BlockSize, y * TetrisConstants.BlockSize, TetrisConstants.BlockSize, TetrisConstants.BlockSize);
                        }
                    }
                }

                if (Broken(gameState))
                {
                    Thread.Sleep(500);
                    continue;
                }

                //Console.WriteLine(gameState.Board);
                //Console.WriteLine(string.Join(";", gameState.NextTetriminoes));
                var twp = gameState.FallingTetrimino;
                if (twp == null)
                {
                    continue;
                }

                Tetrimino tetrimino = twp.Tetrimino;
                if (target == null || WrongTetrimino(target.Tetrimino, tetrimino))
                {
                    target = bestMoveFinder.FindBestMove(gameState, twp, stashAllowed);
                    if (target == null)
                    {
                        continue;
                    }
                }

                var moves = new List<Move>();
                if (target.Stash)
                {
                    moves.Add(Move.Stash);
                    target = null;
                    stashAllowed = false;
                }
                else
                {
                    if (!tetrimino.Equals(target.Tetrimino))
                    {
                        if (CanReachInOneOrTwoCWRotations(tetrimino, target.Tetrimino))
                        {
                            moves.Add(Move.Rotate_CW);
                        }
                        else
                        {
                            moves.Add(Move.Rotate_CWW);
                        }
                    }
                    if (target.Column > twp.LeftCol)
                    {
                        moves.Add(Move.Right);
                    }
                    else if (target.Column < twp.LeftCol)
                    {
                        moves.Add(Move.Left);
                    }
                    if (moves.Count == 0)
                    {
                        moves.Add(Move.Drop);
                        target = null;
                        stashAllowed = true;
                    }
                }

                foreach (var move in moves)
                {
                    Console.WriteLine($"Making move: {move}");
                }
                keyPresser.MakeMove(moves);

                //Console.WriteLine(target);
                //Console.WriteLine("------");
            }
        }


        private bool WrongTetrimino(Tetrimino tetrimino, Tetrimino target)
        {
            for (int i = 0; i < 4; i++)
            {
                if (tetrimino.Equals(target))
                {
                    return false;
                }
                tetrimino = tetrimino.RotateCW();
            }
            return true;
        }

        private bool CanReachInOneOrTwoCWRotations(Tetrimino tetrimino, Tetrimino target)
        {
            for (int i = 0; i < 2; i++)
            {
                tetrimino = tetrimino.RotateCW();
                if (tetrimino.Equals(target))
                {
                    return true;
                }
            }
            return false;
        }

        private bool Broken(GameState gameState)
        {
            if (gameState == null)
            {
                return true;
            }
            foreach (Tetrimino tetrimino in gameState.NextTetriminoes)
            {
                if (tetrimino == null || tetrimino.Width == 4 && tetrimino.Height == 4)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
