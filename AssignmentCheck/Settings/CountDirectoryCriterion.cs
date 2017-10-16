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
    public class CountDirectoryCriterion : DirectoryExistsCriterion
    {
        public int Count { get; set; }

        public override CriterionResult Validate(string path)
        {
            //setup the full path by safely adding the extra path.
            string fullPath = Path.Combine(path, SubPath?.Trim('\\') ?? "");

            //check the base type which sees if the directory in the sub path exists first.
            CriterionResult baseResult = base.Validate(path);
            if (!baseResult.IsValid)
            {
                return baseResult;
            }
            //grab the directories in the path
            var directories = Directory.GetDirectories(fullPath);
            if (directories != null && directories.Length == Count)
            {
                return new CriterionResult()
                {
                    IsValid = true,
                    Description = Description,
                    Message = $"You have {Count} directories in your {SubPath} folder, good job!"
                };
            }
            else
            {
                return new CriterionResult()
                {
                    IsValid = false,
                    Description = Description,
                    Message = $"You have {directories?.Length ?? 0} directories in your {SubPath} folder, but you should have {Count}."
                };
            }
        }
    }
}