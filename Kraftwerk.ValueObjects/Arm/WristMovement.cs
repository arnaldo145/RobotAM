using System;
using System.Collections.Generic;
using System.Text;

namespace Kraftwerk.ValueObjects.Arm
{
    public enum WristMovement
    {
        RotateMinus90Degrees = 1,
        RotateMinus45Degrees = 2,
        InRest = 3,
        Rotate45Degrees = 4,
        Rotate90Degrees = 5,
        Rotate135Degrees = 6,
        Rotate180Degrees = 7
    }
}
