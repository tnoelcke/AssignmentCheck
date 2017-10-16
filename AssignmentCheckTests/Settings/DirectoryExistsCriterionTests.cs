using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssignmentCheck.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AssignmentCheck.Settings.Tests
{
    [TestClass()]
    public class DirectoryExistsCriterionTests
    {
        [TestMethod()]
        public void ValidateTest()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            //start with a matching number.
            DirectoryExistsCriterion target = new DirectoryExistsCriterion()
            {
                SubPath = "\\",
            };
            var result = target.Validate(basePath);
            Assert.IsTrue(result.IsValid);

            target.SubPath = "SomePath\\Dne";
            result = target.Validate(basePath);
            Assert.IsFalse(result.IsValid);
        }
    }
}