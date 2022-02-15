namespace RightPointingTree;

public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node()
    {
    }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}

public static class Solution
{
    public static Node Connect(Node root)
    {
        var queue = new Queue<List<Node>>();
        queue.Enqueue(new List<Node> {root});

        while (queue.Any())
        {
            var newList = new List<Node>();
            var currentNodes = queue.Dequeue();

            Node lastNode = null;
            for (int i = 0; i < currentNodes.Count; i++)
            {
                var currentNode = currentNodes[i];
                if (lastNode != null)
                {
                    lastNode.next = currentNode;
                }

                lastNode = currentNode;

                // perfect tree so we dont need to check both for null
                if (currentNode.left != null)
                {
                    newList.Add(currentNode.left);
                    newList.Add(currentNode.right);
                }
            }

            if (newList.Any())
            {
                queue.Enqueue(newList);
            }
        }

        return root;
    }
}