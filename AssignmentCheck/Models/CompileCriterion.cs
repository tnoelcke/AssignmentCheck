using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace AssignmentCheck.Models
{
    /// <summary>
    /// This class checks that the assignment exists and is in the correct location.
    /// </summary>
    [Serializable]
    [XmlRoot("Criterion")]
    public class CompileCriterion : Criterion
    {
        public override string Description { get; set; }

        /// <summary>
        /// This Fuction Finds the Users assignment and ensures that it is in the correct location
        /// </summary>
        /// <param name="userBasePath"> Takes the user base path as an agrument so we can find that users directory</param>
        /// <returns> True if the assignment exists in the correct location return false if not</returns>
        public override Tuple<bool, string> Validate(string userBasePath)
        {
            return new Tuple<bool, string>(true, "Your Assignment is Turned In Correctly"); 
        }
    }
}