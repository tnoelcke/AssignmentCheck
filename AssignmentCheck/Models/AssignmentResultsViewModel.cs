using AssignmentCheck.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentCheck.Models
{
    public class AssignmentResultsViewModel
    {
        public string UserName { get; set; }
        public IEnumerable<AssignmentResult> Results { get; set; }
    }
}