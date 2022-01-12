using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Enums
{
    public enum Movement
    {
        [Description("None")]
        N = 0,
        [Description("Left")]
        L = 1,
        [Description("Right")]
        R = 2,
        [Description("Move")]
        M = 3,
    }
}
