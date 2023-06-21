using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Array_Exercises
{
    internal class ArraySolutions
    {
        public void RemoveDuplicates(int[] nums)
        {
            Array.Sort(nums);

            int index = 1;

            for (int i = 1; i < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[index] = nums[i];
                    Console.Write(nums[index] + " ");
                    index++;
                }
            }

        }


        // Buy and sell as many time as possible. Just add profit whenever the current price is higher than the previous
        public void BuyAndSellStockPart2(int[] stockPrices)
        {
            int profit = 0;

            for (int i = 1; i < stockPrices.Length; i++)
            {
                if (stockPrices[i] > stockPrices[i - 1])
                {
                    profit = profit + (stockPrices[i] - stockPrices[i - 1]);
                }
            }

            Console.WriteLine("Maximum profit: " + profit);

        }


        public void RotateArray(int[] numbers, int k)
        {
            k = k % numbers.Length;     // in case k is larger than numbers.length
            Reverse(numbers, 0, numbers.Length - 1);    // Reverse whole list
            PrintNumbers(numbers);
            Reverse(numbers, 0, k - 1);     // Reverse up to k
            PrintNumbers(numbers);
            Reverse(numbers, k, numbers.Length - 1);    // Reverse rest of the list
            PrintNumbers(numbers);
        }

        // Part of RotateArray
        private void Reverse(int[] numbers, int start, int end)
        {
            while(start < end)
            {
                int temp = numbers[start];
                numbers[start] = numbers[end];
                numbers[end] = temp;

                start++;
                end--;
            }
        }

        // Part of RotateArray
        private void PrintNumbers(int[] numbers)
        {
            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }


        public void ContainsDuplicate(int[] numbers)
        {
            Dictionary<int, int> occurences = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!occurences.ContainsKey(numbers[i]))
                {
                    occurences.Add(numbers[i], 1);
                }
                else
                {
                    occurences[numbers[i]]++;
                }
            }

            bool hasDuplicates = false;

            foreach (var item in occurences)
            {
                if(item.Value > 1)
                {
                    hasDuplicates = true;
                }
            }

            Console.WriteLine("The array contains duplicates: " + hasDuplicates);
        }



        public void IntersectionOfTwoArrays(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> occurences = new Dictionary<int, int>();

            for (int i = 0; i < arr1.Length; i++)
            {
                if (!occurences.ContainsKey(arr1[i]))
                {
                    occurences.Add(arr1[i], 1);
                }
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                if (occurences.ContainsKey(arr2[i]))
                {
                    occurences[arr2[i]]++;
                }
            }

            foreach (var item in occurences)
            {
                if(item.Value > 1)
                {
                    Console.Write(item.Key + " ");
                }
            }
        }


        public void MoveZeros(int[] numbers)
        {
            int insertPosition = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                // the index pointer will not move as much as i pointer, so it will just override a new list without zeros
                if (numbers[i] != 0)
                {
                    numbers[insertPosition] = numbers[i];
                    insertPosition++;
                }
            }

            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            while (insertPosition < numbers.Length)
            {
                numbers[insertPosition++] = 0;
            }

            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }


        }

    }
}
