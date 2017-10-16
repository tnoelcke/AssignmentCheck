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
    public class CountDirectoryCriterionTests
    {
        [TestMethod()]
        public void ValidateTest()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            int expected = Directory.GetDirectories(basePath)?.Length ?? 0;
            //start with a matching number.
            CountDirectoryCriterion target = new CountDirectoryCriterion()
            {
                SubPath = "\\",
                Count = expected
            };
            var result = target.Validate(basePath);
            Assert.IsTrue(result.IsValid);

            target.Count = expected + 1;
            result = target.Validate(basePath);
            Assert.IsFalse(result.IsValid);

            target.SubPath = "SomePath\\Dne";
            result = target.Validate(basePath);
            Assert.IsFalse(result.IsValid);
        }
    }
}