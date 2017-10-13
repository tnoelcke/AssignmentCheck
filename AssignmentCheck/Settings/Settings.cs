using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssignmentCheck.Properties;
using AssignmentCheck.Settings;
using AssignmentCheck.Models;

namespace AssignmentCheck.Properties
{

    internal partial class Settings
    {
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public List<Assignment> Assignments
        {
            get
            {
                return ((List<Assignment>)(this["Assignments"]));
            }
        }
        
    }
}