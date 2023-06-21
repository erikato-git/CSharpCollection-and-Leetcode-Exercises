using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS_Solutions
{
    internal class Node
    {
        public string Data;
        public Node Left;
        public Node Right;

        public Node(Node left, Node right, string data) 
        {
            Left = left;
            Right = right;
            Data = data;
        }


    }
}
