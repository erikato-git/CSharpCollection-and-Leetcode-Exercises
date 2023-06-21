using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_list
{
    internal class Node
    {
        public int Value { get; }
        public Node Next { get; set; }

        public Node(int init)
        {
            Value = init;
        }

    }
}
