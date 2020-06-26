using System;

namespace Red_Black_Trees
{
    class RedBlackNode
    {
        public bool Red;
        public bool Black;
        public int key;
        public RedBlackNode parent;
        public RedBlackNode leftChild;
        public RedBlackNode rightChild;
        public string name;
        public string color;

        public RedBlackNode(string Name = "Child")
        {
            name = Name;
        }

        public void SetColor(string colorTemp)
        {
            colorTemp = colorTemp.ToUpper();
            if (colorTemp == "BLACK")
            {
                Red = false;
                Black = true;
                color = colorTemp;
            }
            else if (colorTemp == "RED")
            {
                Red = true;
                Black = false;
                color = colorTemp;
            }
        }
    }
}