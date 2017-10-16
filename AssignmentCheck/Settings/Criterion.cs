using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AssignmentCheck.Settings
{
    public abstract class Criterion
    {
        public virtual string Description { get; set; }
        public abstract CriterionResult Validate(string userBasePath);
    }
}
