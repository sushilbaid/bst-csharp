using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstLib
{
    class BstVerticalSum
    {
        public BstVerticalSum(Node root)
        {
            this.Root = root;
            this.distanceNodeMap = new SortedList<int, List<int>>();
        }

        public Node Root
        {
            get;set;
        }

        public SortedList<int, int> Compute()
        {
            this.ComputeHorizantalDistance(this.Root, 0);
            var result = new SortedList<int, int>();
            foreach (var key in this.distanceNodeMap.Keys)
            {
                var sum = 0;
                foreach (var value in this.distanceNodeMap[key])
                    sum += value;
                result.Add(key, sum);
            }
            return result;
        }

        private void ComputeHorizantalDistance(Node node, int distance)
        {
            if (node == null)
                return;
            if (!this.distanceNodeMap.ContainsKey(distance))
                this.distanceNodeMap[distance] = new List<int>();
            this.distanceNodeMap[distance].Add(node.Value);
            this.ComputeHorizantalDistance(node.Left, distance - 1);
            this.ComputeHorizantalDistance(node.Right, distance + 1);
        }

        private SortedList<int, List<int>> distanceNodeMap;
    }
}
