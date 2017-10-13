using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AssignmentCheck.Models
{
    [XmlInclude(typeof(DirectoryExistsCriterion))]
    [XmlInclude(typeof(CompileCriterion))]
    public abstract class Criterion
    {
        public virtual string Description { get; set; }
        public abstract Tuple<bool, string> Validate(string userBasePath);
    }
}
