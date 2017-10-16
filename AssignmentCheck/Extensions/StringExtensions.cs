using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentCheck.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveDomainFromIdentity(this string identity)
        {
            if (string.IsNullOrWhiteSpace(identity))
            {
                return identity;
            }
            int indexOfFirstSlash = identity.IndexOf('\\');
            if(indexOfFirstSlash < 0)
            {
                return identity;
            }
            return identity.Substring(indexOfFirstSlash + 1);
        }
    }
}