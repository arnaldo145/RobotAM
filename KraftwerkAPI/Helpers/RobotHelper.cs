using Kraftwerk.ValueObjects.Arm;
using Kraftwerk.ValueObjects.Head;
using KraftwerkAPI.Models.Arm;
using KraftwerkAPI.Models.Head;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraftwerkAPI.Helpers
{
    public class RobotHelper
    {
        public static ArmModel CreateDefaultArm()
        {
            return new ArmModel()
            {
                Elbow = ElbowMovement.InRest,
                Wrist = WristMovement.InRest
            };
        }

        public static HeadModel CreadDefaultHead()
        {
            return new HeadModel()
            {
                HeadInclination = HeadInclination.InRest,
                HeadRotation = HeadRotation.InRest
            };
        }
    }
}
