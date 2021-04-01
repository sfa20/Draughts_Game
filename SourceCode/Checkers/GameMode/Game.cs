using System;
using System.Collections.Generic;
using Checkers.Players;
using Checkers.Views;
using Checkers.Movement;
using Checkers.Features;

namespace Checkers.GameMode
{
    abstract class Game
    {
        //Create 2D array to  be mapped to grid
        private string[,] boardArray = new string[8, 10];
        private bool turn;
        private bool winner;
        private Dictionary<int, string> dictionary = new Dictionary<int, string>();

        List<string> getAvailablePieces = new List<string>();
        List<string> getAvailableMoves = new List<string>();
        List<string> getCapturePieces = new List<string>();
        List<string> getAdditionalMoves = new List<string>();
        
        List<string> availablePieces;
        List<string> availableMoves;
        List<string> capturePieces;
        
        MoveCount playerOneMoveCount = new MoveCount();
        MoveCount playerTwoMoveCount = new MoveCount();

        Undo undo = new Undo();

        CheckersBoard board = new CheckersBoard();

        public MoveCount PlayerOneMoveCount
        {
            get
            {
                return playerOneMoveCount;
            }
            set
            {
                playerOneMoveCount = value;
            }
        }

        public MoveCount PlayerTwoMoveCount
        {
            get
            {
                return playerTwoMoveCount;
            }
            set
            {
                playerTwoMoveCount = value;
            }
        }

        public CheckersBoard Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
            }
        }

        public Undo Undo
        {
            get
            {
                return undo;
            }
            set
            {
                undo = value;
            }
        }

        public string[,] BoardArray
        {
            get
            {
                return boardArray;
            }
            set
            {
                boardArray = value;
            }
        }

        public bool Turn
        {
            get
            {
                return turn;
            }
            set
            {
                turn = value;
            }
        }

        public bool Winner
        {
            get
            {
                return winner;
            }
            set
            {
                winner = value;
            }
        }

        public Dictionary<int, string> Dictionary
        {
            get
            {
                return dictionary;
            }
            set
            {
                dictionary = value;
            }
        }

        public List<string> GetAvailablePieces
        {
            get
            {
                return getAvailablePieces;
            }
            set
            {
                getAvailablePieces = value;
            }
        }

        public List<string> GetAvailableMoves
        {
            get
            {
                return getAvailableMoves;
            }
            set
            {
                getAvailableMoves = value;
            }
        }

        public List<string> GetCapturePieces
        {
            get
            {
                return getCapturePieces;
            }
            set
            {
                getCapturePieces = value;
            }
        }

        public List<string> GetAdditionalMoves
        {
            get
            {
                return getAdditionalMoves;
            }
            set
            {
                getAdditionalMoves = value;
            }
        }

        public List<string> AvailablePieces
        {
            get
            {
                return availablePieces;
            }
            set
            {
                availablePieces = value;
            }
        }

        public List<string> AvailableMoves
        {
            get
            {
                return availableMoves;
            }
            set
            {
                availableMoves = value;
            }
        }

        public List<string> CapturePieces
        {
            get
            {
                return capturePieces;
            }
            set
            {
                capturePieces = value;
            }
        }

        public void SetDict(Dictionary<int, string> dictionary)
        {
            dictionary.Add(0, "H");
            dictionary.Add(1, "G");
            dictionary.Add(2, "F");
            dictionary.Add(3, "E");
            dictionary.Add(4, "D");
            dictionary.Add(5, "C");
            dictionary.Add(6, "B");
            dictionary.Add(7, "A");
        }

        public void Start(Player playerOne, Player playerTwo, Replay replay)
        {
            board.CreateBoard(BoardArray, playerOne, playerTwo);
            board.DrawBoard(BoardArray, playerOneMoveCount, playerTwoMoveCount);

            SetDict(Dictionary);

            //Set Turn to player one and winner to false
            Turn = true;
            Winner = false;

            //Start Game and Loop till Winner found
            while (!Winner)
            {
                PlayGame(playerOne, playerTwo, replay);
            }
        }

        abstract public void PlayGame(Player playerOne, Player playerTwo, Replay replay);

        public string CheckPiece(string piece, Player player)
        {
            ErrorMessage error = new ErrorMessage();

            while (piece == "XX")
            {
                if (CapturePieces.Count >= 1)
                {
                    error.DisplayCaptureError();
                    Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                    piece = player.PickPiece(BoardArray, Board, CapturePieces, AvailablePieces, player, PlayerOneMoveCount, PlayerTwoMoveCount);
                }
                else
                {
                    error.DisplayPieceError();
                    Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                    piece = player.PickPiece(BoardArray, Board, CapturePieces, AvailablePieces, player, PlayerOneMoveCount, PlayerTwoMoveCount);
                }
            }
            return piece;
        }

        public string CheckMove(string piece, string move, Player player, List<string> CapturePieces)
        {
            ErrorMessage error = new ErrorMessage();

            while (move == "XX")
            {
                if (CapturePieces.Count >= 1)
                {
                    error.DisplayCaptureError();
                    Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                    Console.WriteLine("Checker {0} is currently selected", piece);
                    move = player.PickMove(BoardArray, piece, Dictionary, Board, CapturePieces, AvailableMoves, player, PlayerOneMoveCount, PlayerTwoMoveCount);
                    
                }
                else
                {
                    error.DisplayMoveError();
                    Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                    Console.WriteLine("Checker {0} is currently selected\n", piece);
                    move = player.PickMove(BoardArray, piece, Dictionary, Board, CapturePieces, AvailableMoves, player, PlayerOneMoveCount, PlayerTwoMoveCount);
                   
                }
            }
            return move;
        }

        public void CheckForAdditionalMoves(string move, Player player, MoveDetection movement,Player playerOne, Player playerTwo, Replay replay)
        {
            bool pieceTaken = false;

            if (CapturePieces.Count >= 1)
            {
                pieceTaken = true;
            }

            while (pieceTaken)
            {
                //Sets the piece to the move that has just taken place as this is where the draught is now located
                string piece = move;

                movement.FindAdditionalMoves(BoardArray, player, move, GetAdditionalMoves, Dictionary);
                
                if (GetAdditionalMoves.Count >= 1)
                {
                    int counter = 1;
                    foreach (string a in GetAdditionalMoves)
                    {
                        Console.WriteLine("Move {0}: {1}", counter, a);
                        counter++;
                    }

                    Console.WriteLine("\n Piece {0} is currently selected, Another move is available!", move);
                    Console.WriteLine();

                    GetAdditionalMoves.Clear();
                }
                else
                {
                    pieceTaken = false;
                }

                if (pieceTaken)
                {
                    //Gets user to select a checker and confirms selected piece is valid
                    move = player.PickMove(BoardArray, piece, Dictionary, Board, CapturePieces, AvailableMoves, player, PlayerOneMoveCount, PlayerTwoMoveCount);
                    //loops until valid move selected if invalid move returne d
                    move = CheckMove(piece, move, player, CapturePieces);

                    Undo.AddCurrentBoardState(BoardArray);
                    replay.AddCurrentBoard(BoardArray);
                    
                    //Move Player
                    player.Move(BoardArray, piece, move, player);
                    PlayerOneMoveCount.countmoves();
                    Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                   
                    string choice = Undo.UndoMessage();

                    if (choice == "U")
                    {
                        BoardArray = Undo.UndoMove();
                        Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                        PlayGame(playerOne, playerTwo, replay);
                    }

                    Undo.AddCurrentBoardState(BoardArray);
                    replay.AddCurrentBoard(BoardArray);
                    
                }
            }
        }
    }
}
