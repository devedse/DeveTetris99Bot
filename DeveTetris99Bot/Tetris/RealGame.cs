using DeveTetris99Bot.Config;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DeveTetris99Bot.Tetris
{
    public class RealGame : IGameStateReader, IKeyPresser
    {
        private int cur = 0;
        private Board board;

        private List<Tetrimino> nextBlocks;
        private List<Tetrimino> nextBlocksCaptured = new List<Tetrimino>();
        private TetriminoWithPosition curBlockWithPos;
        private Tetrimino inStash;
        private readonly Tetris99BotForm tetris99Form;
        private readonly Panel drawPanel;
        private readonly Label linesClearedLabel;
        private Graphics g;

        private int linesCleared = 0;

        private bool running = false;

        public RealGame(Tetris99BotForm tetris99Form, Panel drawPanel, Label linesClearedLabel)
        {
            board = new Board(TetrisConstants.BoardWidth, TetrisConstants.BoardHeight);

            this.tetris99Form = tetris99Form;
            this.drawPanel = drawPanel;
            this.linesClearedLabel = linesClearedLabel;
            g = drawPanel.CreateGraphics();
        }

        public void LoadCapturedGameData(List<Tetrimino> theNewIncomingTetriminos)
        {
            if (running)
            {
                foreach (var item in theNewIncomingTetriminos)
                {
                    if (!Tetrimino.All.Any(z => z.Equals(item)))
                    {
                        Console.WriteLine("Deze is wss corrupt");
                        return;
                    }
                }

                lock (nextBlocksCaptured)
                {
                    if (nextBlocksCaptured == null)
                    {
                        nextBlocksCaptured.AddRange(theNewIncomingTetriminos);
                    }
                    else
                    {
                        int aCount = cur;
                        int newCount = 0;

                        int brrr = cur;

                        while (newCount < theNewIncomingTetriminos.Count)
                        {


                            if (aCount >= nextBlocksCaptured.Count)
                            {
                                var toAdd = theNewIncomingTetriminos.Skip(newCount).ToList();
                                foreach (var block in toAdd)
                                {
                                    Console.WriteLine($"Adding block: {block}");
                                }
                                nextBlocksCaptured.AddRange(toAdd);
                                return;
                            }
                            else
                            {
                                if (theNewIncomingTetriminos[newCount].Equals(nextBlocksCaptured[aCount]))
                                {
                                    aCount++;
                                    newCount++;
                                }
                                else
                                {
                                    newCount = 0;
                                    brrr++;
                                    aCount = brrr;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void DrawCurrentBlock()
        {
            for (int y = 0; y < curBlockWithPos.Tetrimino.Height; y++)
            {
                for (int x = 0; x < curBlockWithPos.Tetrimino.Width; x++)
                {
                    bool shouldDraw = curBlockWithPos.Tetrimino.TetriminoArray[y, x];
                    if (shouldDraw)
                    {
                        g.FillRectangle(Brushes.Red, (x + curBlockWithPos.LeftCol) * TetrisConstants.BlockSize, (y + curBlockWithPos.TopRow) * TetrisConstants.BlockSize, TetrisConstants.BlockSize, TetrisConstants.BlockSize);
                    }
                }
            }
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
            lock (nextBlocksCaptured)
            {
                var viableBlocks = nextBlocksCaptured.Skip(cur).Take(6).ToList();

                var theNewBlock = viableBlocks.First();
                int extra = 0;
                if (theNewBlock.Width == 2)
                {
                    extra = 1;
                }
                curBlockWithPos = new TetriminoWithPosition(theNewBlock, 0, 3 + extra);
                nextBlocks = viableBlocks.Skip(1).ToList();
            }
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

        public void MakeMove(List<Move> moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case Move.Left:
                        tetris99Form.CurrentSerialConnection.SendButtonPress("LH");
                        curBlockWithPos.LeftCol--;
                        break;
                    case Move.Right:
                        tetris99Form.CurrentSerialConnection.SendButtonPress("RH");
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
                            RedrawComplete();
                            //DrawDifferences(result.Board, previousBord);

                        }

                        tetris99Form.CurrentSerialConnection.SendButtonPress("UH");

                        cur++;
                        RedetectBlocks();

                        DrawCurrentBlock();


                        Thread.Sleep(1000);
                        break;
                    case Move.Stash:
                        var tmp = inStash;
                        inStash = curBlockWithPos.Tetrimino;
                        tetris99Form.CurrentSerialConnection.SendButtonPress("7");
                        if (tmp == null)
                        {
                            cur++;
                            RedetectBlocks();
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            curBlockWithPos = new TetriminoWithPosition(tmp, 0, 4);
                        }
                        break;
                    case Move.Rotate_CW:
                        tetris99Form.CurrentSerialConnection.SendButtonPress("2");
                        curBlockWithPos.Tetrimino = curBlockWithPos.Tetrimino.RotateCW();
                        break;
                    case Move.Rotate_CWW:
                        tetris99Form.CurrentSerialConnection.SendButtonPress("1");
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

            RedrawComplete();
            DrawCurrentBlock();
        }

        public void Starting()
        {
            running = true;

            while (nextBlocksCaptured.Count == 0)
            {
                //Wait for block data to come in
                Thread.Sleep(1);
            }
            RedetectBlocks();

            Thread.Sleep(5000);
        }
    }
}
