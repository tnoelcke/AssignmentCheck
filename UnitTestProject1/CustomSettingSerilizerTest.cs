using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using AssignmentCheck.Models;
using AssignmentCheck.Settings;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AssignmentCheck;


namespace UnitTestProject1
{
    [TestClass]
    public class CustomSettingSerilizerTest
    {
        [TestMethod]
        public void SerilizeTest()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Assignment>));
            //builds the object we want to see so we can write it as XML


            List<Assignment> Assignments = new List<Assignment>()
                {
                    new Assignment()
                    {
                         Title = "Test1",
                         Criteria = new List<Criterion>()
                         {
                             new CompileCriterion()
                             {
                                 Description = "This Does a thing"
                             },
                             new DirectoryExistsCriterion()
                             {
                                 Description = "This does a different thing",
                                 SubPath = "TEst"
                             }
                         }
                    }
                };

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            xs.Serialize(sw, Assignments);
            Console.WriteLine(sb.ToString());
        }
    }
}
