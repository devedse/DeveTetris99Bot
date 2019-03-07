using System.Collections.Generic;

namespace DeveTetris99Bot.Tetris
{
    public interface IKeyPresser
    {
        void MakeMove(List<Move> moves);
    }
}
