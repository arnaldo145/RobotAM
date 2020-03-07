using Kraftwerk.ValueObjects.Arm;
using Kraftwerk.ValueObjects.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kraftwerk.Business.Movement.Arm
{
    public class ArmMovement : IArmMovement
    {
        public bool ChangeElbowMovement(ArmVO arm, ElbowMovement newElbowMovement)
        {
            return true;
        }

        public bool ChangeWristMovement(ArmVO arm, WristMovement newWristMovement)
        {
            if (arm.Elbow != ElbowMovement.StronglyContracted)
            {
                return false;
            }

            return true;
        }
    }
}
