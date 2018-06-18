using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Used to keep track of the number of pieces currently active in the board.
    /// </summary>
    public class PieceInfo
    {
        public int black = 0;
        public int white = 0;

        public PieceInfo(int black, int white)
        {
            this.black = black;
            this.white = white;
        }
    }
}
