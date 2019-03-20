using DeveTetris99Bot.Config;
using DeveTetris99Bot.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeveTetris99Bot.Tetris
{
    public class FakeGame : IGameStateReader, IKeyPresser
    {
        private int cur = 0;
        private Board board;

        private List<Tetrimino> nextBlocks;
        private TetriminoWithPosition curBlockWithPos;
        private Tetrimino inStash;
        private readonly Panel drawPanel;
        private readonly Label linesClearedLabel;
        private Graphics g;

        private int linesCleared = 0;

        public FakeGame(Panel drawPanel, Label linesClearedLabel)
        {
            board = new Board(TetrisConstants.BoardWidth, TetrisConstants.BoardHeight);

            RedetectBlocks();
            this.drawPanel = drawPanel;
            this.linesClearedLabel = linesClearedLabel;
            g = drawPanel.CreateGraphics();
        }

        public void RedrawComplete()
        {
            g.Clear(Color.Black);
            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    bool shouldDraw = board.BoardArray[y, x];
                    if (shouldDraw)
                    {
                        g.FillRectangle(Brushes.Red, x * TetrisConstants.BlockSize, y * TetrisConstants.BlockSize, TetrisConstants.BlockSize, TetrisConstants.BlockSize);
                    }
                }
            }
        }

        public void DrawDifferences(Board board1, Board board2)
        {
            for (int y = 0; y < board1.Height; y++)
            {
                for (int x = 0; x < board1.Width; x++)
                {
                    bool shouldDraw = board1.BoardArray[y, x] != board2.BoardArray[y, x];
                    if (shouldDraw)
                    {
                        if (board1.BoardArray[y, x])
                        {
                            g.FillRectangle(Brushes.Red, x * TetrisConstants.BlockSize, y * TetrisConstants.BlockSize, TetrisConstants.BlockSize, TetrisConstants.BlockSize);
                        }
                        else
                        {
                            g.FillRectangle(Brushes.Black, x * TetrisConstants.BlockSize, y * TetrisConstants.BlockSize, TetrisConstants.BlockSize, TetrisConstants.BlockSize);
                        }
                    }
                }
            }
        }

        private void RedetectBlocks()
        {
            var viableBlocks = InfinoListo().Skip(cur).Take(6).ToList();

            curBlockWithPos = new TetriminoWithPosition(viableBlocks.First(), 0, 4);
            nextBlocks = viableBlocks.Skip(1).ToList();
        }

        public GameState ReadGameState()
        {
            var gameState = new GameState(board, curBlockWithPos, nextBlocks, inStash, false);

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
                        var previousBord = board;
                        var result = board.drop(curBlockWithPos.Tetrimino, curBlockWithPos.LeftCol);

                        board = result.Board;
                        linesCleared += result.LinesCleared;

                        linesClearedLabel.Invoke(new Action(() =>
                        {
                            linesClearedLabel.Text = linesCleared.ToString();
                        }));

                        if (result.LinesCleared != 0)
                        {
                            RedrawComplete();
                            //DrawDifferences(result.Board, previousBord);
                        }
                        else
                        {
                            //RedrawComplete();
                            DrawDifferences(result.Board, previousBord);
                        }

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

        public void Starting()
        {
        }
    }
}
