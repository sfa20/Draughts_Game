using System;
using System.Collections.Generic;
using System.Linq;
using Checkers.Players;
using Checkers.Views;
using Checkers.Movement;
using Checkers.Features;
namespace Checkers.GameMode
{
    class SinglePlayerGame : Game
    {
        MoveDetection movement = new MoveDetection();
        ErrorMessage error = new ErrorMessage();
        WinScreen win = new WinScreen();
        public override void PlayGame(Player playerOne, Player playerTwo, Replay replay)
        {
            if (Turn)
            {
                //Sets Lists for movement
                movement.CheckMoves(BoardArray, playerOne, GetAvailablePieces, GetAvailableMoves, GetCapturePieces, Dictionary);
                
                //Adds current board to undo stack and replay queue
                Undo.AddCurrentBoardState(BoardArray);
                replay.AddCurrentBoard(BoardArray);

                //Removes duplicates from the original lists
                AvailablePieces = GetAvailablePieces.Distinct().ToList();
                AvailableMoves = GetAvailableMoves.Distinct().ToList();
                CapturePieces = GetCapturePieces.Distinct().ToList();

                #region Get Piece and move from user and check valid
                //Gets user to select a checker and confirms selected piece is valid
                string piece = playerOne.PickPiece(BoardArray, Board, CapturePieces, AvailablePieces, playerOne, PlayerOneMoveCount, PlayerTwoMoveCount);
                //loops until valid piece selected if invalid piece returned
                piece = CheckPiece(piece, playerOne);

                //Gets user to select a checker and confirms selected piece is valid
                string move = playerOne.PickMove(BoardArray, piece, Dictionary, Board,CapturePieces, AvailableMoves, playerOne, PlayerOneMoveCount, PlayerTwoMoveCount);
                //loops until valid move selected if invalid move returned
                move = CheckMove(piece, move, playerOne, CapturePieces);

                #endregion
                
                //Move Player
                playerOne.Move(BoardArray, piece, move, playerOne);
                PlayerOneMoveCount.countmoves();
                Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                
                #region Offer chance to undo move

                //Offers player chance to undo move or end turn
                string choice = Undo.UndoMessage();

                if (choice == "U")
                {
                    BoardArray = Undo.UndoMove();
                    Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);
                    PlayGame(playerOne, playerTwo, replay);
                }

                Undo.PrevMoves.Clear();

                #endregion
                
                //Checks if additional captures are avaialable
                CheckForAdditionalMoves(move, playerOne, movement, playerOne, playerTwo, replay);

                //Set turn to player Two
                Turn = false;

                #region Check for winner and end of game

                //Replay testing
                //Sets winner if player 2 can't move
                movement.CheckMoves(BoardArray, playerTwo, GetAvailablePieces, GetAvailableMoves, GetCapturePieces, Dictionary);

                if (GetAvailablePieces.Count == 0 && GetCapturePieces.Count == 0)
                {
                    Winner = true;

                    win.DrawWinner1();

                    replay.AddReplay(replay.ReplayGame);
                }

                #endregion
            }
            //Player Two
            else
            {
                //Set lists
                movement.CheckMoves(BoardArray, playerTwo, GetAvailablePieces, GetAvailableMoves, GetCapturePieces, Dictionary);
                
                //Removes Duplicates
                AvailablePieces = GetAvailablePieces.Distinct().ToList();
                AvailableMoves = GetAvailableMoves.Distinct().ToList();
                CapturePieces = GetCapturePieces.Distinct().ToList();
                
                string piece = playerTwo.PickPiece(BoardArray, Board, CapturePieces, AvailablePieces, playerTwo, PlayerOneMoveCount, PlayerTwoMoveCount);
                Console.WriteLine("AI has picked piece {0}", piece);
                Console.ReadKey();

                string move = playerTwo.PickMove(BoardArray, piece,Dictionary, Board, CapturePieces, AvailableMoves, playerTwo, PlayerOneMoveCount, PlayerTwoMoveCount);
                Console.WriteLine("AI has choson to move too {0}",move);
                Console.ReadKey();
                
                //Move Player
                playerTwo.Move(BoardArray, piece, move, playerTwo);
                PlayerTwoMoveCount.countmoves();
                Board.DrawBoard(BoardArray, PlayerOneMoveCount, PlayerTwoMoveCount);

                Turn = true;

                #region Check for winner and end of game

                //Replay testing
                //Sets winner if player 2 can't move
                movement.CheckMoves(BoardArray, playerOne, GetAvailablePieces, GetAvailableMoves, GetCapturePieces, Dictionary);

                if (GetAvailablePieces.Count == 0 && GetCapturePieces.Count == 0)
                {
                    Winner = true;

                    replay.AddReplay(replay.ReplayGame);
                    win.DrawWinner3();

                }

                #endregion
            }
        }
        
    }
}
