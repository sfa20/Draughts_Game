using System;
using System.Collections.Generic;
using System.Linq;
using Checkers.Players;
using Checkers.Views;
using Checkers.Movement;
using Checkers.Features;

namespace Checkers.GameMode
{
    class MultiPlayerGame : Game
    {
        MoveDetection movement = new MoveDetection();
        ErrorMessage error = new ErrorMessage();
        WinScreen win = new WinScreen();
        bool moveUndone = false;
        
        public override void PlayGame(Player playerOne, Player playerTwo, Replay replay)
        { 
            if (Turn)
            {
                //Sets Lists for movement
                movement.CheckMoves(BoardArray, playerOne, GetAvailablePieces, GetAvailableMoves, GetCapturePieces, Dictionary);
                //displaymovement(playerOne, playerTwo, GetAvailablePieces, GetAvailableMoves, GetCapturePieces, GetCaptureMoves);
                
                Undo.AddCurrentBoardState(BoardArray);

                replay.AddCurrentBoard(BoardArray);

                //Removes duplicate pieces and moves
                AvailablePieces = GetAvailablePieces.Distinct().ToList();
                AvailableMoves = GetAvailableMoves.Distinct().ToList();
                CapturePieces = GetCapturePieces.Distinct().ToList();

                #region Get Piece and move from user and check valid
                
                //Gets user to select a checker and confirms selected piece is valid
                string piece = playerOne.PickPiece(BoardArray, Board, CapturePieces, AvailablePieces,playerOne, PlayerOneMoveCount, PlayerTwoMoveCount);
                //loops until valid piece selected if invalid piece returned
                piece = CheckPiece(piece, playerOne);

                //Gets user to select a checker and confirms selected piece is valid
                string move = playerOne.PickMove(BoardArray, piece, Dictionary, Board, CapturePieces, AvailableMoves, playerOne, PlayerOneMoveCount, PlayerTwoMoveCount);
                //loops until valid move selected if invalid move returned
                move = CheckMove(piece, move, playerOne, CapturePieces);
                
                #endregion

                //Move Player
                playerOne.Move(BoardArray, piece, move, playerOne);
                PlayerOneMoveCount.countmoves();
                Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                
                replay.AddCurrentBoard(BoardArray);

                #region Offer chance to undo move

                string choice = Undo.UndoMessage();

                if (choice == "U")
                {
                    BoardArray = Undo.UndoMove();
                    Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                    PlayGame(playerOne, playerTwo, replay);
                }

                //Reset Undo Move List
                Undo.PrevMoves.Clear();

                #endregion

                Undo.AddCurrentBoardState(BoardArray);
                replay.AddCurrentBoard(BoardArray);

                CheckForAdditionalMoves(move, playerOne, movement, playerOne, playerTwo, replay);
                
                //Set Turn to Player Two
                Turn = false;

                #region Check for winner and end of game
                
                //Sets winner if player 2 can't move
                movement.CheckMoves(BoardArray, playerTwo, GetAvailablePieces, GetAvailableMoves, GetCapturePieces, Dictionary);
                
                if (GetAvailablePieces.Count == 0 && GetCapturePieces.Count == 0)
                {
                    Winner = true;

                    replay.AddReplay(replay.ReplayGame);
                    win.DrawWinner1();

                }
                
                #endregion
            }
            //Player Two
            else
            {
                movement.CheckMoves(BoardArray, playerTwo, GetAvailablePieces, GetAvailableMoves, GetCapturePieces, Dictionary);

                Undo.AddCurrentBoardState(BoardArray);
                replay.AddCurrentBoard(BoardArray);
                
                AvailablePieces = GetAvailablePieces.Distinct().ToList();
                AvailableMoves = GetAvailableMoves.Distinct().ToList();
                CapturePieces = GetCapturePieces.Distinct().ToList();

                #region Get Piece and Move from user and check valid
                
                //Gets user to select a checker and confirms selected piece is valid
                string piece = playerTwo.PickPiece(BoardArray, Board, CapturePieces, AvailablePieces, playerTwo, PlayerOneMoveCount, PlayerTwoMoveCount);
                
                //loops until valid piece selected if invalid piece returned
                piece = CheckPiece(piece, playerTwo);
                
                //Gets user to select a checker and confirms selected piece is valid
                string move = playerTwo.PickMove(BoardArray, piece, Dictionary, Board, CapturePieces, AvailableMoves, playerTwo, PlayerOneMoveCount, PlayerTwoMoveCount);
                
                //loops until valid move selected if invalid move returned
                move = CheckMove(piece, move, playerTwo, CapturePieces);

                #endregion

                //Move Player
                playerTwo.Move(BoardArray, piece, move, playerTwo);
                PlayerTwoMoveCount.countmoves();
                Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                
                #region Undo

                string choice = Undo.UndoMessage();

                if (choice == "U")
                {
                    BoardArray = Undo.UndoMove();
                    Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                    PlayGame(playerOne, playerTwo, replay);
                }

                #endregion
                
                replay.AddCurrentBoard(BoardArray);
                Undo.AddCurrentBoardState(BoardArray);

                CheckForAdditionalMoves(move, playerTwo, movement, playerOne, playerTwo, replay);

                //Reset Undo Move List
                Undo.PrevMoves.Clear();

                Turn = true;

                #region Check for Winner and end of game

                //Replay testing
                movement.CheckMoves(BoardArray, playerOne, GetAvailablePieces, GetAvailableMoves, GetCapturePieces, Dictionary);
                
                if (GetAvailablePieces.Count == 0 && CapturePieces.Count == 0)
                {
                    Winner = true;
                    
                    replay.AddReplay(replay.ReplayGame);
                    win.DrawWinner1();
                }

                #endregion
            }
        }
        
    }
}
