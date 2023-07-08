using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    // Implementing a queue with an array, FIFO: First-In-First-Out
    internal class Queue
    {
        public int Count = 0;
        public int[] QueueArray;

        public Queue(int[] init)
        {
            QueueArray = init;
        }


        public void Enqueue(int element)
        {
            // new array
            int[] newArray = new int[QueueArray.Length + 1];
            newArray[0] = element;

            // Fill in the old array to the new one shifted one place to the right
            for (int i = 1; i < newArray.Length; i++)
            {
                newArray[i] = QueueArray[i - 1];
            }

            QueueArray = newArray;

        }
        
        public void Dequeue()
        {
            int last = QueueArray[QueueArray.Length-1];

            int[] newArr = new int[QueueArray.Length - 1];

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = QueueArray[i];
            }

            QueueArray = newArr;

        }


        public void PrintOutQueue()
        {
            foreach (var item in QueueArray)
            {
                Console.Write(item + " ");
            }
        }

        public void Front()
        {
            Console.WriteLine(QueueArray[0]);
        }



    }
}
