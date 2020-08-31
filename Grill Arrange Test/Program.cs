using Grill_Arrange_Test.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grill_Arrange_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            GrillViewModel grill = new GrillViewModel(20, 30);
            grill.CookMenus();
            Console.ReadKey();
        }
    }
}
