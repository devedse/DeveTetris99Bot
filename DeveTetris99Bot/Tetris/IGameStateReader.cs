using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveTetris99Bot.Tetris
{
    public interface IGameStateReader
    {
        GameState ReadGameState();
        void Starting();
    }
}
