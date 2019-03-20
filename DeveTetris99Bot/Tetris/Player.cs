using DeveTetris99Bot.Tetris.Logic;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DeveTetris99Bot.Tetris
{
    public class Player
    {
        private readonly IGameStateReader gameStateReader;
        private readonly IKeyPresser keyPresser;
        private readonly BestMoveFinder bestMoveFinder;

        private readonly GameState previousState;
        private ColumnAndOrientationOrStash target;
        private bool stashAllowed;

        public Player(IGameStateReader gameStateReader, IKeyPresser keyPresser)
        {
            this.gameStateReader = gameStateReader;
            this.keyPresser = keyPresser;
            bestMoveFinder = new BestMoveFinder(1);

            previousState = null;

            target = null;
            stashAllowed = true;
        }

        public void Play()
        {
            gameStateReader.Starting();

            while (true)
            {
                var gameState = gameStateReader.ReadGameState();

                if (Broken(gameState))
                {
                    Thread.Sleep(500);
                    continue;
                }

                if (gameState.ThereIsDanger)
                {
                    Evaluator.MaxHeight = 19;
                }
                else
                {
                    Evaluator.MaxHeight = 4;
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

                //foreach (var move in moves)
                //{
                //    Console.WriteLine($"Making move: {move}");
                //}
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
                if (tetrimino == null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
