using DeveTetris99Bot.Tetris;
using System.Collections.Generic;

namespace DeveTetris99Bot.TetrisDetector
{
    public class TetrisDetectionData
    {
        public bool Danger { get; set; }
        public List<Tetrimino> TheNewIncomingTetriminos { get; set; }
    }
}
