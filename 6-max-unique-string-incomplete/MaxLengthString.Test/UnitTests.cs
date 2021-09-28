using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxLengthString.Test
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ExpectLength4()
        {
            var arr = new [] {"un", "iq", "ue"};

            var result = StringOperations.GetMaxLengthUniqueString(arr);
            
            Assert.AreEqual(4, result);
        }
        
        [TestMethod]
        public void ExpectLength6()
        {
            var arr = new[] {"cha","r","act","ers"};
            
            var result = StringOperations.GetMaxLengthUniqueString(arr);
            
            Assert.AreEqual(6, result);
        }
        
        [TestMethod]
        public void ExpectLength26()
        {
            var arr = new [] {"abcdefghijklmnopqrstuvwxyz"};
            
            var result = StringOperations.GetMaxLengthUniqueString(arr);
            
            Assert.AreEqual(26, result);
        }
        
        [TestMethod]
        public void ExpectLength16()
        {
            var arr = new[] {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p"};
            
            var result = StringOperations.GetMaxLengthUniqueString(arr);
            
            Assert.AreEqual(16, result);
        }
        
        [TestMethod]
        public void ExpectLength0()
        {
            var arr = new[] {"yy","bkhwmpbiisbldzknpm"};
            
            var result = StringOperations.GetMaxLengthUniqueString(arr);
            
            Assert.AreEqual(0, result);
        }
        
        [TestMethod]
        public void ExpectLength6Again()
        {
            var arr = new[] {"a", "abc", "d", "de", "def"};
            
            var result = StringOperations.GetMaxLengthUniqueString(arr);
            
            Assert.AreEqual(6, result);
        }
    }
}