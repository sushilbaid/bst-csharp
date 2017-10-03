using System.Collections.Generic;

namespace BstLib
{
    public class Bst
    {
        public static Node Create(int[] inorder, int [] preorder)
        {
            return new BstCreator().Create(inorder, preorder);
        }

        public static SortedList<int, int> VerticalSum(Node root)
        {
            return new BstVerticalSum(root).Compute();
        }
    }
}
