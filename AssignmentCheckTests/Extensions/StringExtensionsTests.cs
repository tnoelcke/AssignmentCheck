using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssignmentCheck.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentCheck.Extensions.Tests
{
    [TestClass()]
    public class StringExtensionsTests
    {
        [TestMethod()]
        public void RemoveDomainFromIdentityTest()
        {
            string target = "ONID\\username";
            string expected = "username";
            Assert.AreEqual(expected, target.RemoveDomainFromIdentity());
            target = " ";
            expected = target;
            Assert.AreEqual(expected, target.RemoveDomainFromIdentity());
            target = " something ";
            expected = target;
            Assert.AreEqual(expected, target.RemoveDomainFromIdentity());
            target = null;
            expected = target;
            Assert.AreEqual(expected, target.RemoveDomainFromIdentity());
            target = @"onid\username\something";
            expected = @"username\something";
            Assert.AreEqual(expected, target.RemoveDomainFromIdentity());
            target = @"invalid\";
            expected = "";
            Assert.AreEqual(expected, target.RemoveDomainFromIdentity());
        }
    }
}