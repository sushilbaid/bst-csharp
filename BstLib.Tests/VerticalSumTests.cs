using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstLib.Tests
{
    [TestClass]
    public class VerticalSumTests
    {
        [TestMethod]
        public void VerticalSumOnlyRoot()
        {
            var result = Bst.VerticalSum(new Node(4));
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0], 4);
        }

        [TestMethod]
        public void VerticalSum7Nodes()
        {
            var tree = Bst.Create(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 4, 2, 1, 3, 6, 5, 7 });
            var expectedResult = new SortedList<int, int>()
            {
                { -2, 1 },
                { -1, 2 },
                { 0, 12 },
                { 1, 6 },
                { 2, 7 },
            };
            var result = Bst.VerticalSum(tree);
            AssertEquals(expectedResult, result);
        }

        private void AssertEquals(SortedList<int, int>expectedResult, SortedList<int, int> result)
        {
            Console.WriteLine("Expected: {0}, Actual: {1}", expectedResult.ToString2(), result.ToString2());
            Assert.AreEqual(expectedResult.Count, result.Count);
            foreach (var key in result.Keys)
            {
                Assert.AreEqual(expectedResult[key], result[key]);
            }
        }
    }

    public static class SortedListExtensions
    {
        public static string ToString2(this SortedList<int, int> sortedList)
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Count={0}", sortedList.Count);
            result.Append(", items=[");
            foreach (var item in sortedList)
                result.AppendFormat("{{{0}, {1}}}", item.Key, item.Value);
            result.Append("]");
            return result.ToString();
        }
    }
}
