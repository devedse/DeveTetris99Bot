using DeveTetris99Bot.Config;
using DeveTetris99Bot.Helpers;
using DeveTetris99Bot.TetrisDetector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly Panel drawPanelBlocks;
        private readonly Panel panelDanger;
        private readonly Label linesClearedLabel;
        private readonly Label dangerCountLabel;
        private Graphics g;
        private Graphics gBlocks;
        private Graphics gDanger;
        private int linesCleared = 0;

        private bool running = false;

        private Stopwatch _timeSinceLastKeyPress = Stopwatch.StartNew();

        public RealGame(Tetris99BotForm tetris99Form, Panel drawPanel, Panel drawPanelBlocks, Panel drawPanelDanger, Label linesClearedLabel, Label dangerCountLabel)
        {
            board = new Board(TetrisConstants.BoardWidth, TetrisConstants.BoardHeight);

            this.tetris99Form = tetris99Form;
            this.drawPanel = drawPanel;
            this.drawPanelBlocks = drawPanelBlocks;
            panelDanger = drawPanelDanger;
            this.linesClearedLabel = linesClearedLabel;
            this.dangerCountLabel = dangerCountLabel;
            g = drawPanel.CreateGraphics();
            gBlocks = drawPanelBlocks.CreateGraphics();
            gDanger = drawPanelDanger.CreateGraphics();
        }

        private List<Tetrimino> _lastDetectedBlocks = new List<Tetrimino>();
        private int _lastDetectedBlocksAreTheSameTimes = 0;
        private int _lastDetectedDanger = 0;
        private DateTime _lastDanger = DateTime.MinValue;
        private DateTime _lastNoDanger = DateTime.MinValue;

        public void LoadCapturedGameData(TetrisDetectionData detectionData)
        {
            if (running)
            {
                if (detectionData.Danger > 0)
                {
                    _lastDanger = DateTime.Now;
                    _lastDetectedDanger = detectionData.Danger;
                }
                else
                {
                    _lastNoDanger = DateTime.Now;
                }


                foreach (var item in detectionData.TheNewIncomingTetriminos)
                {
                    if (!Tetrimino.All.Any(z => z.Equals(item)))
                    {
                        Console.WriteLine("Deze is wss corrupt");
                        return;
                    }
                }

                if (detectionData.TheNewIncomingTetriminos.Count != _lastDetectedBlocks.Count)
                {
                    _lastDetectedBlocks = detectionData.TheNewIncomingTetriminos;
                    _lastDetectedBlocksAreTheSameTimes = 0;
                    return;
                }

                for (int i = 0; i < detectionData.TheNewIncomingTetriminos.Count; i++)
                {
                    if (!detectionData.TheNewIncomingTetriminos[i].Equals(_lastDetectedBlocks[i]))
                    {
                        _lastDetectedBlocks = detectionData.TheNewIncomingTetriminos;
                        _lastDetectedBlocksAreTheSameTimes = 0;
                        return;
                    }
                }

                _lastDetectedBlocksAreTheSameTimes++;

                if (_lastDetectedBlocksAreTheSameTimes < 3)
                {
                    //Make sure we get 3 valid readings before acknowledging that these blocks are actually valid
                    return;
                }






                lock (nextBlocksCaptured)
                {
                    if (nextBlocksCaptured.Count == 0)
                    {
                        var toAdd = detectionData.TheNewIncomingTetriminos;
                        for (int i = 0; i < toAdd.Count; i++)
                        {
                            var block = toAdd[i];
                            Console.WriteLine($"Adding block (New) ({nextBlocksCaptured.Count + i}):{Environment.NewLine}{block.ToStringRotateable()}");
                        }
                        nextBlocksCaptured.AddRange(toAdd);
                    }
                    else
                    {
                        int lastInExisting = nextBlocksCaptured.Count - 1;
                        int lastInNew = detectionData.TheNewIncomingTetriminos.Count - 1;

                        int deducter = detectionData.TheNewIncomingTetriminos.Count;
                        bool hasFoundEqualsBefore = false;

                        while (lastInNew >= 0)
                        {
                            var blockInExisting = nextBlocksCaptured[lastInExisting];
                            var blockInNew = detectionData.TheNewIncomingTetriminos[lastInNew];

                            if (!blockInExisting.Equals(blockInNew))
                            {
                                //reset the existing counter
                                lastInExisting = nextBlocksCaptured.Count - 1;
                                if (hasFoundEqualsBefore)
                                {
                                    hasFoundEqualsBefore = false;
                                }
                                else
                                {
                                    lastInNew--;
                                }

                                deducter = lastInNew + 1;
                            }
                            else
                            {
                                hasFoundEqualsBefore = true;
                                lastInExisting--;
                                lastInNew--;
                            }
                        }


                        var toAdd = detectionData.TheNewIncomingTetriminos.Skip(deducter).ToList();
                        for (int i = 0; i < toAdd.Count; i++)
                        {
                            var block = toAdd[i];
                            Console.WriteLine($"Adding block ({nextBlocksCaptured.Count + i}):{Environment.NewLine}{block.ToStringRotateable()}");
                        }

                        nextBlocksCaptured.AddRange(toAdd);
                    }
                }
            }
        }

        public void DrawNextBlocks()
        {
            List<Tetrimino> copy;
            lock (nextBlocks)
            {
                copy = nextBlocks.ToList();
            }


            int pos = 0;
            //int ccc = cur;

            gBlocks.Clear(Color.Black);
            while (pos < copy.Count)
            {
                var curBlock = copy[pos];

                for (int y = 0; y < curBlock.Height; y++)
                {
                    for (int x = 0; x < curBlock.Width; x++)
                    {
                        if (curBlock.TetriminoArray[y, x])
                        {
                            gBlocks.FillRectangle(Brushes.Red, x * TetrisConstants.BlockSize, y * TetrisConstants.BlockSize + pos * (TetrisConstants.BlockSize * 3), TetrisConstants.BlockSize, TetrisConstants.BlockSize);
                        }
                    }
                }

                pos++;
                //ccc++;
            }


        }

        public void DrawCurrentBlock()
        {
            //Console.WriteLine($"Drawing cur block: {curBlockWithPos.LeftCol} {curBlockWithPos.Tetrimino}");

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
            while (nextBlocksCaptured.Count == cur)
            {
                Console.WriteLine("Waiting for new blocks, should only happen in fake game mode");
                //wait for new blocks
                Thread.Sleep(500);
            }

            lock (nextBlocksCaptured)
            {
                var viableBlocks = nextBlocksCaptured.Skip(cur).ToList();

                var theNewBlock = viableBlocks.First();
                Console.WriteLine($"New cur block ({cur}):{Environment.NewLine}{theNewBlock.ToStringRotateable()}");
                curBlockWithPos = new TetriminoWithPosition(theNewBlock, 2, 3 + (theNewBlock.Width == 2 ? 1 : 0));
                nextBlocks = viableBlocks.Skip(1).ToList();
            }
        }

        public GameState ReadGameState()
        {
            var gameState = new GameState(board, curBlockWithPos, nextBlocks, inStash, DetectIfThereIsDanger());

            return gameState;
        }

        public void NextBlock()
        {
            cur++;
        }

        public void MakeMove(List<Move> moves)
        {
            foreach (var move in moves.Take(1))
            {
                int linesClearedNow = 0;
                string keyToPress = null;

                switch (move)
                {
                    case Move.Left:
                        //tetris99Form.CurrentSerialConnection.SendButtonPress("LH");
                        keyToPress = "LH";
                        curBlockWithPos.LeftCol--;
                        break;
                    case Move.Right:
                        //tetris99Form.CurrentSerialConnection.SendButtonPress("RH");
                        keyToPress = "RH";
                        curBlockWithPos.LeftCol++;
                        break;
                    case Move.Drop:
                        var previousBord = board;
                        var result = board.drop(curBlockWithPos.Tetrimino, curBlockWithPos.LeftCol);

                        board = result.Board;
                        linesCleared += result.LinesCleared;
                        linesClearedNow = result.LinesCleared;

                        linesClearedLabel.Invoke(new Action(() =>
                        {
                            linesClearedLabel.Text = linesCleared.ToString();
                        }));

                        if (result.LinesCleared != 0)
                        {
                            //RedrawComplete();
                            //DrawDifferences(result.Board, previousBord);


                        }
                        else
                        {
                            //RedrawComplete();
                            //DrawDifferences(result.Board, previousBord);

                        }

                        keyToPress = "UH";
                        //tetris99Form.CurrentSerialConnection.SendButtonPress("UH");

                        cur++;
                        RedetectBlocks();

                        //DrawCurrentBlock();


                        //Thread.Sleep(500);
                        break;
                    case Move.Stash:
                        var tmp = inStash;
                        inStash = curBlockWithPos.Tetrimino;
                        keyToPress = "7";
                        //tetris99Form.CurrentSerialConnection.SendButtonPress("7");
                        if (tmp == null)
                        {
                            cur++;
                            RedetectBlocks();
                            //Thread.Sleep(500);
                        }
                        else
                        {
                            curBlockWithPos = new TetriminoWithPosition(tmp, 2, 3 + (tmp.Width == 2 ? 1 : 0));
                        }
                        break;
                    case Move.Rotate_CW:
                        keyToPress = "2";
                        //tetris99Form.CurrentSerialConnection.SendButtonPress("2");
                        Rotate();
                        break;
                    case Move.Rotate_CWW:
                        keyToPress = "1";
                        //tetris99Form.CurrentSerialConnection.SendButtonPress("1");
                        Rotate();
                        Rotate();
                        Rotate();
                        break;
                    case Move.Enter:
                        break;
                    default:
                        break;
                }



                RedrawComplete();
                DrawCurrentBlock();
                DrawNextBlocks();

                bool thereWasDanger = DetectIfThereIsDanger();

                if (thereWasDanger)
                {
                    gDanger.Clear(Color.Red);
                    dangerCountLabel.Invoke(new Action(() =>
                    {
                        dangerCountLabel.Text = _lastDetectedDanger.ToString();
                    }));
                }
                else
                {
                    gDanger.Clear(Color.Green);
                }

                if (!string.IsNullOrWhiteSpace(keyToPress))
                {
                    var timeToWait = (int)Math.Max(0, minTimeToWait - _timeSinceLastKeyPress.Elapsed.TotalMilliseconds);
                    if (timeToWait > 0)
                    {
                        Thread.Sleep(timeToWait);
                    }

                    minTimeToWait = FrameDurationHelper.ToFrameDuration(3);

                    tetris99Form.CurrentSerialConnection.SendButtonPress(keyToPress, false);
                    _timeSinceLastKeyPress.Restart();
                    if (keyToPress == "UH")
                    {
                        //If other players spawn shit, we need to wait for the animation
                        if (thereWasDanger)
                        {
                            minTimeToWait = FrameDurationHelper.ToFrameDuration(33 + _lastDetectedDanger * 4);
                        }
                        else
                        {
                            minTimeToWait = FrameDurationHelper.ToFrameDuration(8);
                        }
                    }
                    if (linesClearedNow > 0)
                    {
                        //Theres no more danger now
                        _lastDanger = DateTime.MinValue;
                        _lastNoDanger = DateTime.Now;

                        minTimeToWait = FrameDurationHelper.ToFrameDuration(48);
                    }
                }
            }
        }

        private bool DetectIfThereIsDanger()
        {
            double dangerTimer = 2;
            var timeSinceLastDanger = DateTime.Now - _lastDanger;
            var timeSinceLastNoDanger = DateTime.Now - _lastNoDanger;
            //bool thereWasDanger = timeSinceLastDanger.TotalSeconds < dangerTimer;

            bool thereWasDanger = _lastDanger > _lastNoDanger;

            if (!thereWasDanger)
            {
                if (timeSinceLastDanger.TotalSeconds < dangerTimer)
                {
                    thereWasDanger = true;
                }
            }

            if (thereWasDanger && timeSinceLastNoDanger.TotalSeconds < 2)
            {

            }
            else
            {
                thereWasDanger = false;
            }

            return thereWasDanger;
        }

        private int minTimeToWait = 0;

        public void Rotate()
        {
            var preToTheLeft = curBlockWithPos.Tetrimino.DeductedLeftRows;
            curBlockWithPos.Tetrimino = curBlockWithPos.Tetrimino.RotateCW();
            var after = curBlockWithPos.Tetrimino.DeductedLeftRows;

            //Console.WriteLine($"Moving block {preToTheLeft - after}");
            curBlockWithPos.LeftCol -= preToTheLeft - after;

            curBlockWithPos.LeftCol = Math.Max(0, curBlockWithPos.LeftCol);
            curBlockWithPos.LeftCol = Math.Min(curBlockWithPos.LeftCol, TetrisConstants.BoardWidth - curBlockWithPos.Tetrimino.Width);
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

            //Sometimes if you don't do this it sends random inputs.
            tetris99Form.CurrentSerialConnection.SendButtonPress("LH");
            tetris99Form.CurrentSerialConnection.SendButtonPress("UH");
            tetris99Form.CurrentSerialConnection.SendButtonPress("RH");
            tetris99Form.CurrentSerialConnection.SendButtonPress("DH");

            Thread.Sleep(5000);

            //Select Aanvallers
            tetris99Form.CurrentSerialConnection.SendButtonPress("DR");
        }
    }
}
