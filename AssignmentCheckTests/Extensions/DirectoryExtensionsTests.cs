using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssignmentCheck.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AssignmentCheck.Extensions.Tests
{
    [TestClass()]
    public class DirectoryExtensionsTests
    {
        [TestMethod()]
        public void GetDirectoriesAtDepthTest()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            //navigate up 2 folders
            DirectoryInfo dir = new DirectoryInfo(basePath);
            basePath = dir.Parent.Parent.FullName;
            var actual = basePath.GetDirectoriesAtDepth(2);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() > 0);
            Assert.IsTrue(actual.Contains(dir.FullName));
            Assert.IsFalse(actual.Contains(dir.Parent.FullName));
            Assert.IsFalse(actual.Contains(dir.Parent.Parent.FullName));

            basePath = dir.FullName;
            actual = basePath.GetDirectoriesAtDepth(100);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 0);
        }
    }
}