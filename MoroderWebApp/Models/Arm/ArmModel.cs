using Kraftwerk.ValueObjects.Arm;
using Moroder.Business.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoroderWebApp.Models.Arm
{
    public class ArmModel
    {
        public ElbowMovement Elbow { get; set; }
        public string ElbowDescription => Elbow.GetDescription();
        public WristMovement Wrist { get; set; }
        public string WristDescription => Wrist.GetDescription();
    }
}
