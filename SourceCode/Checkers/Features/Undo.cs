using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Views;
using Checkers.Movement;
using Checkers.Players;
using Checkers.GameMode;

namespace Checkers.Features
{
    class Undo
    {

        Stack<string[,]> prevMoves = new Stack<string[,]>();

        public Stack<string[,]> PrevMoves
        {
            get
            {
                return prevMoves;
            }
            set
            {
                prevMoves = value;
            }
        }

        public void AddCurrentBoardState(string[,] boardArray)
        {
            string[,] currentState = boardArray.Clone() as string[,];
            PrevMoves.Push(currentState);
        }
        
        public string UndoMessage()
        {
            string choice;
            Console.WriteLine(" Press Enter to End your Turn or Press U to Undo");
            return choice = Console.ReadLine().ToUpper();
        }
        

        public string[,] UndoMove()
        {
            return PrevMoves.Pop();
        }
    }
}
