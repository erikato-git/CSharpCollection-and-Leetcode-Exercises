using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS_Solutions
{
    internal class BFS_DFS
    {
        public void bfs_traversal(Node node)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);

            while (q.Count > 0)
            {
                node = q.Dequeue();
                Console.WriteLine(node.Data + " ");

                if(node.Left!= null)
                {
                    q.Enqueue((Node)node.Left);
                }

                if(node.Right!= null)
                {
                    q.Enqueue((Node)node.Right);
                }
            }

        }


        public void dfs_traversal(Node node)
        {
            Stack<Node> q = new Stack<Node>();
            q.Push(node);

            while (q.Count > 0)
            {
                node = q.Pop();
                Console.WriteLine(node.Data + " ");

                if (node.Left != null)
                {
                    q.Push((Node)node.Left);
                }

                if (node.Right != null)
                {
                    q.Push((Node)node.Right);
                }
            }

        }
    }
}
