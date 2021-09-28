using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailVerification.Tests
{
    [TestClass]
    public class UnitTests
    {
        private EmailVerificationService _sut;
        
        public UnitTests()
        {
            _sut = new EmailVerificationService();
        }
        
        [TestMethod]
        public void TestEmails1()
        {
            var emails = new []
            {
                "test.email+alex@leetcode.com",
                "test.e.mail+bob.cathy@leetcode.com",
                "testemail+david@lee.tcode.com"
            };

            var distinctEmails = _sut.NumberOfUniqueEmails(emails);
            
            Assert.AreEqual(2, distinctEmails);
        }
        
        [TestMethod]
        public void TestEmails2()
        {
            var emails = new []
            {
                "a@leetcode.com",
                "b@leetcode.com",
                "c@leetcode.com"
            };

            var distinctEmails = _sut.NumberOfUniqueEmails(emails);
            
            Assert.AreEqual(3, distinctEmails);
        }
    }
}