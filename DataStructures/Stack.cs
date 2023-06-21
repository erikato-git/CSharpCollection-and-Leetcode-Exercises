using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Stack
    {
        int[] StackArray;

        public Stack() 
        {
            StackArray = new int[0];
        }

        public void Push(int number)
        {
            if(StackArray.Length == 0)
            {
                int[] newarr = new int[StackArray.Length + 1];
                newarr[0] = number;
                StackArray = newarr;
            }
            else
            {
                int[] newArr = new int[StackArray.Length + 1];
                newArr[0] = number;

                for (int i = 1; i < newArr.Length; i++)
                {
                    newArr[i] = StackArray[i - 1];
                }

                StackArray = newArr;
            }

        }

        public void Pop()
        {
            if(StackArray.Length > 0 ) 
            {
                int pop = StackArray[0];
                int[] newArr = new int[StackArray.Length-1];

                for (int i = 0; i < newArr.Length; i++)
                {
                    newArr[i] = StackArray[i + 1];
                }
                StackArray = newArr;
            }
            else
            {
                return;
            }
        }

        public void PrintStack()
        {
            foreach (var item in StackArray)
            {
                Console.Write(item + " ");
            }
        }
    }
}
