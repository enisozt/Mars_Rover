using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Enums
{
    public enum Direction
    {
        [Description("Stable")]
        X = 0,
        [Description("North")]
        N = 1,
        [Description("East")]
        E = 2,
        [Description("South")]
        S = 3,
        [Description("West")]
        W = 4
    }
}
