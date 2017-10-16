using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AssignmentCheck.Extensions
{
    public static class DirectoryExtensions
    {
        public static IEnumerable<string> GetDirectoriesAtDepth(this string baseDirectory, int maxDepth)
        {
            return baseDirectory.GetDirectoriesAtDepth(maxDepth, 0);
        }
        private static IEnumerable<string> GetDirectoriesAtDepth(this string baseDirectory, int maxDepth, int currentDepth)
        {
            if (string.IsNullOrWhiteSpace(baseDirectory) || maxDepth <= currentDepth || !Directory.Exists(baseDirectory))
            {
                return new string[] { baseDirectory };
            }
            else
            {
                var nextLevelDirs = Directory.GetDirectories(baseDirectory);
                int nextDepth = currentDepth + 1;
                return nextLevelDirs.SelectMany(d => d.GetDirectoriesAtDepth(maxDepth, nextDepth).ToArray());
            }

        }
    }
}