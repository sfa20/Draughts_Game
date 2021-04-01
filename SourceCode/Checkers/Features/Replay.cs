using System;
using System.Collections.Generic;
using System.Timers;
using Checkers.Views;
using Checkers.Movement;
using System.Threading;

namespace Checkers.Features
{
    class Replay
    {
        List<Queue<string[,]>> prevGames = new List<Queue<string[,]>>();

        Queue<string[,]> replayGame = new Queue<string[,]>();

        public Queue<string[,]> ReplayGame
        {
            get
            {
                return replayGame;
            }
            set
            {
                replayGame = value;
            }
        }
        public List<Queue<string[,]>> PrevGames
        {
            get
            {
                return prevGames;
            }
            set
            {
                prevGames = value;
            }
        }


        public void AddReplay(Queue<string[,]> game)
        {
            PrevGames.Add(game);
        }

        public void AddCurrentBoard(string[,] boardArray)
        {
            string[,] currentState = boardArray.Clone() as string[,];
            ReplayGame.Enqueue(currentState);
        }
        
        public void WatchGame(int selection)
        {
            CheckersBoard board = new CheckersBoard();
            MoveCount playerOne = new MoveCount();
            MoveCount playerTwo = new MoveCount();



            Queue<string[,]> temp1 = prevGames[selection-1];


            if (temp1.Count >= 1)
            {
                string[,] temp = temp1.Dequeue();
                board.DrawBoard(temp, playerOne, playerTwo);
                Thread.Sleep(3000);
                WatchGame(selection);
            }
            else
            {
                Console.WriteLine("End of Replay");

                Console.ReadKey();
            }

        }


        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            
        }
    }
}
