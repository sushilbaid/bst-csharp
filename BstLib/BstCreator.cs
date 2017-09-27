using System;

namespace BstLib
{
    class BstCreator
    {
        /// <summary>
        /// Create Binary search tree given the inorder & preorder traversals.
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="preorder"></param>
        /// <returns></returns>
        public Node Create(int[] inorder, int[] preorder)
        {
            if (inorder.Length != preorder.Length)
                throw new ArgumentException(
                    string.Format("inorder & preorder list have different counts {0}, {1} respectively", 
                        inorder.Length, preorder.Length));
            this.inorder = inorder;
            this.preorder = preorder;
            return this.Create(0, 0, inorder.Length);
        }

        /// <summary>
        /// Create sub-tree with inorder & preorder traversals in range {startInorder, length} & {startPreorder, length} respectively.
        /// </summary>
        /// <param name="startInorder"></param>
        /// <param name="startPreorder"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        Node Create(int startInorder, int startPreorder, int length)
        {
            if (length == 0)
                return null;
            var value = this.preorder[startPreorder];
            var indexOfNodeInInorderList = FindNodeIndex(value, startInorder, length);
            if (indexOfNodeInInorderList == -1)
                throw new ArgumentException(
                    string.Format("invalid inorder traversal. missing node {0} that is available in preorder", value));
            var result = new Node(value);
            var nodesInLeft = indexOfNodeInInorderList - startInorder;
            var nodesInRight = length - nodesInLeft - 1;
            result.Left = this.Create(startInorder, startPreorder + 1, nodesInLeft);
            result.Right = this.Create(indexOfNodeInInorderList + 1, startPreorder + nodesInLeft + 1, nodesInRight);
            return result;
        }

        /// <summary>
        /// Find index of the node with value - in the inorder traversal in range {startInorder, Length}
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startInorder"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        int FindNodeIndex(int value, int startInorder, int length)
        {
            for (int index = startInorder; index < startInorder + length; index++)
                if (this.inorder[index] == value)
                    return index;
            return -1;
        }


        private int[] inorder;
        private int[] preorder;
    }
}
