using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Players;

namespace Checkers.Movement
{
    class MoveDetection
    {
        public void CheckMoves(string[,] boardArray, Player player, List<string> getAvailablePieces, List<string> getAvailableMoves, List<string> getCapturePieces, Dictionary<int, string> dict)
        {
            string enemy;
            string enemyKing;

            //Sets the enemy depending on player using the method
            if (player.Draught == "O " | player.King == "OK")
            {
                enemy = "X ";
                enemyKing = "XK";
            }
            else
            {
                enemy = "O ";
                enemyKing = "OK";
            }

            //Clear Lists
            getAvailablePieces.Clear();
            getAvailableMoves.Clear();
            getCapturePieces.Clear();
            
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (player is PlayerOne)
                    {
                        if (boardArray[x, y] == player.Draught | boardArray[x, y] == player.King)
                        {
                            //standard player one movement upward for force capture
                            //Prevents out of bounds array error
                            if (x > 1)
                            {
                                //Check up and Left for enemy
                                if (boardArray[x - 1, y - 1] == enemy | boardArray[x - 1, y - 1] == enemyKing)
                                {
                                    //check Left again for free space
                                    if (boardArray[x - 2, y - 2] == "  ")
                                    {
                                        string temp = dict[x];
                                        getCapturePieces.Add(temp + y.ToString());
                                    }
                                }
                                //Check up and Right for enemy
                                if (boardArray[x - 1, y + 1] == enemy | boardArray[x - 1, y + 1] == enemyKing)
                                {
                                    //Check Right for free space
                                    if (boardArray[x - 2, y + 2] == "  ")
                                    {
                                        string temp = dict[x];
                                        getCapturePieces.Add(temp + y.ToString());
                                    }
                                }
                            }

                            //Check upward Single movement for player 1 and Player 1 King
                            //Prevents out of bounds array error
                            if (x != 0)
                            {
                                //Check Left for single movement
                                if (boardArray[x - 1, y - 1] == "  ")
                                {
                                    string temp = dict[x];
                                    getAvailablePieces.Add(temp + y.ToString());
                                    //temp2 gets the row value (ie D)
                                    string temp2 = dict[x - 1];
                                    getAvailableMoves.Add(temp2 + (y - 1).ToString());
                                }
                                //check right for single movement
                                if (boardArray[x - 1, y + 1] == "  ")
                                {
                                    string temp = dict[x];
                                    getAvailablePieces.Add(temp + y.ToString());
                                    string temp2 = dict[x - 1];
                                    getAvailableMoves.Add(temp2 + (y + 1).ToString());
                                }
                            }

                            //king downward move and capture
                            if (x < 6)
                            {
                                if (boardArray[x, y] == player.King)
                                {
                                    //Check down and left for enemy
                                    if (boardArray[x + 1, y - 1] == enemy | boardArray[x + 1, y - 1] == enemyKing)
                                    {
                                        //Check left again for free space
                                        if (boardArray[x + 2, y - 2] == "  ")
                                        {
                                            string temp = dict[x];
                                            getCapturePieces.Add(temp + y.ToString());
                                        }
                                    }
                                    
                                    //Check down and right for enemy
                                    if (boardArray[x + 1, y + 1] == enemy | boardArray[x + 1, y + 1] == enemyKing)
                                    {
                                        //Check right again for free space
                                        if (boardArray[x + 2, y + 2] == "  ")
                                        {
                                            string temp = dict[x];
                                            getCapturePieces.Add(temp + y.ToString());
                                        }
                                    }
                                }
                            }
 
                            //King Dowward movement
                            if (x != 7)
                            {
                                if (boardArray[x, y] == player.King)
                                {
                                    if (boardArray[x + 1, y - 1] == "  ")
                                    {
                                        string temp = dict[x];
                                        getAvailablePieces.Add(temp + y.ToString());
                                        //temp2 gets the row value (ie D)
                                        string temp2 = dict[x + 1];
                                        getAvailableMoves.Add(temp2 + (y - 1).ToString());
                                    }

                                    if (boardArray[x + 1, y + 1] == "  ")
                                    {
                                        string temp = dict[x];
                                        getAvailablePieces.Add(temp + y.ToString());
                                        //temp2 gets the row value (ie D)
                                        string temp2 = dict[x + 1];
                                        getAvailableMoves.Add(temp2 + (y + 1).ToString());
                                    }
                                }
                            }
                        }
                    }

                    if (player is PlayerTwo | player is AI)
                    {
                        //Standard Player Two Movement and Player 1 king movemnt
                        //Reverse Movement
                        if (boardArray[x, y] == player.Draught | boardArray[x, y] == player.King)
                        {
                            //Check for force Capture
                            if (x < 6)
                            {
                                //Check Left for enemy
                                if (boardArray[x + 1, y - 1] == enemy | boardArray[x + 1, y - 1] == enemyKing)
                                {
                                    //Check Left of enemy for Free Space
                                    if (boardArray[x + 2, y - 2] == "  ")
                                    {
                                        string temp = dict[x];
                                        getCapturePieces.Add(temp + y.ToString());
                                    }
                                }

                                //Check Right for enemy
                                if (boardArray[x + 1, y + 1] == enemy | boardArray[x + 1, y + 1] == enemyKing)
                                {
                                    //Check Right of enemy for Free Space
                                    if (boardArray[x + 2, y + 2] == "  ")
                                    {
                                        string temp = dict[x];
                                        getCapturePieces.Add(temp + y.ToString());
                                    }
                                }
                            }

                            //Check Downward for SingleMovement
                            if (x != 7)
                            {
                                //Check Left for free space
                                if (boardArray[x + 1, y - 1] == "  ")
                                {
                                    string temp = dict[x];
                                    getAvailablePieces.Add(temp + y.ToString());
                                    string temp2 = dict[x + 1];
                                    getAvailableMoves.Add(temp2 + (y - 1).ToString());
                                }

                                //Check Right for free space
                                if (boardArray[x + 1, y + 1] == "  ")
                                {
                                    string temp = dict[x];
                                    getAvailablePieces.Add(temp + y.ToString());
                                    string temp2 = dict[x + 1];
                                    getAvailableMoves.Add(temp2 + (y + 1).ToString());

                                }
                            }
                            
                            //Test for king upward Move and capture
                            if (x > 1)
                            {
                                if (boardArray[x,y] == player.King)
                                {
                                    //Check up and left for enemy
                                    if(boardArray[x-1, y-1]  == enemy | boardArray[x-1, y-1] == enemyKing)
                                    {
                                        //Check left again for empty space
                                        if(boardArray[x -2, y-2] == "  ")
                                        {
                                            string temp = dict[x];
                                            getCapturePieces.Add(temp + y.ToString());
                                        }
                                    }
                                    //Check up and right for enemy
                                    if (boardArray[x-1,y+1] == enemy | boardArray[x-1, y+1] == enemyKing)
                                    {
                                        //Check right again for empty space
                                        if (boardArray[x-2, y+2] == "  ")
                                        {
                                            string temp = dict[x];
                                            getCapturePieces.Add(temp + y.ToString());
                                        }
                                    }
                                }
                            }

                            if (x != 0)
                            {
                                if (boardArray[x,y] == player.King)
                                {
                                    if (boardArray[x-1,y-1] == "  ")
                                    {
                                        string temp = dict[x];
                                        getAvailablePieces.Add(temp + y.ToString());
                                        //temp2 gets the row value (ie D)
                                        string temp2 = dict[x - 1];
                                        getAvailableMoves.Add(temp2 + (y - 1).ToString());
                                    }

                                    if (boardArray[x-1, y+1] == "  ")
                                    {
                                        string temp = dict[x];
                                        getAvailablePieces.Add(temp + y.ToString());
                                        //temp2 gets the row value (ie D)
                                        string temp2 = dict[x - 1];
                                        getAvailableMoves.Add(temp2 + (y + 1).ToString());
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        public void FindAdditionalMoves(string[,] boardArray, Player player, string piece, List<string> additionalMoves, Dictionary<int, string> dict)
        {
            string enemy;
            string enemyKing;
            
            int currentRow = player.GetRow(piece);
            int currentCol = player.GetCol(piece);
            
            //These fourk lines  need to be moved so they do not causee an out of bounds array
            string MoveUpAndCaptureRight;
            string MoveUpAndCaptureLeft;
            string MoveDownAndCaptureRight;
            string MoveDownAndCaptureLeft;

            //Sets the enemy depending on player using the method
            if (player.Draught == "O " | player.King == "OK")
            {
                enemy = "X ";
                enemyKing = "XK";
            }
            else
            {
                enemy = "O ";
                enemyKing = "OK";
            }
            
            if (player is PlayerOne && (boardArray[currentRow, currentCol] == "O " | boardArray[currentRow, currentCol] == "OK"))
            {
                //Upward Move and Capture for both draught and king
                if(currentRow > 1)
                {
                    //Check Up Right
                    if ((currentCol < 8) && (boardArray[currentRow - 1, currentCol + 1] == enemy | boardArray[currentRow - 1, currentCol + 1] == enemyKing))
                    {
                        //Check right again for free space
                        if (currentCol < 7 && boardArray[currentRow - 2, currentCol + 2] == "  ")
                        {
                            MoveUpAndCaptureRight = dict[currentRow - 2] + (currentCol + 2).ToString();
                            additionalMoves.Add(MoveUpAndCaptureRight);
                        }
                    }
                    //Check Up Left
                    if ((currentCol > 1) && (boardArray[currentRow - 1, currentCol - 1] == enemy | boardArray[currentRow - 1, currentCol - 1] == enemyKing))
                    {
                        //Check Left again for free space
                        if ((currentCol > 2) && (boardArray[currentRow - 2, currentCol - 2] == "  "))
                        {
                            MoveUpAndCaptureLeft = dict[currentRow - 2] + (currentCol - 2).ToString();
                            additionalMoves.Add(MoveUpAndCaptureLeft);
                        }
                    }
                }
                
                //Downward movement for player One king
                if( boardArray[currentRow, currentCol] == player.King)
                {
                    if (currentRow < 7)
                    {
                        //Check Down and Right
                        if ((currentCol < 8) && (boardArray[currentRow + 1, currentCol + 1] == enemy | boardArray[currentRow + 1, currentCol + 1] == enemyKing))
                        {
                            //Check right again for free space
                            if (currentCol < 7 && boardArray[currentRow + 2, currentCol + 2] == "  ")
                            {
                                MoveDownAndCaptureRight = dict[currentRow + 2] + (currentCol + 2).ToString();
                                additionalMoves.Add(MoveDownAndCaptureRight);
                            }
                        }
                        //Check Down and Left
                        if ((currentCol > 1) && (boardArray[currentRow + 1, currentCol - 1] == enemy | boardArray[currentRow + 1, currentCol - 1] == enemyKing))
                        {
                            if ((currentCol > 2) && (boardArray[currentRow + 2, currentCol - 2] == "  "))
                            {
                                MoveDownAndCaptureLeft = dict[currentRow + 2] + (currentCol - 2).ToString();
                                additionalMoves.Add(MoveDownAndCaptureLeft);
                            }
                        }
                    }
                }
            }
            //Needs Checked below here for player two logic
            //Check for Player Two Moves
            else if (player is PlayerTwo && (boardArray[currentRow, currentCol] == "O " | boardArray[currentRow, currentCol] == "OK")) 
            {
                if (currentRow < 6)
                {
                    //Check Down Right
                    if (boardArray[currentRow + 1, currentCol + 1] == enemy | boardArray[currentRow + 1, currentCol + 1] == enemyKing)
                    {
                        //Check right again for free space
                        if (boardArray[currentRow + 2, currentCol + 2] == "  ")
                        {
                            MoveUpAndCaptureRight = dict[currentRow - 2] + dict[currentCol - 2];
                            additionalMoves.Add(MoveUpAndCaptureRight);
                        }
                    }
                    //Check Down Left
                    if (boardArray[currentRow + 1, currentCol - 1] == enemy | boardArray[currentRow + 1, currentCol - 1] == enemyKing)
                    {
                        if (boardArray[currentRow + 2, currentCol - 2] == "  ")
                        {
                            MoveUpAndCaptureLeft = dict[currentRow - 2] + dict[currentCol - 2];
                            additionalMoves.Add(MoveUpAndCaptureLeft);
                        }
                    }
                }

                //Check Upward movement for player2 king
                if (boardArray[currentRow, currentCol] == player.King)
                {
                    if (currentRow > 1)
                    {
                        //Check Up and Right
                        if (boardArray[currentRow - 1, currentCol + 1] == enemy | boardArray[currentRow - 1, currentCol + 1] == enemyKing)
                        {
                            //Check right again for free space
                            if (boardArray[currentRow - 2, currentCol + 2] == "  ")
                            {
                                MoveDownAndCaptureRight = dict[currentRow + 2] + dict[currentCol + 2];
                                additionalMoves.Add(MoveDownAndCaptureRight);
                            }
                        }
                        //Check Down and Left
                        if (boardArray[currentRow - 1, currentCol - 1] == enemy | boardArray[currentRow - 1, currentCol - 1] == enemyKing)
                        {
                            if (boardArray[currentRow - 2, currentCol - 2] == "  ")
                            {
                                MoveDownAndCaptureLeft = dict[currentRow + 2] + dict[currentCol - 2];
                                additionalMoves.Add(MoveDownAndCaptureLeft);
                            }
                        }
                    }
                }
            }//End of else if
        }
    }
}
