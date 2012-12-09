using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartupHelper.Profiles
{
    public class NumberOfMonitorsCondition : StartupCondition
    {
        public int MonitorCount { get; set; }
    }
}
