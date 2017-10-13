using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace AssignmentCheck.Models
{
    [Serializable]
    public class Assignment
    {
        public string Title { get; set; }

        public List<Criterion> Criteria { get; set; }
        
        public List<CriterionResult> CheckCriterion(string basePath)
        {
            List<CriterionResult> results = new List<CriterionResult>();
            foreach(Criterion test in Criteria)
            {
                Tuple<bool, string> result  = test.Validate(basePath);
                CriterionResult toAdd = new CriterionResult(result, test.Description);
                results.Add(toAdd);
            }
            return results;
        }
    }
}