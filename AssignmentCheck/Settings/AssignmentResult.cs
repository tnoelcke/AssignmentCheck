using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentCheck.Settings
{
    public class AssignmentResult
    {
        public string Title { get; set; }

        public List<CriterionResult> Results { get; set; }

        public int ValidCount
        {
            get { return Results?.Count(c => c.IsValid) ?? 0; }
        }

        public int CriteriaCount
        {
            get { return Results?.Count ?? 0; }
        }

        public bool AreAllValid
        {
            get { return ValidCount == CriteriaCount; }
        }
    }
}