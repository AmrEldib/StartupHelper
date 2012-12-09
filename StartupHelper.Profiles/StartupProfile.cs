using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartupHelper.Profiles
{
    public class StartupProfile
    {
        public List<ConditionProfile> ConditionsProfiles { get; set; }

        public List<Application> Applications { get; set; }
    }
}
