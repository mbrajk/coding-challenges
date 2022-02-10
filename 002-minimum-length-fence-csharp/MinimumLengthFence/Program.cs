// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;

int[][] trees1 = { 
    new[] {3, 0},
    new[] {4, 0},
    new[] {5, 0},
    new[] {6, 1},
    new[] {7, 2},
    new[] {7, 3},
    new[] {7, 4},
    new[] {6, 5},
    new[] {5, 5},
    new[] {4, 5},
    new[] {3, 5},
    new[] {2, 5},
    new[] {1, 4},
    new[] {1, 3},
    new[] {1, 2},
    new[] {2, 1},
    new[] {4, 2},
    new[] {0, 3}
};

int[][] trees2 =
{
    new[] {1, 1},
    new[] {2, 2},
    new[] {2, 0},
    new[] {2, 4},
    new[] {3, 3},
    new[] {4, 2}
};
foreach (var treeSet in new List<int[][]> {trees1, trees2})
{
    var fencePosts = FencePerimiter(treeSet);
    foreach (var fencePost in fencePosts)
    {
        Console.WriteLine(fencePost);
    }
    
    Console.WriteLine($"Total posts: {fencePosts.Count}");
}

List<Tree> FencePerimiter(int[][] trees)
{
    var fencePoints = new Stack<Tree>();

    var sortedTrees = trees
        .Select(tree => new Tree(tree[0], tree[1]))
        .OrderBy(tree => tree.X)
        .ThenBy(tree => tree.Y);

    foreach (var tree in sortedTrees.Concat(sortedTrees.Reverse()))
    {
        while (fencePoints.Count() > 1 &&
               isClockwise(fencePoints.ElementAt(1), fencePoints.ElementAt(0), tree))
        {
            fencePoints.Pop();
        }

        fencePoints.Push(tree);
    }
    
    return fencePoints.Distinct().ToList();
}

bool isClockwise(Tree point1, Tree point2, Tree point3)
{
    //precision shouldn't matter here as we are never dividing
    //(x2-x1)*(y3-y1)-(y2-y1)*(x3-x1)

    //determining left turn, right turn or co-linear:
    // 
    // + = left turn
    // 0 = co-linear
    // - = right turn
    var result = (point2.X - point1.X) * (point3.Y - point1.Y) - (point2.Y - point1.Y) * (point3.X - point1.X);
    return result switch
    {
        < 0 => true,
        _ => false
    };
}

public record Tree
{
    public readonly int X;
    public readonly int Y;

    public Tree(int x, int y)
    {
        X = x;
        Y = y;
    }
}