using FluentAssertions;
using Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests;

[TestClass]
public class LRUCacheTests
{
    // These unit tests are strange but im just using the leetcode example as a guide
    // and I just want it to pass for their scenario

    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        LRUCache sut = new LRUCache(2);

        // Act
        sut.Put(1, 1);
        sut.Put(2, 2);

        var a = sut.Get(1);

        sut.Put(3, 3);

        var b = sut.Get(2);

        sut.Put(4, 4);

        var c = sut.Get(1);
        var d = sut.Get(3);
        var e = sut.Get(4);

        // Assert
        a.Should().Be(1);
        b.Should().Be(-1);
        c.Should().Be(-1);
        d.Should().Be(3);
        e.Should().Be(4);
    }

    [TestMethod]
    public void TestMethod2()
    {
        // Arrange
        LRUCache sut = new LRUCache(2);

        // Act
        sut.Put(2, 1);
        sut.Put(2, 2);

        var a = sut.Get(2);

        sut.Put(1, 1);
        sut.Put(4, 1);

        var xxx = sut.Get(2);

        // Assert
        a.Should().Be(2);
        xxx.Should().Be(-1);
    }

    [TestMethod]
    public void TestMethod3()
    {
        // Arrange
        LRUCache sut = new LRUCache(2);

        // Act
        sut.Put(2, 1);
        sut.Put(1, 1);
        sut.Put(2, 3);
        sut.Put(4, 1);

        var a = sut.Get(1);
        var b = sut.Get(2);

        // Assert
        a.Should().Be(-1);
        b.Should().Be(3);
    }
}