using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minimum.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var arrays = new List<int[]>();

        arrays.Add(new[] { 5, 6, 2, 3, 4 }); //2
            
        arrays.Add(new[] { 1 }); //1
        arrays.Add(new[] { 4, 5, 1, 2, 3 }); //1
            
        arrays.Add(new[] { 3, 4, 5, 1, 2 }); //1
        arrays.Add(new[] { 4, 5, 6, 7, 8, 0, 2 }); //0
        arrays.Add(new[] { 4, 5, 6, 7, 8, 1, 2 }); //1
        arrays.Add(new[] { 4, 5, 6, 7, 0, 1, 2 }); //0
        arrays.Add(new[] { 11, 13, 15, 17 }); //11

        var answers = new[] { 2, 1, 1, 1, 0, 1, 0, 11 };
        for (int i = 0; i <  answers.Length; i++)
        {
            var result = RotatedSortedArray2.FindMinimumValue(arrays[i]);
            result.Should().Be(answers[i]);
        }
    }
    
    [TestMethod]
    public void TestMethod2()
    {
        var arrays = new List<int[]>();

        arrays.Add(new[] { 5, 6, 2, 3, 4 }); //2
            
        arrays.Add(new[] { 1 }); //1
        arrays.Add(new[] { 4, 5, 1, 2, 3 }); //1
            
        arrays.Add(new[] { 3, 4, 5, 1, 2 }); //1
        arrays.Add(new[] { 4, 5, 6, 7, 8, 0, 2 }); //0
        arrays.Add(new[] { 4, 5, 6, 7, 8, 1, 2 }); //1
        arrays.Add(new[] { 4, 5, 6, 7, 0, 1, 2 }); //0
        arrays.Add(new[] { 11, 13, 15, 17 }); //11

        var answers = new[] { 2, 1, 1, 1, 0, 1, 0, 11 };
        for (int i = 0; i <  answers.Length; i++)
        {
            var result = RotatedSortedArray.FindMinimumValue(arrays[i]);
            result.Should().Be(answers[i]);
        }
    }
}