using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentCheck.Models
{
    public class AssignmentsResults
    {
        public string UserName { get; set; }
        public List<AssignmentResult> Results {get; set;}
    }
}