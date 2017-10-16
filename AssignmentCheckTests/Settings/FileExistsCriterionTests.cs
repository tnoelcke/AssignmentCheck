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
    public class FileExistsCriterionTests
    {
        [TestMethod()]
        public void ValidateTest()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            //get a file from the current app directory
            var file = Directory.GetFiles(basePath).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(file))
            {
                Assert.Inconclusive("Couldn't find a file at " + basePath);
            }
            FileInfo fileDetails = new FileInfo(file);
            string namePattern = "*." + fileDetails.Extension.Trim('.');
            string dirPath = fileDetails.Directory.Parent.Parent.Parent.FullName;
            string subPath = fileDetails.Directory.Parent.Parent.Name;
            FileExistsCriterion target = new FileExistsCriterion()
            {
                Depth = 2,
                SubPath = subPath,
                FileNamePattern = namePattern,
                Description = "test"
            };
            var actual = target.Validate(dirPath);
            Assert.IsTrue(actual.IsValid);
            target.FileNamePattern = "*.dne," + namePattern;
            actual = target.Validate(dirPath);
            Assert.IsTrue(actual.IsValid);

            target.FileNamePattern = "*.dne";
            actual = target.Validate(dirPath);
            Assert.IsFalse(actual.IsValid);
            target.FileNamePattern = namePattern;
            target.SubPath = "dne";
            Assert.IsFalse(actual.IsValid);
            target.SubPath = subPath;
            target.Depth = 3;
            Assert.IsFalse(actual.IsValid);
        }
    }
}