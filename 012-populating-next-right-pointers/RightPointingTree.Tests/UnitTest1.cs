using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RightPointingTree.Tests;

[TestClass]
public class UnitTest1
{
    // not a great test but i know this solution works
    [TestMethod]
    public void TestMethod1()
    {
        var sut = new Node();
        sut.val = 1;
        sut.left = new Node
        {
            val = 2,
            left = new Node
            {
                val = 4
            },
            right = new Node
            {
                val = 5
            }
        };
        sut.right = new Node
        {
            val = 3,
            left = new Node
            {
                val = 6
            },
            right = new Node
            {
                val = 7
            },
        };

        var a = Solution.Connect(sut);

        a.left.next.val.Should().Be(3);
    }
}