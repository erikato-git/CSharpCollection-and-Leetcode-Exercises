using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    
    internal class BuyAndSellStock
    {
        private int[] stockPrices = { 7, 1, 5, 3, 6, 4 };
    
        public void Method()
        {
            int buy_price = stockPrices[0];

            int max_profit = 0;

            for (int i = 1; i < stockPrices.Length; i++)
            {
                // if new buying price is lower - change buying price
                if(buy_price > stockPrices[i])
                {
                    buy_price = stockPrices[i];
                }
                else
                {
                    int current_profit = stockPrices[i] - buy_price;
                    max_profit = Math.Max(current_profit, max_profit);      // if new current profit is bigger change max_profit
                }
            }

            Console.WriteLine("Maximum profit: " + max_profit);
        }
    }
}
