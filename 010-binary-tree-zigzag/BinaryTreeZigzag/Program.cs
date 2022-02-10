using System.Collections;

namespace MyNamespace;

public class Program
{
    public static IList<IList<int>> ParseZigZag(TreeNode root)
    {
        IList<IList<int>> result = new List<IList<int>>();

        if (root == null)
        {
            return result;
        }

        var queue = new Queue<List<TreeNode>>();
        // we would need this hashset for a cyclic graph, dont need it for a binary tree
        //var visited = new HashSet<TreeNode>(); 
        queue.Enqueue(new List<TreeNode> {root});

        var n = 1;
        while (queue.Any())
        {
            var nodesToVisit = queue.Dequeue();
            var nextList = new List<TreeNode>();
            var levelList = new List<int>();
            
            foreach (var node in nodesToVisit)
            {
                if (node != null)
                {
                    levelList.Add(node.Value);

                    if (node.Left != null)
                    {
                        nextList.Add(node.Left);
                    }

                    if (node.Right != null)
                    {
                        nextList.Add(node.Right);
                    }
                }
            }

            if (nextList.Any())
            {
                queue.Enqueue(nextList);
            }

            if (n % 2 == 0)
            {
                levelList.Reverse();
            }
            result.Add(levelList);
            n++;
        }

        return result;
        
        //this is a simple one level at a time traversal that i was testing. returns all items in one list
        // var n = 0;
        // var currentList = new List<int>();
        // while (queue.Any())
        // {
        //     var currentNode = queue.Dequeue();
        //     currentList.Add(currentNode.Value);    
        //     if (currentNode.Left != null)
        //     {
        //         queue.Enqueue(currentNode.Left);
        //     }
        //
        //     if (currentNode.Right != null)
        //     {
        //         queue.Enqueue(currentNode.Right);
        //     }
        //}
    }
}

public class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(
        int value = 0,
        TreeNode left = null,
        TreeNode right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}