using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistinctSubsequences.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestRabbit()
        {
            // Arrange
            var string1 = "rabbbit";
            var string2 = "rabbit";
            
            // Act            
            var result = Solution.NumDistinct(string1, string2);

            Assert.AreEqual(3, result);
        }
       
        [TestMethod]
        public void TestBag()
        {
            // Arrange
            var string1 = "babgbag";
            var string2 = "bag";
            
            // Act            
            var result = Solution.NumDistinct(string1, string2);

            Assert.AreEqual(5, result);
        }
        
        [TestMethod]
        public void TestEmptyString()
        {
            // Arrange
            var string1 = "abc";
            var string2 = "";
            
            // Act            
            var result = Solution.NumDistinct(string1, string2);

            Assert.AreEqual(result, 0);
        }
        
        [TestMethod]
        public void TestZero()
        {
            // Arrange
            var string1 = "abc";
            var string2 = "d";
            
            // Act            
            var result = Solution.NumDistinct(string1, string2);

            Assert.AreEqual(result, 0);
        }
        
        [TestMethod]
        public void TestSlow()
        {
            // Arrange
            var string1 = "bccbcdcabadabddbccaddcbabbaaacdba";
            var string2 = "bccbbdc";
            
            // Act            
            var result = Solution.NumDistinct(string1, string2);

            Assert.AreEqual(result, 172);
        }
    }
}