using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Views
{
    class ErrorMessage
    {
        public void DisplayCaptureError()
        {
                Console.Clear();
                Console.WriteLine("           ***********************************************");
                Console.WriteLine("           ***                                         ***");
                Console.WriteLine("           ***    Force Capture on! You must Attack    ***");
                Console.WriteLine("           ***                                         ***");
                Console.WriteLine("           ***********************************************");
                Console.WriteLine("\n\n              Press Any Key to continue");
                Console.ReadKey();
                Console.Clear();
        }

        public void DisplayMoveError()
        {
            Console.Clear();
            Console.WriteLine("           ***********************************************");
            Console.WriteLine("           ***                                         ***");
            Console.WriteLine("           ***   You have not selected a valid move    ***");
            Console.WriteLine("           ***                                         ***");
            Console.WriteLine("           ***********************************************");
            Console.WriteLine("\n\n              Press Any Key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplayPieceError()
        {
            Console.Clear();
            Console.WriteLine("           ***********************************************");
            Console.WriteLine("           ***                                         ***");
            Console.WriteLine("           ***   You have not selected a valid Piece   ***");
            Console.WriteLine("           ***                                         ***");
            Console.WriteLine("           ***********************************************");
            Console.WriteLine("\n\n              Press Any Key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
