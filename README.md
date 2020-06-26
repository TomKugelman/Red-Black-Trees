# Red-Black-Trees
> Author: Thomas Kugelman

> Date Created: February, 2020

> Date Revised: June, 2020

> Language: C# .NET Core (Console Application)

## Description
This program allows the user to create a Red-Black binary search tree of any size. It also allows the user to search any node in the tree and in return get its smallest and largest child node (following both its subtrees). 

## Classes
- RedBlackNode -- A custom NODE class with several class properties such as: leftChild, rightChild, name, color, and two booleans to make soem processes easier to type and have less programmer errors.
- RedBlackTree -- A custom class that acts as a Red-Black tree with functions to manipulate the tree as well as traverse and return data.

### Class Functions
#### RedBlackNode
- Constructor -- Sets the name of the node // only useful for debugging
- SetColor -- Sets the color of the node

#### RedBlackTree
- InsertNode -- Takes 1 integer as an argument and creates a new instance of the RedBlackNode class using that integer, then adds it to the tree and calls <Rebalance()>.
- InOrder -- Takes 1 RedBlackNode as an argument and traverses the tree in order, printing each node as it goes. This function will also mark the ROOT node.
- FindMin -- Takes 1 integer as an argument and searches the tree for a node with that value, then traverses down its left subtree until it finds a <leftChild> leaf.
- FindMax -- Takes 1 integer as an argument and searches the tree for a node with that value, then traverses down its right subtree until it finds a <rightChild> leaf.
- NumOfNodes -- Takes no arguments and only calls <CountNodes()>.
- CountNodes -- Takes 1 RedBlackNode as an argument (which should always be the ROOT) and recursively traverses the tree counting each node and <strong>returns</strong> an integer
- Rebalance -- Takes 1 RedBlackNode as an argument and checks whether a rule for Red-Black trees has been broken, then calls the function that fixes the tree.
- ColorFlip -- Takes 1 RedBlackNode as an argument. Flips the grandparents color to RED and sets both of the grandparents children to BLACK.
- LeftRightRotation -- Takes 1 RedBlackNode as an argument. Performs a left rotation then a right rotation. Further details within <Tree.cs>.
- RightLeftRotation -- Takes 1 RedBlackNode as an argument. Performs a right rotation then a left rotation. Furhter Details within <Tree.cs>.
- LeftRotation -- Takes 1 RedBlackNode as an argument. Performs a left rotation. Furhter Details within <Tree.cs>.
- RightRotation -- Takes 1 RedBlackNode as an argument. Performs a right rotation. Furhter Details within <Tree.cs>.
- Search -- Takes 1 integer as an argument. Calls <FindMin()> and <FindMax()> with the given value, times the search process and outputs the result, including the time to the console.
 
 
