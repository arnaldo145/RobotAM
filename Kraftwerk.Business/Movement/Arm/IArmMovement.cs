using Kraftwerk.ValueObjects.Arm;
using Kraftwerk.ValueObjects.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kraftwerk.Business.Movement.Arm
{
    public interface IArmMovement : IMovement
    {
        bool ChangeElbowMovement(ArmVO arm, ElbowMovement newElbowMovement);
        bool ChangeWristMovement(ArmVO arm, WristMovement newWristMovement);
        bool CanMoveArm(RobotVO robot, ArmVO armMoved, ArmSide armSide);
    }
}
