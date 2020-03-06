using Kraftwerk.Models.Arm;
using Kraftwerk.Models.Head;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kraftwerk.Models.Robot
{
    public class RobotModel
    {
        public HeadModel Head { get; set; }
        public ArmModel LeftArm { get; set; }
        public ArmModel RightArm { get; set; }
    }
}
