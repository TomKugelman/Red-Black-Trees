using System;
using System.Diagnostics;

namespace Red_Black_Trees
{
    class RedBlackTree
    {
        public RedBlackNode root = new RedBlackNode("root");
        public bool rootSet = false;
        public int numOfLeafs = 0;

        public void InsertNode(int value)
        {
            RedBlackNode newNode = new RedBlackNode();
            newNode.key = value;
            newNode.SetColor("red");
            RedBlackNode current = root;
            RedBlackNode parent = current;

            bool done = false;

            if (!rootSet)
            {
                root.key = value;
                root.SetColor("black");
                rootSet = true;
            }
            else
            {
                while (!done)
                {
                    parent = current;

                    if (value < current.key)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            newNode.parent = parent;
                            done = true;
                            Rebalance(newNode);
                        }
                    }
                    else if (value > current.key)
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            newNode.parent = parent;
                            done = true;
                            Rebalance(newNode);
                        }
                    }
                }
            }
        }
    
        public void InOrder(RedBlackNode node)
        {
            if (node != null)
            {
                InOrder(node.leftChild);
                // If the node has no parent it is the root
                if (node.parent == null)
                    Console.WriteLine(" | " + node.key.ToString() + " - " + node.color + " | - Root");
                else 
                    Console.WriteLine(" | " + node.key.ToString() + " - " + node.color);
                if(node.rightChild == null && node.leftChild == null)
                    numOfLeafs++;
                InOrder(node.rightChild);
            }
        }

        public int FindMin(int value)
        {
            bool found = false;
            RedBlackNode current = root;

            while(!found)
            {
                if (current.key == value)
                {
                    found = true;
                }
                else if (value < current.key)
                {
                    current = current.leftChild;
                }
                else if (value > current.key)
                {
                    current = current.rightChild;
                }
            }

            if (found)
            {
                while (current.leftChild != null)
                {
                    current = current.leftChild;
                }
                return current.key;
            }
            else
            {
                return -1;
            }
        }

        public int FindMax(int value)
        {
            bool found = false;
            RedBlackNode current = root;

            while (!found)
            {
                if (current.key == value)
                {
                    found = true;
                }
                else if (value < current.key)
                {
                    current = current.leftChild;
                }
                else if (value > current.key)
                {
                    current = current.rightChild;
                }
            }

            if (found)
            {
                while (current.rightChild != null)
                {
                    current = current.rightChild;
                }
                return current.key;
            }
            else
            {
                return -1;
            }
        }

        public int NumOfNodes()
        {
            return CountNodes(root);
        }

        public int CountNodes(RedBlackNode node)
        {
            if (node == null)
                return 0;
            else
                return CountNodes(node.leftChild) + CountNodes(node.rightChild) + 1;
        }

        private void Rebalance(RedBlackNode node)
        {
            
            if (node != null)
            {
                // Always make sure the root is black. Brute force assigning works here because
                // this function does not act as if the local parameter is the root like the rotation functions do
                if (root.Red)
                    root.SetColor("BLACK");

                if (node.Red)
                {
                    if (node.parent.Red)
                    {
                        if (node.parent.rightChild != null && node == node.parent.rightChild)
                        {
                            if (node.parent.parent.rightChild != null && node.parent == node.parent.parent.rightChild)
                            {
                                if (node.parent.parent.leftChild == null || node.parent.parent.leftChild.Black)
                                {
                                    LeftRotation(node.parent.parent);
                                }
                                else if (node.parent.parent.leftChild.Red)
                                {
                                    ColorFlip(node);
                                }
                            }
                            else if (node.parent.parent.leftChild != null &&  node.parent == node.parent.parent.leftChild)
                            {
                                if (node.parent.parent.rightChild == null || node.parent.parent.rightChild.Black)
                                {
                                    LeftRightRotation(node.parent.parent);
                                }
                                else if (node.parent.parent.rightChild.Red)
                                {
                                    ColorFlip(node);
                                }
                            }
                        }
                        else if (node.parent.leftChild != null && node == node.parent.leftChild)
                        {
                            if (node.parent.parent.leftChild != null && node.parent == node.parent.parent.leftChild)
                            {
                                if (node.parent.parent.rightChild == null || node.parent.parent.rightChild.Black)
                                {
                                    RightRotation(node.parent.parent);
                                }
                                else if (node.parent.parent.rightChild.Red)
                                {
                                    ColorFlip(node);
                                }
                            }
                            else if (node.parent.parent.rightChild != null && node.parent == node.parent.parent.rightChild)
                            {
                                if (node.parent.parent.leftChild == null || node.parent.parent.leftChild.Black)
                                {
                                    RightLeftRotation(node.parent.parent);
                                }
                                else if (node.parent.parent.leftChild.Red)
                                {
                                    ColorFlip(node);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ColorFlip(RedBlackNode node)
        {
            node.parent.parent.SetColor("Red");
            if (node.parent.parent.leftChild != null)
                node.parent.parent.leftChild.SetColor("Black");
            if (node.parent.parent.rightChild != null)
                node.parent.parent.rightChild.SetColor("Black");
        }

        private void LeftRightRotation(RedBlackNode node)
        {
            RedBlackNode newParent = node.leftChild.rightChild; // new parent = grandparent's left child's right child
            newParent.leftChild = node.leftChild; // new parent's left child = grandparent's left child
            newParent.leftChild.parent = newParent; // new parent's left child's parent = new parent
            newParent.parent = node; // new parent's parent = grandparent
            node.leftChild = newParent; // grandparent's left child = parent
            newParent.leftChild.rightChild = null;
            newParent.leftChild.SetColor("red");
            RightRotation(node);
        }

        private void RightLeftRotation(RedBlackNode node)
        {
            RedBlackNode newParent = node.rightChild.leftChild; // problem child will become new parent
            newParent.rightChild = node.rightChild; // new parent's right child = grandparent's right child
            newParent.rightChild.parent = newParent; // nea pearent's right child's parent = new parent
            newParent.parent = node; // new parent's parent = grandparent
            node.rightChild = newParent; // grandparent's right child = new parent
            newParent.rightChild.leftChild = null;
            newParent.rightChild.SetColor("red");
            LeftRotation(node);
        }

        private void LeftRotation(RedBlackNode node)
        {
            RedBlackNode newParent = node.rightChild; // new parent = grandparent's right child
            newParent.rightChild.parent = newParent; // problem childs parent = new parent
            newParent.parent = node.parent; // new parent's parent = grandparent's parent
            newParent.leftChild = node; // new parent's left child = grandparent
            newParent.leftChild.parent = newParent;
            newParent.leftChild.rightChild = null;
            if (newParent.parent != null)
            {
                if (newParent.parent.key < newParent.key)
                {
                    newParent.parent.rightChild = newParent;
                }
                else if (newParent.parent.key > newParent.key)
                {
                    newParent.parent.leftChild = newParent;
                }
            }
            else if (newParent.parent == null)
            {
                newParent.parent = null;
                root = newParent;
                
            }

            newParent.SetColor("black");
        }

        private void RightRotation(RedBlackNode node)
        {
            RedBlackNode newParent = node.leftChild; // new parent = grandparent's left child
            newParent.leftChild.parent = newParent; // problem child's parent = new parent
            newParent.parent = node.parent; // new parents parent = grandparent's parent
            newParent.rightChild = node; //  new parent's left child = grandparent
            newParent.rightChild.parent = newParent;
            newParent.rightChild.leftChild = null;
            if (newParent.parent != null)
            {
                if (newParent.parent.key < newParent.key)
                {
                    newParent.parent.rightChild = newParent;
                }
                else if (newParent.parent.key > newParent.key)
                {
                    newParent.parent.leftChild = newParent;
                }
            }
            else if (newParent.parent == null)
            {
                newParent.parent = null;
                root = newParent;

            }

            newParent.SetColor("Black");
            node.SetColor("Red");
        }

        public void Search(int input)
        {
            int foundMin = 0;
            int foundMax = 0;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            foundMin = FindMin(input);
            foundMax = FindMax(input);

            stopwatch.Stop();

            if (foundMin == -1)
                Console.WriteLine("Invalid input!");
            else
            {
                Console.WriteLine("The minimum value child node of your search is: " + foundMin.ToString());
                Console.WriteLine("The maximum value child node of your search is: " + foundMax.ToString());
            }

            Console.WriteLine("Task runtime: " + stopwatch.Elapsed.ToString());
        }
    }
}