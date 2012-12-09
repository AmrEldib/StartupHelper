using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartupHelper.Profiles
{
    public class WirelessNetworkNameCondition : StartupCondition
    {
        public string SsidName { get; set; }
    }
}
