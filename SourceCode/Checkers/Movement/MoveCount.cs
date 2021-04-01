using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Movement
{
    class MoveCount
    {
        private int noofmoves;

        public int NoOfMoves
        {
            get
            {
                return noofmoves;
            }
            set
            {
                noofmoves = value;
            }
        }

        public int countmoves()
        {
            NoOfMoves++;
            return NoOfMoves;
        }
    }
}
