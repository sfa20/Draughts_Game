using System;
using System.Collections.Generic;
using Checkers.Views;
using Checkers.Movement;

namespace Checkers.Players
{
    abstract class Player
    {
        private string draught;
        private string king;

        public Player()
        {
            draught = Draught;
            king = King;
        }

        public string Draught
        {
            get
            {
                return draught;
            }
            set
            {
                draught = value;
            }
        }

        public string King
        {
            get
            {
                return king;
            }
            set
            {
                king = value;
            }
        }

        //Gets the row from the users input
        public int GetRow(string x)
        {
            if (x.Contains("A"))
            {
                int y = 7;
                return y;
            }
            else if (x.Contains("B"))
            {
                int y = 6;
                return y;
            }
            else if (x.Contains("C"))
            {
                int y = 5;
                return y;
            }
            else if (x.Contains("D"))
            {
                int y = 4;
                return y;
            }
            else if (x.Contains("E"))
            {
                int y = 3;
                return y;
            }
            else if (x.Contains("F"))
            {
                int y = 2;
                return y;
            }
            else if (x.Contains("G"))
            {
                int y = 1;
                return y;
            }
            else if (x.Contains("H"))
            {
                int y = 0;
                return y;
            }
            else
            {
                int y = 10;
                return y;
            }
        }

        //Gets the column from the users input
        public int GetCol(string x)
        {
            if (x == ("A1") | x == ("C1") | x == ("E1") | x == ("G1"))
            {
                int y = 1;
                return y;
            }
            else if (x == "A3" | x == ("C3") | x == ("E3") | x == ("G3"))
            {
                int y = 3;
                return y;
            }
            else if (x == "A5" | x == ("C5") | x == ("E5") | x == ("G5"))
            {
                int y = 5;
                return y;
            }
            else if (x == "A7" | x == ("C7") | x == ("E7") | x == ("G7"))
            {
                int y = 7;
                return y;
            }
            else if (x == "B2" | x == ("D2") | x == ("F2") | x == ("H2"))
            {
                int y = 2;
                return y;
            }
            else if (x == "B4" | x == ("D4") | x == ("F4") | x == ("H4"))
            {
                int y = 4;
                return y;
            }
            else if (x == "B6" | x == ("D6") | x == ("F6") | x == ("H6"))
            {
                int y = 6;
                return y;
            }
            else if (x == "B8" | x == ("D8") | x == ("F8") | x == ("H8"))
            {
                int y = 8;
                return y;
            }
            else
            {
                int y = 10;
                return y;
            }
        }

        public string PickPiece(string[,] boardArray, CheckersBoard board,List<string> capturePieces, List<string> availablePieces, Player player, MoveCount playerOneMoveCount, MoveCount playerTwoMoveCount)
        {
            string choice = "XX";

            //Outputs the availabla capture pieces to choose from
            if ((player is PlayerOne | player is PlayerTwo ) && capturePieces.Count > 0)
            {
                Console.Write("Available Pieces: ");
                foreach (string availablepiece in capturePieces)
                {
                    Console.Write("{0}, ", availablepiece);
                }
            }
            //Outputs the available Pieces to choose from if no capture pieces available
            else if((player is PlayerOne | player is PlayerTwo) && availablePieces.Count > 0)
            {
                Console.Write("Available Pieces: ");
                foreach (string availablepiece in availablePieces)
                {
                    Console.Write("{0}, ", availablepiece);
                }
            }

            //Diplays Player Ones Message
            if (player is PlayerOne)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n\n Player One");
                Console.Write("\n Please select the piece you want to move:  ");
                choice = Console.ReadLine().ToUpper();
                Console.ResetColor();
            }
            //Displays Player Twos Message
            else if (player is PlayerTwo)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\n Player Two");
                Console.Write("\n Please select the piece you want to move:  ");
                choice = Console.ReadLine().ToUpper();
                Console.ResetColor();
            }
            //Handles AI Piece Selection
            else if (player is AI)
            {
                Random rand = new Random();
                string piece = null;

                //If capture piece is available pick from this list
                if (capturePieces.Count >= 1)
                {
                    piece = capturePieces[rand.Next(0, capturePieces.Count - 1)];
                    return piece;
                }
                //Otherwise pick from this list
                else
                {
                    piece = availablePieces[rand.Next(0, availablePieces.Count - 1)];
                    return piece;
                }
            }
                
            //Validates the user selection against that lists of pieces and if valid returns the selection
            if (capturePieces.Count >= 1)
            {
                foreach (string piece in capturePieces)
                {
                    if (piece == choice)
                    {
                        return choice;
                    }
                }
            }
            else if (availablePieces.Count >= 1)
                {
                    foreach (string piece in availablePieces)
                    {
                        if (piece == choice)
                        {
                            return choice;
                        }
                    }
                }
            
            return choice = "XX";
        }
        
        public string PickMove(string[,] boardArray, string piece, Dictionary<int, string> dictionary, CheckersBoard board, List<string> capturePieces, List<string> availableMoves, Player player, MoveCount playerOneMoveCount, MoveCount playerTwoMoveCount)
        {
            availableMoves.Clear();

            string choice = "XX";
            string moveUpAndCaptureRight = null;
            string moveUpAndCaptureLeft = null;
            string moveDownAndCaptureRight = null;
            string moveDownAndCaptureLeft = null;
            string moveUpAndRight = null;
            string moveUpAndLeft = null;
            string moveDownAndRight = null;
            string moveDownAndLeft = null;

            try
            {
                if (capturePieces.Count >= 1 && player is PlayerOne)
                {
                    //Gets the two possible capture moves of the selected piece
                    if (player.GetRow(piece) > 1)
                    {
                        if (boardArray[player.GetRow(piece) - 1, player.GetCol(piece) - 1] == "X " | boardArray[player.GetRow(piece) - 1, player.GetCol(piece) - 1] == "XK")
                        {
                            if (boardArray[player.GetRow(piece) - 2, player.GetCol(piece) - 2] == "  ")
                            {
                                availableMoves.Add(dictionary[player.GetRow(piece) - 2] + (player.GetCol(piece) - 2).ToString());
                                moveUpAndCaptureLeft = dictionary[player.GetRow(piece) - 2] + (player.GetCol(piece) - 2).ToString();
                            }
                        }

                        //Checks that move is valid against the game board
                        if (boardArray[player.GetRow(piece) - 1, player.GetCol(piece) + 1] == "X " | boardArray[player.GetRow(piece) - 1, player.GetCol(piece) + 1] == "XK")
                        {
                            if (boardArray[player.GetRow(piece) - 2, player.GetCol(piece) + 2] == "  ")
                            {
                                availableMoves.Add(dictionary[player.GetRow(piece) - 2] + (player.GetCol(piece) + 2).ToString());
                                moveUpAndCaptureRight = dictionary[player.GetRow(piece) - 2] + (player.GetCol(piece) + 2).ToString();
                            }
                        }
                        
                    }

                    //if King is selected gets the two possible reverse capture moves of the seleceted piece
                    if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King && player.GetRow(piece) < 6)
                    {
                        //Checks that move is valid against the game board
                        if (boardArray[player.GetRow(piece) + 1, player.GetCol(piece) - 1] == "X " | boardArray[player.GetRow(piece) + 1, player.GetCol(piece) - 1] == "XK")
                        {
                            if (boardArray[player.GetRow(piece) + 2, player.GetCol(piece) - 2] == "  ")
                            {
                                availableMoves.Add(dictionary[player.GetRow(piece) + 2] + (player.GetCol(piece) - 2).ToString());
                                moveDownAndCaptureLeft = dictionary[player.GetRow(piece) + 2] + (player.GetCol(piece) - 2).ToString();
                            }
                        }

                        if (boardArray[player.GetRow(piece) + 1, player.GetCol(piece) + 1] == "X " | boardArray[player.GetRow(piece) + 1, player.GetCol(piece) + 1] == "XK")
                        {
                            if (boardArray[player.GetRow(piece) + 2, player.GetCol(piece) + 2] == "  ")
                            {
                                availableMoves.Add(dictionary[player.GetRow(piece) + 2] + (player.GetCol(piece) + 2).ToString());
                                moveDownAndCaptureRight = dictionary[player.GetRow(piece) + 2] + (player.GetCol(piece) + 2).ToString();
                            }
                        }

                        
                    }
                    
                }
                else if (capturePieces.Count >= 1 && (player is PlayerTwo | player is AI))
                {
                    //Gets the two possible capture moves of the selected piece
                    if (player.GetRow(piece) < 6)
                    {
                        //Checks that move is valid against the game board
                        if (boardArray[player.GetRow(piece) + 1, player.GetCol(piece) - 1] == "O " | boardArray[player.GetRow(piece) + 1, player.GetCol(piece) - 1] == "OK")
                        {
                            if (boardArray[player.GetRow(piece) + 2, player.GetCol(piece) - 2] == "  ")
                            {
                                availableMoves.Add(dictionary[player.GetRow(piece) + 2] + (player.GetCol(piece) - 2).ToString());
                                moveDownAndCaptureLeft = dictionary[player.GetRow(piece) + 2] + (player.GetCol(piece) - 2).ToString();
                            }
                        }

                        if (boardArray[player.GetRow(piece) + 1, player.GetCol(piece) + 1] == "O " | boardArray[player.GetRow(piece) + 1, player.GetCol(piece) + 1] == "OK")
                        {
                            if (boardArray[player.GetRow(piece) + 2, player.GetCol(piece) + 2] == "  ")
                            {
                                availableMoves.Add(dictionary[player.GetRow(piece) + 2] + (player.GetCol(piece) + 2).ToString());
                                moveDownAndCaptureRight = dictionary[player.GetRow(piece) + 2] + (player.GetCol(piece) + 2).ToString();
                            }
                        }

                        
                    }
                    //if King is selected gets the two possible reverse capture moves of the seleceted piece
                    if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King && player.GetRow(piece) > 1)
                    {
                        //Checks that move is valid against the game board
                        if (boardArray[player.GetRow(piece) - 1, player.GetCol(piece) - 1] == "O " | boardArray[player.GetRow(piece) - 1, player.GetCol(piece) - 1] == "OK")
                        {
                            if (boardArray[player.GetRow(piece) - 2, player.GetCol(piece) - 2] == "  ")
                            {
                                availableMoves.Add(dictionary[player.GetRow(piece) - 2] + (player.GetCol(piece) - 2).ToString());
                                moveUpAndCaptureLeft = dictionary[player.GetRow(piece) - 2] + (player.GetCol(piece) - 2).ToString();
                            }
                        }

                        if (boardArray[player.GetRow(piece) - 1, player.GetCol(piece) + 1] == "O " | boardArray[player.GetRow(piece) - 1, player.GetCol(piece) + 1] == "OK")
                        {
                            if (boardArray[player.GetRow(piece) - 2, player.GetCol(piece) + 2] == "  ")
                            {
                                availableMoves.Add(dictionary[player.GetRow(piece) - 2] + (player.GetCol(piece) + 2).ToString());
                                moveUpAndCaptureRight = dictionary[player.GetRow(piece) - 2] + (player.GetCol(piece) + 2).ToString();
                            }
                        }
                    }

                }
                else if (player is PlayerOne)
                {
                    //Gets the possible capture moves for the selected checker
                    if (player.GetRow(piece) != 0)
                    {
                        //Checks that move is valid against the game board
                        if (boardArray[player.GetRow(piece) - 1, player.GetCol(piece) - 1] == "  ")
                        {
                            availableMoves.Add(dictionary[player.GetRow(piece) - 1] + (player.GetCol(piece) - 1).ToString());
                            moveUpAndLeft = dictionary[player.GetRow(piece) - 1] + (player.GetCol(piece) - 1).ToString();
                        }

                        if (boardArray[player.GetRow(piece) - 1, player.GetCol(piece) + 1] == "  ")
                        {
                            availableMoves.Add(dictionary[player.GetRow(piece) - 1] + (player.GetCol(piece) + 1).ToString());
                            moveUpAndRight = dictionary[player.GetRow(piece) - 1] + (player.GetCol(piece) + 1).ToString();
                        }

                        
                    }

                    //if king has been selected reverse moves are checked
                    if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King && player.GetRow(piece) != 7)
                    {
                        //Checks that move is valid against the game board
                        if (boardArray[player.GetRow(piece) + 1, player.GetCol(piece) - 1] == "  ")
                        {
                            availableMoves.Add(dictionary[player.GetRow(piece) + 1] + (player.GetCol(piece) - 1).ToString());
                            moveDownAndLeft = dictionary[player.GetRow(piece) + 1] + (player.GetCol(piece) - 1).ToString();
                        }


                        if (boardArray[player.GetRow(piece) + 1, player.GetCol(piece) + 1] == "  ")
                        {
                            availableMoves.Add(dictionary[player.GetRow(piece) + 1] + (player.GetCol(piece) + 1).ToString());
                            moveDownAndRight = dictionary[player.GetRow(piece) + 1] + (player.GetCol(piece) + 1).ToString();
                        }

                    }

                }
                else if (player is PlayerTwo | player is AI)
                {
                    //Gets the possible capture moves for the selected checker
                    if (player.GetRow(piece) < 7)
                    {
                        //Checks that move is valid against the game board
                        if (boardArray[player.GetRow(piece) + 1, player.GetCol(piece) - 1] == "  ")
                        {
                            availableMoves.Add(dictionary[player.GetRow(piece) + 1] + (player.GetCol(piece) - 1).ToString());
                            moveDownAndLeft = dictionary[player.GetRow(piece) + 1] + (player.GetCol(piece) - 1).ToString();
                        }

                        if (boardArray[player.GetRow(piece) + 1, player.GetCol(piece) + 1] == "  ")
                        {
                            availableMoves.Add(dictionary[player.GetRow(piece) + 1] + (player.GetCol(piece) + 1).ToString());
                            moveDownAndRight = dictionary[player.GetRow(piece) + 1] + (player.GetCol(piece) + 1).ToString();
                        }

                    }

                    //if king has been selected reverse moves are checked
                    if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King && player.GetRow(piece) > 1)
                    {
                        //Checks that move is valid against the game board
                        if (boardArray[player.GetRow(piece) - 1, player.GetCol(piece) - 1] == "  ")
                        {
                            availableMoves.Add(dictionary[player.GetRow(piece) - 1] + (player.GetCol(piece) - 1).ToString());
                            moveUpAndLeft = dictionary[player.GetRow(piece) - 1] + (player.GetCol(piece) - 1).ToString();
                        }

                        if (boardArray[player.GetRow(piece) - 1, player.GetCol(piece) + 1] == "  ")
                        {
                            availableMoves.Add(dictionary[player.GetRow(piece) - 1] + (player.GetCol(piece) + 1).ToString());
                            moveUpAndRight = dictionary[player.GetRow(piece) - 1] + (player.GetCol(piece) + 1).ToString();
                        }

                    }

                }

                if (player is PlayerOne | player is PlayerTwo)
                {
                    Console.Write("\nAvailable Moves: ");
                    foreach (string move in availableMoves)
                    {
                        Console.Write("{0}, ", move);
                    }
                }

                if (player is PlayerOne)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n\n Please enter the tile you want to move too:  ");
                    choice = Console.ReadLine().ToUpper();
                    Console.ResetColor();
                }
                else if (player is PlayerTwo)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" \n\n Please select the piece you want to move too:  ");
                    choice = Console.ReadLine().ToUpper();
                    Console.ResetColor();
                }
                else
                {

                }
                
                if (player is PlayerOne | player is PlayerTwo)
                {
                    //If move matches any of the possible moves the choice is returned
                    if (choice == moveDownAndCaptureRight | choice == moveDownAndCaptureLeft | choice == moveUpAndCaptureRight | choice == moveUpAndCaptureLeft | choice == moveDownAndRight | choice == moveDownAndLeft | choice == moveUpAndRight | choice == moveUpAndLeft)
                    {
                        return choice;
                    }
                }
                //Ai selects a random move from the available moves list
                else
                {
                    Random rand = new Random();

                    if(availableMoves.Count > 1)
                    {
                        int coinflip = rand.Next(0, availableMoves.Count);
                        return availableMoves[coinflip];
                    }
                    else
                    {
                        return availableMoves[0];
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return choice = "XX";
        }
        
        public void Move(string[,] boardArray, string piece, string move, Player player)
        {
            //Movement Up capture Up
            if (player.GetRow(piece) - player.GetRow(move) == 2)
            {
                if (player is PlayerOne)
                {
                    //Move Left and Capture
                    if(player.GetCol(piece) - player.GetCol(move) == 2)
                    {
                        if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King | player.GetRow(move) == 0)
                        {
                            boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                        }
                        else
                        {
                            boardArray[player.GetRow(move), player.GetCol(move)] = player.Draught;
                        }
                        boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                        boardArray[player.GetRow(piece) - 1, player.GetCol(piece) - 1] = "  ";
                    }
                    //Move Right and capture
                    else if (player.GetCol(move) - player.GetCol(piece) == 2)
                    {
                        if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King | player.GetRow(move) == 0)
                        {
                            boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                        }
                        else
                        {
                            boardArray[player.GetRow(move), player.GetCol(move)] = player.Draught;
                        }
                        boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                        boardArray[player.GetRow(piece) - 1, player.GetCol(piece) + 1] = "  ";
                    }
                    
                }
                else if (player is PlayerTwo | player is AI)
                {
                    //Only Player Two King can move up
                    if(boardArray[player.GetRow(piece), player.GetCol(piece)] == player.king)
                    {
                        //Move Left and Capture
                        if (player.GetCol(piece) - player.GetCol(move) == 2)
                        {
                            if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King)
                            {
                                boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                            }
                            else
                            {
                                boardArray[player.GetRow(move), player.GetCol(move)] = player.Draught;
                            }
                            boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                            boardArray[player.GetRow(piece) - 1, player.GetCol(piece) - 1] = "  ";
                        }
                        //Move Right and capture
                        else if (player.GetCol(move) - player.GetCol(piece) == 2)
                        {
                            if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King)
                            {
                                boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                            }
                            else
                            {
                                boardArray[player.GetRow(move), player.GetCol(move)] = player.Draught;
                            }
                            boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                            boardArray[player.GetRow(piece) - 1, player.GetCol(piece) + 1] = "  ";
                        }
                    }
                }
            }//End of Movement Up capture Up If

            //Move and Capture Down
            else if (player.GetRow(move) - player.GetRow(piece) == 2)
            {
                if (player is PlayerOne)
                {
                    //Move Left and Capture
                    if (player.GetCol(piece) - player.GetCol(move) == 2)
                    {
                        if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King)
                        {
                            boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                            boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                            boardArray[player.GetRow(piece) + 1, player.GetCol(piece) - 1] = "  ";
                        }
                    }
                    //Move Right and capture
                    else if (player.GetCol(move) - player.GetCol(piece) == 2)
                    {
                        if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King)
                        {
                            boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                            boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                            boardArray[player.GetRow(piece) + 1, player.GetCol(piece) + 1] = "  ";
                        }
                    }

                }
                else if (player is PlayerTwo | player is AI)
                {
                    //Move Left and Capture
                    if (player.GetCol(piece) - player.GetCol(move) == 2)
                    {
                        if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King | player.GetRow(move) == 7)
                        {
                            boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                        }
                        else
                        {
                            boardArray[player.GetRow(move), player.GetCol(move)] = player.Draught;
                        }
                        boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                        boardArray[player.GetRow(piece) + 1, player.GetCol(piece) - 1] = "  ";
                    }
                    //Move Right and capture
                    else if (player.GetCol(move) - player.GetCol(piece) == 2)
                    {
                        if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King | player.GetRow(move) == 7)
                        {
                            boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                        }
                        else
                        {
                            boardArray[player.GetRow(move), player.GetCol(move)] = player.Draught;
                        }
                        boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                        boardArray[player.GetRow(piece) + 1, player.GetCol(piece) + 1] = "  ";
                    }
                }
            }
            //End of Move and Capture Down

            //Single Movement Up
            else if (player.GetRow(piece) - player.GetRow(move) == 1)
            {
                if (player is PlayerOne)
                {
                    if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King | player.GetRow(move) == 0)
                    {
                        boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                    }
                    else
                    {
                        boardArray[player.GetRow(move), player.GetCol(move)] = player.Draught;
                    }
                    boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                }
                else if(player is PlayerTwo | player is AI)
                {
                    if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.king)
                    {
                        boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                        boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                    }
                }
            }
            //End of Single Movement Up

            //Single Movement Down
            else if (player.GetRow(move) - player.GetRow(piece)  == 1)
            {
                if (player is PlayerOne)
                {
                    if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King)
                    {
                        boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                        boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                    }
                }
                else if (player is PlayerTwo | player is AI)
                {
                    if (boardArray[player.GetRow(piece), player.GetCol(piece)] == player.King | player.GetRow(move) == 7)
                    {
                        boardArray[player.GetRow(move), player.GetCol(move)] = player.King;
                    }
                    else
                    {
                        boardArray[player.GetRow(move), player.GetCol(move)] = player.Draught;
                    }
                    boardArray[player.GetRow(piece), player.GetCol(piece)] = "  ";
                }
            }
            //End of Single Movement Down
        }
        
    }
}
