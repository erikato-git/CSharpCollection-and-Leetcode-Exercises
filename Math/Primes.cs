using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    internal class Primes
    {
        public HashSet<int> PrimeNumbers = new HashSet<int>();

        public void PrimesInRange(int n)
        {
            // Starter ved 2 - 1 går op i 1
            for (int i = 2; i < n; i++)
            {
                bool isPrime = true;
                for(int j = 1; j <= i; j++)
                {
                    // 1 går op i alt, j og i må ikke være det samme for eg. 4 % 4 == 0
                    if(i % j == 0 && j != 1 && i != j)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                {
                    PrimeNumbers.Add(i);
                }
            }

            // Print prime numbers

            foreach(var i in PrimeNumbers)
            {
                Console.WriteLine(i);
            }
        }

    }
}
