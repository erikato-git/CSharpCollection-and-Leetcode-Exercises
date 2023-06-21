using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    // BST: Root node is greather than left child but smaller than right child
    // OBS: This is not a balanced BST
    internal class BST
    {
        Node root;


        public void insert(Node node)
        {
            root = insertHelper(root, node);
        }

        private Node insertHelper(Node root, Node node)
        {
            int data = node.data;

            // First element in the BST
            if(root == null)
            {
                root = node;
                return root;
            }
            // left-child
            else if(data < root.data)
            {
                root.left = insertHelper(root.left, node);
            }
            // right-child
            else
            {
                root.right = insertHelper(root.right, node);
            }

            return root;
        }

        public void display()
        {
            displayHelper(root);
        }

        public void displayHelper(Node root)
        {
            if(root != null)
            {
                // increasing order
                displayHelper(root.left);
                Console.WriteLine(root.data);
                displayHelper(root.right);
            }

        }

        public bool search(int data)
        {
            return searchHelper(root, data);
        }

        private bool searchHelper(Node node, int data) 
        {
            if(node == null)    // doesn't exist
            {
                return false;
            }
            else if(node.data == data)  // found
            {
                return true;
            }
            else if(node.data > data)   // less than root
            {
                return searchHelper(node.left, data);
            }
            // bigger than root
            else
            {
                return searchHelper(node.right, data);
            }
        }


        public void remove(int data)
        {
            if (search(data))       // if found
            {
                removeHelper(root, data);
            }
            else
            {
                Console.WriteLine("Node containing that data doesn't exist");
            }
        }

        private Node removeHelper(Node root, int data)
        {
            if(root == null)
            {
                return root;
            }
            else if(data < root.data)
            {
                root.left = removeHelper(root.left, data);
            }
            else if(data > root.data)
            {
                root.right = removeHelper(root.right, data);
            }
            // Node found
            else
            {
                // check if leave-node
                if(root.left == null && root.right == null)
                {
                    root = null;
                }
                else if(root.right != null)     // Find a successor to replace the deleted node
                {
                    root.data = successor(root);
                    root.right = removeHelper(root.right, root.data);
                }
                else
                {
                    root.data = predecessor(root);
                    root.left = removeHelper(root.left,root.data);
                }
            }

            return root;
        }

        private int successor(Node root)
        {
            root = root.right;
            while(root.left != null)    // Find node most to the left below root
            {
                root = root.left;
            }
            return root.data;
        }

        private int predecessor(Node root)
        {
            root = root.left;
            while(root.right != null)       // Find node most to the right below root
            {
                root = root.right;
            }
            return root.data;
        }

        public void maxDepth()
        {
            Console.WriteLine(maxDepthHelper(root));
        }

        public int maxDepthHelper(Node root)
        {
            if(root == null)
            {
                return 0;
            }

            int depth = 1;

            if(root.left != null && root.right != null)
            {
                int leftDepth = maxDepthHelper(root.left);
                int rightDepth = maxDepthHelper(root.right);
                depth += leftDepth > rightDepth ? leftDepth : rightDepth;
            }

            if (root.left != null && root.right == null)
            {
                depth += maxDepthHelper(root.left);
            }

            if (root.left == null && root.right != null)
            {
                depth += maxDepthHelper(root.right);
            }

            return depth;
        }
    }
}
