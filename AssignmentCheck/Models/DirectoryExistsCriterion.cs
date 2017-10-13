using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;

namespace AssignmentCheck.Models
{
    [Serializable]
    [XmlRoot("Criterion")]
    public class DirectoryExistsCriterion : Criterion
    {
        public string SubPath { get; set; }
        public override Tuple<bool, string> Validate(string path)
        {
            if (!Directory.Exists(path + SubPath))
            {
                return new Tuple<bool, string>(false, "Your Assignment is Not in the correct Location");
            }
            return new Tuple<bool, string>(true, "Your Assignemnt is Turned In Correctly");
        }
    }
}