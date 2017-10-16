using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;

namespace AssignmentCheck.Settings
{
    [Serializable]
    [XmlRoot("Criterion")]
    public class DirectoryExistsCriterion : Criterion
    {
        public string SubPath { get; set; }
        public override CriterionResult Validate(string path)
        {
            //setup the full path by safely adding the extra path.
            string fullPath = Path.Combine(path, SubPath?.Trim('\\') ?? "");
            //grab the directories in the path
            if (!Directory.Exists(fullPath))
            {
                return new CriterionResult()
                {
                    IsValid = false,
                    Description = Description,
                    Message = $"The folder {fullPath} does not exist, looks like you may not have created the folder {SubPath} correctly."
                };
            }
            return new CriterionResult()
            {
                IsValid = true,
                Description = Description,
                Message = $"You succesfully created the folder {SubPath}, good job!"
            };
        }
    }
}