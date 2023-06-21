using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class Sorting_Solutions
    {

        public void BubbleSort(int[] arr1)
        {
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                if (arr1[i] > arr1[i + 1])
                {
                    int temp = arr1[i];
                    arr1[i] = arr1[i + 1];
                    arr1[i + 1] = temp;
                }
            }

            foreach (var item in arr1)
            {
                Console.Write(item + " ");
            }
        }

    }
}
