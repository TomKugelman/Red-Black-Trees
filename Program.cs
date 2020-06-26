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
            foreach (int index in randomArray)
                Console.Write("| "+ index + " |");

            Console.WriteLine();

            // Add each unique number to the tree
            for (int index = 0; index < randomArray.Length; index++)
            {
                Tree.InsertNode(randomArray[index]);
            }

            Tree.InOrder(Tree.root);

            // Display number of nodes in the tree
            int numberOfNodes = Tree.NumOfNodes();
            Console.WriteLine("Number of nodes in the full tree " + numberOfNodes.ToString());
            Console.WriteLine();

            // Prompt user for searchTarget
            // Print the min value for that subtree
            // Print the max value for that subtree
            // Time the search
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Type a number you'd like to search for");
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
                //randomArray[i] = random.Next(0, 100);
                badKey = true;
                while (badKey)
                {
                    badKey = false;
                    randomKey = random.Next(0, 100);

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
