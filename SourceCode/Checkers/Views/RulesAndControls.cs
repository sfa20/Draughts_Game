using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Views
{
    class RulesAndControls
    {
        public void DrawRules()
        {
            Console.Clear();
            Console.SetWindowSize(140, 60);

            Console.WriteLine("\n\n                            ****************************************************************");
            Console.WriteLine("                              *********************Rules and Controls********************");
            Console.WriteLine("                            *****************************************************************");


            string rules = @"   

                                                        Rules

                1. O checkers can move one space upward diagonally.  If the space is occupied by an X or XK the
                   Player can capture this as long as the next space in the same direction is free.
                
                2. X's can move one space Downward diagonally.  If the space is occupied by an O or OK the Player
                   can capture this as long as the next space in the same direction is free.

                3. Players must capture an enemy piece if a capture is available

                4. If you capture an enemy and are immediately able to capture another this is allowed as and extension of
                   your move before the turn changes to the enemy.

                5. OK and XK checkers can move in both directions on the board however the same restrictions
                   regarding capturing apply

                6. The game is won when the opposition player either cannot move or has no pieces lef

";

            string controls = @"
                    
                                                                Controls


                1. To select a piece enter the co-ordinates of the piece as represented on the grid when prompted ie C1 and press enter
                
                2. To select a move enter the co-ordinates of the cell you want to move to as represented on the board when prompted ie D2
                
                3. After your move you can press u or U to undo and retake your shot. 

";


            Console.WriteLine(rules);
            Console.WriteLine(controls);
            Console.ReadKey();

        }
    }
}
