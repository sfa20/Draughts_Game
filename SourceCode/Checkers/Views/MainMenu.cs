using System;

namespace Checkers.Views
{
    class MainMenu
    {
        public void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine(new string('\n', 2));
            Console.WriteLine("                            ****************************************************************");
            Console.WriteLine("                              ***************Please Select a Game Mode********************");
            Console.WriteLine("                            *****************************************************************");
            Console.WriteLine(new string('\n', 2));
            Console.WriteLine("               ╔══════════════════════════════╗  ");
            Console.WriteLine("               ║                              ║  ");
            Console.WriteLine("               ║          MAIN MENU           ║  ");
            Console.WriteLine("               ║                              ║  ");
            Console.WriteLine("               ║    1. One Player             ║  ");
            Console.WriteLine("               ║    2. Two Player             ║  ");
            Console.WriteLine("               ║    3. ScoreBoard             ║  ");
            Console.WriteLine("               ║    4. Replays                ║  ");
            Console.WriteLine("               ║    5. Rules & Controls       ║  ");
            Console.WriteLine("               ║    9. Exit                   ║  ");
            Console.WriteLine("               ║                              ║  ");
            Console.WriteLine("               ╚══════════════════════════════╝  ");
        }
    }
}
