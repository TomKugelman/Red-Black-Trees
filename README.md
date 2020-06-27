# Red-Black-Trees
> Author: Thomas Kugelman

> Date Created: February, 2020

> Date Revised: June, 2020

> Language: C# .NET Core (Console Application)

## Description
This program allows the user to create a Red-Black binary search tree of any size. It also allows the user to search any node in the tree and in return get its smallest and largest child node (following both its subtrees). The total number of nodes in the tree as well as the total number of leaf nodes in the tree are also displayed. 

## Classes
- RedBlackNode -- A custom NODE class with several class properties such as: leftChild, rightChild, name, color, and two booleans to make some IF-ELSE statements easier to write.
- RedBlackTree -- A custom class that acts as a Red-Black tree with functions to manipulate the tree as well as traverse and return data.
- Program -- Handles the main user interactions and serves as a hub for the application.

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
- CountNodes -- Takes 1 RedBlackNode as an argument (which should always be the ROOT) and recursively traverses the tree counting each node and returns an integer
- Rebalance -- Takes 1 RedBlackNode as an argument and checks whether a rule for Red-Black trees has been broken, then calls the function that fixes the tree.
- ColorFlip -- Takes 1 RedBlackNode as an argument. Flips the grandparent's color to RED and sets both of the grandparents children to BLACK.
- LeftRightRotation -- Takes 1 RedBlackNode as an argument. Performs a left rotation then a right rotation. Further details within <Tree.cs>.
- RightLeftRotation -- Takes 1 RedBlackNode as an argument. Performs a right rotation then a left rotation. Further Details within <Tree.cs>.
- LeftRotation -- Takes 1 RedBlackNode as an argument. Performs a left rotation. Further Details within <Tree.cs>.
- RightRotation -- Takes 1 RedBlackNode as an argument. Performs a right rotation. Further Details within <Tree.cs>.
- Search -- Takes 1 integer as an argument. Calls <FindMin()> and <FindMax()> with the given value, times the search process and outputs the result, including the time to the console.
 
#### Program
- CreateRandomArray -- Takes 1 integer as an argument and returns an array filled with unique numbers the size of the argument given.

## Notes
If you wish to actually run this program, please be aware that in "Program.cs" under the "main" function there is a FOREACH loops that prints the "randomUniqueArray" to the console. If my formatting is hard to read, try changing <typeWriterReturn> to a different value. I found this small edition helped me quickly skim over the output when comparing it to the "InOrder" output below it.

### Potential Improvements
When I was initially writing this application and learning about Red-Black binary trees I found it very difficult to keep track of what exactly each rotation does step-by-step. While doing some research I saw a very nice visualization tool using WinForms that made it much easier to udnerstand. If I was going to take this project further I would create some sort of animation within WinForms that allows the user to do one of two things, watch the tree being made step-by-step node-by-node, or let them skip the whole process and see a fully realized tree. While I am experiences with WinForms to some extent, doing soemthing similiar with Python and a data visualizer seems more efficient. However, after gaining some more experience I may come back to this project and see if I can make it even better!
