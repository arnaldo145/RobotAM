using System;
using System.Collections.Generic;
using System.Text;

namespace Kraftwerk.ValueObjects.Arm
{
    public class ArmVO
    {
        public ElbowMovement Elbow { get; set; }
        public WristMovement Wrist { get; set; }
    }
}
