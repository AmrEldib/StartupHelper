using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartupHelper.Profiles
{
    public class TimeCondition : StartupCondition
    {
        public DateTime Time { get; set; }

        public TimeCondition()
        {

        }
    }
}
