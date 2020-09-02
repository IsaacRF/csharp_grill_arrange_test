using Grill_Arrange_Test.Client;
using Grill_Arrange_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grill_Arrange_Test
{
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// App entry point
        /// </summary>
        /// <param name="args">Launch args</param>
        static void Main(string[] args)
        {
            int grillLength = 20;
            int grillWidth = 30;
            bool validLength = false;
            bool validWidth = false;

            while (!validLength)
            {
                Console.WriteLine("Enter a valid Grill Length");
                validLength = int.TryParse(Console.ReadLine(), out grillLength);
            }
            while (!validWidth)
            {
                Console.WriteLine("Enter a valid Grill Width");
                validWidth = int.TryParse(Console.ReadLine(), out grillWidth);
            }
           
            Console.WriteLine("Creating a {0}x{1} grill...", grillLength, grillWidth);
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();

            GrillViewModel grill = new GrillViewModel(grillLength, grillWidth);
            grill.Cook();
            Console.ReadKey();
        }
    }
}
