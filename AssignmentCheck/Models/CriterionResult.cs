using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentCheck.Models
{
    public class CriterionResult
    {
        public string Description { get; set; }
        public string Message { get; set; }
        public bool Result { get; set; }

        public CriterionResult(Tuple<bool, string> testResult, string description)
        {
            this.Description = description;
            Result = testResult.Item1;
            Message = testResult.Item2;
        }

    }
}