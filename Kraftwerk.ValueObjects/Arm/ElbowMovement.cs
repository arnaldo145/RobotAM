using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Kraftwerk.ValueObjects.Arm
{
    public enum ElbowMovement
    {
        [Description("Em repouso")]
        InRest = 1,
        [Description("Levement contraído")]
        SlightlyContracted = 2,
        [Description("Contraído")]
        Contracted = 3,
        [Description("Fortemente contraído")]
        StronglyContracted = 4
    }
}
