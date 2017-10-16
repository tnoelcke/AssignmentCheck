using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace AssignmentCheck.Settings
{
    [Serializable]
    [XmlInclude(typeof(CompileCriterion))]
    [XmlInclude(typeof(DirectoryExistsCriterion))]
    [XmlInclude(typeof(CountDirectoryCriterion))]
    [XmlInclude(typeof(FileExistsCriterion))]
    public class Assignment
    {
        public string Title { get; set; }

        public List<Criterion> Criteria { get; set; }
        
        public AssignmentResult Validate(string basePath)
        {
            return new AssignmentResult()
            {
                Title = Title,
                Results = Criteria.Select(c => c.Validate(basePath)).ToList()
            };
        }
    }
}