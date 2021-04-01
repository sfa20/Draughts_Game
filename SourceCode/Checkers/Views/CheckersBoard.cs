using System;
using Checkers.Players;
using Checkers.Movement;

namespace Checkers.Views
{
    class CheckersBoard
    {
        public void CreateBoard(string[,] GameBoard, Player playerOne, Player playerTwo)
        {
            //Row D
            for (int x = 2; x < 9; x++)
            {
                GameBoard[4, x] = "  ";
                x++;
            }

            //Row E
            for (int x = 1; x < 9; x++)
            {
                GameBoard[3, x] = "  ";
                x++;
            }

            
            //Player two row F and H
            for (int x = 0; x < 3; x++)
            {
                for (int y = 2; y < 10; y++)
                {
                    GameBoard[x, y] = playerTwo.Draught;
                    y++;
                }
                x++;
            }
            
            //Player two row G
            for (int x = 1; x < 9; x++)
            {
                GameBoard[1, x] = playerTwo.Draught;
                x++;
            }

            //Player one row A and C
            for (int x = 5; x < 8; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    GameBoard[x, y] = playerOne.Draught;
                    y++;
                }
                x++;
            }
           
            //Player one row B
            for (int x = 2; x < 10; x++)
            {
                GameBoard[6, x] = playerOne.Draught;
                x++;
            }
            
            //GameBoard[1, 7] = playerTwo.King;
            //GameBoard[1, 1] = playerOne.Draught;
            //GameBoard[6, 6] = playerOne.Draught;
            //GameBoard[5, 7] = playerTwo.Draught;
            //GameBoard[5, 3] = playerTwo.Draught;
            //GameBoard[6, 4] = playerOne.Draught;
            //GameBoard[2, 4] = playerTwo.Draught;
        }

        public void DrawBoard(string[,] gameboard, MoveCount playerone, MoveCount playertwo)
        {
            string[,] board = gameboard;
           
            Console.Clear();
            Console.SetWindowSize(110, 50);
            Console.WriteLine(new string('\n', 3));
            Console.WriteLine("          ********************Game Board*****************");
            Console.WriteLine("           _______________________________________________________");
            Console.WriteLine("          |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |");
            Console.WriteLine("       H  |▒▒▒▒▒▒|  {0}  |▒▒▒▒▒▒|  {1}  |▒▒▒▒▒▒|  {2}  |▒▒▒▒▒▒|  {3}  |            Player 1: O", board[0, 2], board[0, 4], board[0, 6], board[0, 8]);
            Console.WriteLine("          |▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|            Player 2: X");
            Console.WriteLine("          |      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|");
            Console.WriteLine("       G  |  {0}  |▒▒▒▒▒▒|  {1}  |▒▒▒▒▒▒|  {2}  |▒▒▒▒▒▒|  {3}  |▒▒▒▒▒▒|", board[1, 1], board[1, 3], board[1, 5], board[1, 7]);
            Console.WriteLine("          |______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|");
            Console.WriteLine("          |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |");
            Console.Write("       F  |▒▒▒▒▒▒|  {0}  |▒▒▒▒▒▒|  {1}  |▒▒▒▒▒▒|  {2}  |▒▒▒▒▒▒|  {3}  |        "    , board[2, 2], board[2, 4], board[2, 6], board[2, 8]); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(" Player 1 Move Count: {0}", playerone.NoOfMoves); Console.ResetColor(); 
            Console.Write("          |▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|       "); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(" Player 2 Move Count: {0} ", playertwo.NoOfMoves); Console.ResetColor();
            Console.WriteLine("          |      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|");
            Console.WriteLine("       E  |  {0}  |▒▒▒▒▒▒|  {1}  |▒▒▒▒▒▒|  {2}  |▒▒▒▒▒▒|  {3}  |▒▒▒▒▒▒|", board[3, 1], board[3, 3], board[3, 5], board[3, 7]);
            Console.WriteLine("          |______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|");
            Console.WriteLine("          |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |");
            Console.WriteLine("       D  |▒▒▒▒▒▒|  {0}  |▒▒▒▒▒▒|  {1}  |▒▒▒▒▒▒|  {2}  |▒▒▒▒▒▒|  {3}  |", board[4, 2], board[4, 4], board[4, 6], board[4, 8]);
            Console.WriteLine("          |▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|");
            Console.WriteLine("          |      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|");
            Console.WriteLine("       C  |  {0}  |▒▒▒▒▒▒|  {1}  |▒▒▒▒▒▒|  {2}  |▒▒▒▒▒▒|  {3}  |▒▒▒▒▒▒|", board[5, 1], board[5, 3], board[5, 5], board[5, 7]);
            Console.WriteLine("          |______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|");
            Console.WriteLine("          |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |");
            Console.WriteLine("       B  |▒▒▒▒▒▒|  {0}  |▒▒▒▒▒▒|  {1}  |▒▒▒▒▒▒|  {2}  |▒▒▒▒▒▒|  {3}  |", board[6, 2], board[6, 4], board[6, 6], board[6, 8]);
            Console.WriteLine("          |▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|");
            Console.WriteLine("          |      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|      |▒▒▒▒▒▒|");
            Console.WriteLine("       A  |  {0}  |▒▒▒▒▒▒|  {1}  |▒▒▒▒▒▒|  {2}  |▒▒▒▒▒▒|  {3}  |▒▒▒▒▒▒|", board[7, 1], board[7, 3], board[7, 5], board[7, 7]);
            Console.WriteLine("          |______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|______|▒▒▒▒▒▒|");
            Console.WriteLine();
            Console.WriteLine("             1       2      3      4      5      6      7      8");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


        }
    }
}
 