using Grill_Arrange_Test.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grill_Arrange_Test
{
    /// <summary>
    /// Represents the Grill and its view logic
    /// </summary>
    class GrillViewModel
    {
        public int GrillLength { get; set; }
        public int GrillWidth { get; set; }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="grillLength">Grill length in cm</param>
        /// <param name="grillWidth">Grill width in cm</param>
        public GrillViewModel(int grillLength, int grillWidth)
        {
            GrillLength = grillLength;
            GrillWidth = grillWidth;
        }

        /// <summary>
        /// Retrieves and cook menus
        /// </summary>
        public void CookMenus()
        {
            GrillMenuClient client = new GrillMenuClient(new AnonymousCredentials());
            var results = client.GetAll();

            foreach (var menu in results.OrderBy(r => r.Menu))
            {
                int itemsReady = 0;
                int rounds = 0;
                string roundSummary;

                Console.WriteLine("[{0}]", menu.Menu);

                // Round
                while (itemsReady < menu.Items.Count)
                {
                    rounds++;
                    int grillAvailableArea = GrillLength * GrillWidth;
                    roundSummary = string.Format("--> Round {0}: | ", rounds);

                    // Items Check
                    foreach (var item in menu.Items.OrderBy(i => i.Length * i.Width))
                    {
                        if (item.Quantity != 0)
                        {
                            int itemArea = Convert.ToInt16(Math.Truncate((Double)(item.Length.Value * item.Width.Value)));

                            if (itemArea <= grillAvailableArea)
                            {
                                int itemsFitting = grillAvailableArea / itemArea;
                                itemsFitting = (itemsFitting > item.Quantity) ? item.Quantity.Value : itemsFitting;

                                grillAvailableArea -= itemArea * itemsFitting;
                                item.Quantity -= itemsFitting;
                                if (itemsFitting != 0)
                                {
                                    roundSummary += string.Format("'{0}' x {1} |", item.Name, itemsFitting);
                                }

                                if (item.Quantity == 0)
                                {
                                    itemsReady++;
                                }
                            }
                        }
                    }

                    Console.WriteLine("|");
                    Console.WriteLine(roundSummary);
                    
                }

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("(Total: {0} Rounds)", rounds);
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine();
            }
        }
    }
}
