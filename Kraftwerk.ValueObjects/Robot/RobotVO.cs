using Kraftwerk.ValueObjects.Arm;
using Kraftwerk.ValueObjects.Head;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kraftwerk.ValueObjects.Robot
{
    public class RobotVO
    {
        public long Id { get; set; }
        public HeadVO Head { get; set; }
        public ArmVO LeftArm { get; set; }
        public ArmVO RightArm { get; set; }
    }
}
