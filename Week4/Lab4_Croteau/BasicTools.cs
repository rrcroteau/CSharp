using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Croteau
{
    public class BasicTools
    {
        /// <summary>
        /// Causes the program to pause until user hits Enter key
        /// </summary>

        public static void Pause()
        {
        
            //print a prompt
            Console.WriteLine("\n\nPress the Enter key to continue");

            //use input to cause system to wait for Enter key to be pressed
            Console.Read();

        }
            
    }
}
