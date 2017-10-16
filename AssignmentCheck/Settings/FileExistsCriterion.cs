using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AssignmentCheck.Extensions;

namespace AssignmentCheck.Settings
{
    public class FileExistsCriterion : DirectoryExistsCriterion
    {
        public string FileNamePattern { get; set; }
        public int Depth { get; set; }

        public override CriterionResult Validate(string path)
        {
            CriterionResult baseResult = base.Validate(path);
            if (!baseResult.IsValid)
            {
                return baseResult;
            }
            //setup the full path by safely adding the extra path.
            string fullPath = Path.Combine(path, SubPath?.Trim('\\') ?? "");
            //next step down directories based on the depth specified 
            var directories = fullPath.GetDirectoriesAtDepth(Depth);
            var patterns = FileNamePattern.Split(',');
            if (directories != null && directories.Any())
            {
                //check the file pattern
                foreach (var dir in directories)
                {
                    foreach (var pattern in patterns) {
                        if (Directory.GetFiles(dir, pattern).Any())
                        {
                            return new CriterionResult()
                            {
                                Description = Description,
                                IsValid = true,
                                Message = $"You have a '{FileNamePattern}' file {Depth} folders deep in your in your '{SubPath}' folder."
                            };
                        }
                    }
                }
            }
            //if we end up here the file is not found
            return new CriterionResult()
            {
                Description = Description,
                IsValid = false,
                Message = $"Could not find a file like '{FileNamePattern}' {Depth} folders down from the '{SubPath}' folder."
            };

        }
    }
}