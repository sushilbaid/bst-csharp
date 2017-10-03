using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BstLib.Tests
{
    [TestClass]
    public class BstLibCreate
    {
        [TestMethod]
        public void CreateNullTree()
        {
            Assert.IsNull(Bst.Create(new int[] { }, new int[] { }));
        }

        [TestMethod]
        public void CreateRootNodeOnlyTree()
        {
            var root = Bst.Create(new int[] { 1 }, new int[] { 1 });
            Assert.IsNotNull(root);
            Assert.AreEqual(1, root.Value);
            Assert.IsNull(root.Left);
            Assert.IsNull(root.Right);
        }

        [TestMethod]
        public void Create3NodeTree()
        {
            var tree = Bst.Create(new int[] { 1, 2, 3 }, new int[] { 2, 1, 3 });
            Assert.AreEqual(2, tree.Value);
            Assert.AreEqual(1, tree.Left.Value);
            Assert.AreEqual(3, tree.Right.Value);
        }

        [TestMethod]
        public void Create5NodeTree()
        {
            var tree = Bst.Create(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 2, 1, 4, 5 });
            Assert.AreEqual(3, tree.Value);
            Assert.AreEqual(2, tree.Left.Value);
            Assert.AreEqual(1, tree.Left.Left.Value);
            Assert.AreEqual(4, tree.Right.Value);
            Assert.AreEqual(5, tree.Right.Right.Value);
        }

        [TestMethod]
        public void Create15NodeTree()
        {
            var tree = Bst.Create(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 
                new int[] { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 });
            Assert.AreEqual(8, tree.Value);
            Assert.AreEqual(4, tree.Left.Value);
            Assert.AreEqual(12, tree.Right.Value);

            Assert.AreEqual(2, tree.Left.Left.Value);
            Assert.AreEqual(1, tree.Left.Left.Left.Value);
            Assert.AreEqual(3, tree.Left.Left.Right.Value);

            Assert.AreEqual(6, tree.Left.Right.Value);
            Assert.AreEqual(5, tree.Left.Right.Left.Value);
            Assert.AreEqual(7, tree.Left.Right.Right.Value);

            Assert.AreEqual(10, tree.Right.Left.Value);
            Assert.AreEqual(9, tree.Right.Left.Left.Value);
            Assert.AreEqual(11, tree.Right.Left.Right.Value);

            Assert.AreEqual(14, tree.Right.Right.Value);
            Assert.AreEqual(13, tree.Right.Right.Left.Value);
            Assert.AreEqual(15, tree.Right.Right.Right.Value);
        }

        [TestMethod]
        public void CreateLeftSkewedTree()
        {
            var tree = Bst.Create(new int[] { 1, 2, 3, 4, 5 }, 
                new int[] { 5, 4, 3, 2, 1 });
            Assert.AreEqual(5, tree.Value);
            Assert.AreEqual(4, tree.Left.Value);
            Assert.AreEqual(3, tree.Left.Left.Value);
            Assert.AreEqual(2, tree.Left.Left.Left.Value);
            Assert.AreEqual(1, tree.Left.Left.Left.Left.Value);

            Assert.IsNull(tree.Right);
            Assert.IsNull(tree.Left.Right);
            Assert.IsNull(tree.Left.Left.Right);
            Assert.IsNull(tree.Left.Left.Left.Right);
            Assert.IsNull(tree.Left.Left.Left.Left.Right);
        }

        [TestMethod]
        public void CreateRightSkewedTree()
        {
            var tree = Bst.Create(new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(1, tree.Value);
            Assert.AreEqual(2, tree.Right.Value);
            Assert.AreEqual(3, tree.Right.Right.Value);
            Assert.AreEqual(4, tree.Right.Right.Right.Value);
            Assert.AreEqual(5, tree.Right.Right.Right.Right.Value);

            Assert.IsNull(tree.Left);
            Assert.IsNull(tree.Right.Left);
            Assert.IsNull(tree.Right.Right.Left);
            Assert.IsNull(tree.Right.Right.Right.Left);
            Assert.IsNull(tree.Right.Right.Right.Right.Right);
        }
    }
}
