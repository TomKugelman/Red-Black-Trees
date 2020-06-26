using System;

namespace Red_Black_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            // Ask user for the size of the tree they would like to build
            Console.WriteLine("How many nodes would you like this tree to have?");
            int arraySize = Int32.Parse(Console.ReadLine());

            int[] randomArray = CreateRandomArray(arraySize);

            RedBlackTree Tree = new RedBlackTree();

            // Print the unique numbers before adding to the tree
            int typeWriterReturn = 10; // modify this variable if your console is hard to read
            int typeWriterCounter = 0;
            foreach (int index in randomArray)
                {
                    // Every nth line (where n = <typeWriterReturn>) return to beginning of line
                    if (typeWriterCounter == typeWriterReturn)
                    {
                        Console.WriteLine();
                        typeWriterCounter = 0;
                    }
                    Console.Write("| "+ index + " ");
                    typeWriterCounter++;
                }

            Console.WriteLine("\n");

            // Add each unique number to the tree
            for (int index = 0; index < randomArray.Length; index++)
            {
                Tree.InsertNode(randomArray[index]);
            }

            // Display each node as the tree is being traversed
            Tree.InOrder(Tree.root);

            // Display number of nodes in the tree
            // This just verifies the tree is of the correct size to the user
            int numberOfNodes = Tree.NumOfNodes();
            Console.WriteLine("\nNumber of nodes in the full tree: " + numberOfNodes.ToString());
            Console.WriteLine($"There are {Tree.numOfLeafs} leaf nodes (nodes with no children) in this tree");
            Console.WriteLine();

            // Prompt user for searchTarget
            // Print the min value for that subtree
            // Print the max value for that subtree
            // Time the search
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Type a number you'd like to find the minimum and maximum child nodes of.");
                int searchTarget = Int32.Parse(Console.ReadLine());

                try 
                {
                    Array.BinarySearch(randomArray, searchTarget);
                    Tree.Search(searchTarget);
                    validInput = true;
                }
                catch 
                {
                    Console.WriteLine("Oops! Looks like that number isn't in our tree.");
                }
            }

            Console.ReadLine();
        }

        private static int[] CreateRandomArray(int maxSize)
        {
            var random = new Random();
            bool badKey;
            int randomKey = 0;
            int[] randomArray = new int[maxSize];

            for (int i = 0; i < randomArray.Length; i++)
            {
                badKey = true;
                while (badKey)
                {
                    badKey = false;
                    // Make sure the pool of unique numbers is HIGHER than the max size of the array
                    randomKey = random.Next(0, maxSize + 1);

                    for (int j = 0; j < randomArray.Length; j++)
                    {
                        if (randomKey == randomArray[j])
                        {
                            badKey = true;
                        }
                    }
                }
                randomArray[i] = randomKey;
            }
            return randomArray;
        }
    }
}
