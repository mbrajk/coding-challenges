using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntervalListIntersections.Tests;

[TestClass]
public class UnitTest1
{
    private readonly Solution _sut;

    public UnitTest1()
    {
        _sut = new Solution();   
    }
    
    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        var firstList = new []
        {
            new [] {0, 2},
            new [] {5, 10},
            new [] {13, 23},
            new [] {24, 25}
        };

        var secondList = new []
        {
            new [] {1, 5},
            new [] {8, 12},
            new [] {15, 24},
            new [] {25, 26},
        };

        var expectedResult = new []
        {
            new [] {1, 2},
            new [] {5, 5},
            new [] {8, 10},
            new [] {15, 23},
            new [] {24, 24},
            new [] {25, 25},
        };
        
        // Act
        var result = _sut.IntervalIntersection(firstList, secondList);
        
        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [TestMethod]
    public void TestMethod2()
    {
        // Arrange
        var firstList = new []
        {
            new [] { 1, 3 },
            new [] { 5, 9 },
        };

        var secondList = new int[][] { };

        var expectedResult = new int[][] { };
        
        // Act
        var result = _sut.IntervalIntersection(firstList, secondList);
        
        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [TestMethod]
    public void TestMethod3()
    {
        // Arrange
        var firstList = new int[][] { };

        var secondList = new []
        {
            new [] { 4, 8 },
            new [] { 10, 12 },
        };

        var expectedResult = new int[][] { };
        
        // Act
        var result = _sut.IntervalIntersection(firstList, secondList);
        
        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [TestMethod]
    public void TestMethod4()
    {
        // Arrange
        var firstList = new []
        {
            new [] { 1, 7 },
        };

        var secondList = new []
        {
            new [] { 3, 10 },
        };

        var expectedResult =  new []
        {
            new [] { 3, 7 },
        };
        
        // Act
        var result = _sut.IntervalIntersection(firstList, secondList);
        
        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
}