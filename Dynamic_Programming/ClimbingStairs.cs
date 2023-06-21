using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    internal class ClimbingStairs
    {
        public void Method(int n)
        {
            if (n == 0)
            {
                Console.WriteLine("Invalid argument");
                return;
            }

            if (n == 1)
            {
                Console.WriteLine("1 possible way");
                return;
            }
            
            int[] differentPaths = new int[n + 1];
            differentPaths[1] = 1;
            differentPaths[2] = 2;

            // Amount of different paths follows a fibonacci sequence, Ask how many possible ways the current path require: the sum of possible ways for one step and two steps ago
            for (int i = 3; i <= n; i++)
            {
                differentPaths[i] = differentPaths[i - 1] + differentPaths[i - 2];
                Console.WriteLine("Step {0}: {1}", i, differentPaths[i]);
            }

            Console.WriteLine("Amount of different paths: {0}", differentPaths[n]);
        }
    }
}
