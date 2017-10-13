using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssignmentCheck.Models;
using System.Xml.Serialization;

namespace AssignmentCheck.Settings {   


        [Serializable]
        public class AssignmentSetting
        {
            public List<Assignment> Assignments { get; set; }   
        }
}
