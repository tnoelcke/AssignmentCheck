using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentCheck.Models
{
    public class AssignmentResult
    {
        public string Title { get; set; }

        public List<CriterionResult> Results { get; set; }

    }
}