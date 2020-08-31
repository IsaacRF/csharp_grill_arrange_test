using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grill_Arrange_Test
{
    class Grill
    {
        public int[][] grillSpace;

        public Grill(int grillLength, int grillWidth)
        {           
            InitializeGrill(grillLength, grillWidth);
        }

        /// <summary>
        /// Initializes grill with specified size
        /// </summary>
        /// <param name="grillLength">Grill length in cm</param>
        /// <param name="grillWidth">Grill width in cm</param>
        private void InitializeGrill(int grillLength, int grillWidth)
        {
            grillSpace = new int[grillLength][];
            //Initialize grill space
            for (int i = 0; i < grillSpace.Length; i++)
            {
                grillSpace[i] = new int[grillWidth];
            }
        }

        /// <summary>
        /// Checks if there is enough remaining space in the grill for specified item size
        /// </summary>
        /// <param name="length">Item length</param>
        /// <param name="width">Item width</param>
        /// <returns>True if there is space</returns>
        /// TODO: Need to return WHERE the available space is located rather than true or false
        public bool IsThereRoom(int length, int width)
        {
            List<int> rowsWithSpace = new List<int>();
            List<int> colsWithSpace = new List<int>();

            //Search for space horizontally
            for (int i = 0; i < grillSpace.Length; i++)
            {
                bool isRoomInRow = grillSpace[0].Where(cell => (cell == 0)).Count() >= length;
                if (isRoomInRow)
                {
                    rowsWithSpace.Add(i);
                }
            }
            if (rowsWithSpace.Count >= width)
            {
                return true;
            }

            //Search for space vertically
            for (int j = 0; j < grillSpace[0].Length; j++)
            {
                bool isRoomInCol = GetColumn(j).Where(cell => (cell == 0)).Count() >= length;
                if (isRoomInCol)
                {
                    colsWithSpace.Add(j);
                }
            }
            if (colsWithSpace.Count >= width)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Pretty prints the grill distribution showing the id of the element in every
        /// cell
        /// </summary>
        public void PrintGrill()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.WriteLine("grill[{0},{1}] = {2}", i, j, grillSpace[i][j]);
                }
            }
        }

        /// <summary>
        /// Returns column in specified index
        /// </summary>
        /// <param name="index">Column Index</param>
        /// <returns>int[] with the column content</returns>
        public int[] GetColumn(int index)
        {
            return grillSpace
                .Where(o => (o != null && o.Count() > index))
                .Select(o => o[index])
                .ToArray();
        }
    }
}
