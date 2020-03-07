using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraftwerkAPI.Models.Arm
{
    public class ArmModel
    {
        public ElbowMovement Elbow { get; set; }
        public WristMovement Wrist { get; set; }
    }
}
