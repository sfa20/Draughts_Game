using System;
using Checkers.Views;
using Checkers.GameMode;
using Checkers.Players;
using Checkers.Features;
using System.Threading;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            StartScreen image = new StartScreen();
            MainMenu mainMenu = new MainMenu();

            PlayerOne playerOne = new PlayerOne();
            PlayerTwo playerTwo = new PlayerTwo();
            AI Arti = new AI("X ", "XK");
            Replay replay = new Replay();
            
            //Draw SplashScreen
            image.DrawScreen();
            Thread.Sleep(2500);
            Console.Clear();

            int selection = 0;

            //Display menu will selection not equal to 9 - 9 being the exit condition for the program
            while (selection != 9)
            {
                mainMenu.DrawMenu();
                Console.Write("Please make a selection: ");
                //Try catch cathes exception caused by empty input
                try
                {
                    selection = int.Parse(Console.ReadLine());
                }
                catch(Exception ex )
                {
                }

                switch (selection)
                {
                    case 1:
                        SinglePlayerGame singlePlayer = new SinglePlayerGame();
                        singlePlayer.Start(playerOne, Arti, replay);
                        break;
                    case 2:
                        MultiPlayerGame multiPlayer = new MultiPlayerGame();
                        multiPlayer.Start(playerOne, playerTwo, replay);
                        break;
                    case 3:
                        Replays replays = new Replays();
                        replays.DrawMenu(replay);
                        break;
                    case 4:
                        RulesAndControls rulesAndControls = new RulesAndControls();
                        rulesAndControls.DrawRules();
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("\nYou have not selected a valid option, Please try again");
                        Console.WriteLine("\n          Press Enter to Continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
