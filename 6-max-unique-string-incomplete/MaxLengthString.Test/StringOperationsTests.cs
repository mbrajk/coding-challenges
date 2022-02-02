using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxLengthString.Test
{
    [TestClass]
    public class StringOperationsTests
    {
        private readonly List<IStringOperations> _stringOperationsImplementations = new();

        public StringOperationsTests()
        {
            _stringOperationsImplementations.Add(new RecursiveStringOperations());
        }

        [TestMethod]
        public void ExpectLength4()
        {
            var arr = new[] {"un", "iq", "ue"};

            foreach (var stringOperationsImplementation in _stringOperationsImplementations)
            {
                var result = stringOperationsImplementation.GetMaxLengthUniqueString(arr);
                Assert.AreEqual(4, result);
            }
        }

        [TestMethod]
        public void ExpectLength6()
        {
            var arr = new[] {"cha", "r", "act", "ers"};

            foreach (var stringOperationsImplementation in _stringOperationsImplementations)
            {
                var result = stringOperationsImplementation.GetMaxLengthUniqueString(arr);
                Assert.AreEqual(6, result);
            }
        }

        [TestMethod]
        public void ExpectLength26()
        {
            var arr = new[] {"abcdefghijklmnopqrstuvwxyz"};

            foreach (var stringOperationsImplementation in _stringOperationsImplementations)
            {
                var result = stringOperationsImplementation.GetMaxLengthUniqueString(arr);
                Assert.AreEqual(26, result);
            }
        }

        [TestMethod]
        public void ExpectLength16()
        {
            var arr = new[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p"};

            foreach (var stringOperationsImplementation in _stringOperationsImplementations)
            {
                var result = stringOperationsImplementation.GetMaxLengthUniqueString(arr);
                Assert.AreEqual(16, result);
            }
        }

        [TestMethod]
        public void ExpectLength0()
        {
            var arr = new[] {"yy", "bkhwmpbiisbldzknpm"};

            foreach (var stringOperationsImplementation in _stringOperationsImplementations)
            {
                var result = stringOperationsImplementation.GetMaxLengthUniqueString(arr);
                Assert.AreEqual(0, result);
            }
        }

        [TestMethod]
        public void ExpectLength6Again()
        {
            var arr = new[] {"a", "abc", "d", "de", "def"};

            foreach (var stringOperationsImplementation in _stringOperationsImplementations)
            {
                var result = stringOperationsImplementation.GetMaxLengthUniqueString(arr);
                Assert.AreEqual(6, result);
            }
        }
        
        [TestMethod]
        public void ExpectLength9()
        {
            var arr = new[] {"abc","def","bp","dq","eg","fh"};

            foreach (var stringOperationsImplementation in _stringOperationsImplementations)
            {
                var result = stringOperationsImplementation.GetMaxLengthUniqueString(arr);
                Assert.AreEqual(9, result);
            }
        }
    }
}