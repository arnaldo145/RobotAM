using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraftwerkAPI.Models.Arm
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
