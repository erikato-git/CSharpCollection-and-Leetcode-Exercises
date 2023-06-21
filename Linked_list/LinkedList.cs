using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_list
{
    internal class LinkedList
    {
        public Node Head;
        public int Count;

        public LinkedList() 
        {
            Head = null;
            Count = 0;
        }

        public void AddNodeToFront(Node node)
        {
            node.Next = Head;
            Head = node;
            Count++;
        }

        public void PrintLinkedList()
        {
            Node node = Head;

            while(node != null)
            {
                Console.Write(node.Value + " ");
                node = node.Next;
            }
        }

        public void RemoveNode(Node nodeToDelete)
        {
            Node indexNode = Head;

            if(nodeToDelete == Head)
            {
                Head = nodeToDelete.Next;
            }

            while (indexNode != null)
            {
                if(indexNode.Next == nodeToDelete)
                {
                    // Jump over nodeToDelete
                    indexNode.Next = nodeToDelete.Next;
                }

                indexNode = indexNode.Next;
            }

        }


        public void ReverseLinkedList()
        {
            Stack<Node> stack = new Stack<Node>();      // For Last-In-First-Out
            Node node = Head;
            stack.Push(node);

            while (node != null)
            {
                node = node.Next;
                if(node != null )
                {
                    stack.Push(node);
                }
            }

            Node topNode = stack.Pop();
            List<Node> reversedLinkedList = new List<Node>();
            reversedLinkedList.Add(topNode);

            while(stack.Count > 0)
            {
                topNode.Next = stack.Pop();
                topNode = topNode.Next;
                reversedLinkedList.Add(topNode);
            }

            foreach(var i in reversedLinkedList)
            {
                Console.Write(i.Value + " ");
            }
        }



    }
}
