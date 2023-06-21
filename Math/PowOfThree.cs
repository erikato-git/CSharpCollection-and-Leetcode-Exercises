using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    internal class PowOfThree
    {
        // test if integers inserted in the exponent of 3 until the number is smaller than the arg
        public void IsPowerOfThree(int n)
        {
            int i = 0;
            int sum = 0;

            while(sum < n)
            {
                sum = (int)System.Math.Pow(3, i);
                i++;

            }

            if(sum % 3 == 0 && sum <= n) 
            {
                Console.WriteLine("Arg is power of three");
            }
            else
            {
                Console.WriteLine("Arg is not power of three");
            }

        }
    }
}
