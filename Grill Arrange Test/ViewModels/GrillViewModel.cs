using Grill_Arrange_Test.Client;
using Grill_Arrange_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grill_Arrange_Test.ViewModels
{
    /// <summary>
    /// Represents the Grill and its view logic
    /// </summary>
    public class GrillViewModel
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
        /// Retrieves menus from API
        /// </summary>
        /// <returns></returns>
        public IList<GrillMenuModel> GetMenus()
        {
            //Note: This should be replaced by a call to a Repository / Data handle layer that also 
            //handles cache. Omitted for simplicity.
            GrillMenuClient client = new GrillMenuClient(new AnonymousCredentials());
            return client.GetAll();
        }

        /// <summary>
        /// Retrieves and cooks all menus
        /// </summary>
        public void Cook()
        {
            var menus = GetMenus();
            CookMenus(menus);
        }

        /// <summary>
        /// Cooks specified menus
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        public int CookMenus(IList<GrillMenuModel> menus)
        {
            int totalRounds = 0;

            //Menus Check
            foreach (var menu in menus.OrderBy(r => r.Menu))
            {
                int itemsReady = 0;
                int rounds = 0;

                Console.WriteLine("[{0}]", menu.Menu);

                // Round Check
                while (itemsReady < menu.Items.Count)
                {
                    rounds++;
                    string roundSummary = CookRound(menu, ref itemsReady);
                    PrintRoundSummary(rounds, roundSummary);
                }
                totalRounds += rounds;
                PrintMenuTotalRounds(rounds);
            }

            PrintCookResult(totalRounds);
            return totalRounds;
        }

        /// <summary>
        /// Cook one round of the specified menu
        /// </summary>
        /// <param name="menu">Menu to cook a round from</param>
        /// <param name="itemsReady">Counter of items with entire quantity already cooked</param>
        /// <returns>string summarizing the round cooking results</returns>
        private string CookRound(GrillMenuModel menu, ref int itemsReady)
        {            
            int grillAvailableArea = GrillLength * GrillWidth;
            string roundSummary = "";

            // Items Check
            foreach (var item in menu.Items.OrderBy(i => i.Length * i.Width))
            {
                if (item.Quantity != 0)
                {
                    int itemArea = Convert.ToInt16(Math.Truncate((double)(item.Length.Value * item.Width.Value)));
                    if (itemArea <= grillAvailableArea)
                    {
                        int itemsFitting = grillAvailableArea / itemArea;
                        itemsFitting = (itemsFitting > item.Quantity) ? item.Quantity.Value : itemsFitting;

                        //Update info
                        grillAvailableArea -= itemArea * itemsFitting;
                        item.Quantity -= itemsFitting;
                        if (itemsFitting != 0)
                        {
                            roundSummary += string.Format("'{0}' x {1} | ", item.Name, itemsFitting);
                        }
                        if (item.Quantity == 0)
                        {
                            itemsReady++;
                        }
                    }
                }
            }

            return roundSummary;
        }

        /// <summary>
        /// Prints round cooked items and quantities
        /// </summary>
        /// <param name="round">Round number</param>
        /// <param name="roundSummary">Round results summary</param>
        private void PrintRoundSummary(int round, string roundSummary)
        {
            Console.WriteLine("|");
            Console.WriteLine("--> Round {0}: | {1}", round, roundSummary);
        }

        /// <summary>
        /// Prints menu closing total rounds
        /// </summary>
        /// <param name="rounds">Menu total rounds</param>
        private void PrintMenuTotalRounds(int rounds)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("(Total: {0} Rounds)", rounds);
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints global total rounds to cook all menus
        /// </summary>
        /// <param name="totalRounds">Global total rounds</param>
        private void PrintCookResult(int totalRounds)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("All menus cooked!");
            Console.WriteLine("(Global total: {0} Rounds)", totalRounds);
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
