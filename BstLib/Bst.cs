namespace BstLib
{
    public class Bst
    {
        public static Node Create(int[] inorder, int [] preorder)
        {
            return new BstCreator().Create(inorder, preorder);
        }
    }
}
