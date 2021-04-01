using System;
using Checkers.Features;
using System.Collections.Generic;

namespace Checkers.Views
{
    class Replays
    {
        public void DrawMenu(Replay replay)
        {
            int gamecounter = 1;
            int game = replay.PrevGames.Count;
            int selection = 0;
            Console.Clear();
            Console.WriteLine("                       **************************************");
            Console.WriteLine("                          *************REPLAYS************");

            Console.WriteLine("\n\nGames are listed from newest game to oldest game\n ");
            foreach (Queue<string[,]> a in replay.PrevGames)
            {
                Console.WriteLine("press {0} for game {0}", gamecounter, game);
                gamecounter++;
                game--;
            }

            Console.WriteLine("Select a game to watch" );

            while (selection == 0)
            {
                try
                {
                    selection = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                { }
            }
            
            replay.WatchGame(selection);
            
        }
    }
}
