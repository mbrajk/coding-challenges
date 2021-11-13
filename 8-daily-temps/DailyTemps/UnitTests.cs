using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DailyTemps.UnitTests;

[TestClass]
public class UnitTests
{
    private readonly IEnumerable<ISolution> _suts = new List<ISolution>
    {
        new Solution(),
        new StackSolution()
    };

    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        var array = new[] { 12, 11, 10, 9, 12 };
        var expectedResult = new[] { 0, 3, 2, 1, 0 };

        foreach(var sut in _suts)
        {
            // Act
            var result = sut.DailyTemperatures(array);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }

    [TestMethod]
    public void TestMethod2()
    {
        // Arrange
        var array = new[] { 10, 11, 10, 9, 12 };
        var expectedResult = new[] { 1, 3, 2, 1, 0 };

        foreach (var sut in _suts)
        {
            // Act
            var result = sut.DailyTemperatures(array);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }

    [TestMethod]
    public void TestMethod3()
    {
        // Arrange
        var array = new[] { 55, 38, 53, 81, 61, 93, 97, 32, 43, 78 };
        var expectedResult = new[] { 3, 1, 1, 2, 1, 1, 0, 1, 1, 0 };

        foreach (var sut in _suts)
        {
            // Act
            var result = sut.DailyTemperatures(array);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}