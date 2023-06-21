using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    // House Robber: find maximum loot (values in int-array). Positions cannot be beside each other
    internal class HouseRobber
    {
        public int[] HouseLoots = { 2, 7, 3, 1, 4, 2, 1, 8 };
        
        public void Method()
        {
            // Contains the current max-loot
            int[] maxLoot = new int[HouseLoots.Length];

            maxLoot[0] = HouseLoots[0];
            maxLoot[1] = Math.Max(HouseLoots[0], HouseLoots[1]);

            for (int i = 2; i < HouseLoots.Length; i++)
            {
                // Check if last max-loot is higher than the next and two steps back max-loot
                maxLoot[i] = Math.Max(maxLoot[i - 2] + HouseLoots[i], maxLoot[i - 1]);
            }

            foreach (var item in maxLoot)
            {
                Console.Write(item + " ");
            }
        }
    }
}
