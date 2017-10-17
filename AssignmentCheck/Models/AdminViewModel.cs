using AssignmentCheck.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentCheck.Models
{
    public class AdminViewModel
    {
        public IEnumerable<Tuple<string, AssignmentResult>> Results { get; set; }
    }
}