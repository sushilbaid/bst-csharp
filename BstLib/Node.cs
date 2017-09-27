namespace BstLib
{
    public class Node
    {
        public Node()
        {

        }

        public Node(int value)
        {
            this.Value = value;
        }

        public Node(int value, Node left, Node right)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        public Node Left
        {
            get;set;
        }

        public Node Right
        {
            get;set;
        }

        public int Value
        {
            get; set;
        }
    }
}
