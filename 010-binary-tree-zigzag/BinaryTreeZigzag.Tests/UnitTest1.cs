using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNamespace;

namespace BinaryTreeZigzag.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        var tree = new TreeNode
        {
            Value = 3,
            Left = new TreeNode
            {
                Value = 9
            },
            Right = new TreeNode
            {
                Value = 20,
                Left = new TreeNode
                {
                    Value = 15
                },
                Right = new TreeNode
                {
                    Value = 7
                }
            }
        };
        
        // Act
        var result = Program.ParseZigZag(tree);
        
        // Assert
        var expected = new List<List<int>>
        {
            new(){ 3 },
            new(){ 20, 9 },
            new(){ 15, 7 }
        };

        for (int i = 0; i < expected.Count; i++)
        {
            result[i].Should().BeEquivalentTo(expected[i]).And.ContainInOrder(expected[i]);
        }
    }
    
    [TestMethod]
    public void TestMethod2()
    {
        // Arrange
        var tree = new TreeNode
        {
            Value = 1
        };

        // Act
        var result = Program.ParseZigZag(tree);

        // Assert
        var expected = new List<List<int>>
        {
            new(){ 1 }
        };
        
        result.Should().BeEquivalentTo(expected);
    }
    
    [TestMethod]
    public void TestMethod3()
    {
        // Arrange
        var tree = new TreeNode();

        // Act
        var result = Program.ParseZigZag(tree);

        // Assert
        var expected = new List<List<int>>();
        result.Should().BeEquivalentTo(expected);
    }
    
    [TestMethod]
    public void TestMethod4()
    {
        // Arrange
        var tree = new TreeNode
        {
            Value = 1, Left = new TreeNode {Value = 2}
        };

        // Act
        var result = Program.ParseZigZag(tree);

        // Assert
        var expected = new List<List<int>>
        {
            new() { 1 },
            new() { 2 }
        };
        
        for (int i = 0; i < expected.Count; i++)
        {
            result[i].Should().BeEquivalentTo(expected[i]).And.ContainInOrder(expected[i]);
        }
    }
    
    [TestMethod]
    public void TestMethod5()
    {
        // Arrange
        var tree = new TreeNode
        {
            Value = 1,
            Left = new TreeNode
            {
                Value = 2,
                Left = new TreeNode
                {
                    Value = 4
                }
            },
            Right = new TreeNode
            {
                Value = 3,
                Right = new TreeNode
                {
                    Value = 5
                }
            }
        };

        // Act
        var result = Program.ParseZigZag(tree);

        // Assert
        var expected = new List<List<int>>
        {
            new() { 1 },
            new() { 3,2 },
            new() { 4,5 }
        };
        
        for (int i = 0; i < expected.Count; i++)
        {
            result[i].Should().BeEquivalentTo(expected[i]).And.ContainInOrder(expected[i]);
        }
    }
    
    [TestMethod]
    public void TestMethod6()
    {
        // Arrange
        // Act
        var result = Program.ParseZigZag(null);

        // Assert
        var expected = new List<List<int>>();

        result.Should().BeEquivalentTo(expected);
    }
}