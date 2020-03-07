using Kraftwerk.ValueObjects.Head;
using Kraftwerk.ValueObjects.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kraftwerk.Business.Movement.Head
{
    public interface IHeadMovement : IMovement
    {
        bool ChangeInclination(RobotVO robot, HeadInclination newHeadInclination);
        bool ChangeRotation(RobotVO robot, HeadRotation newHeadRotation);
        bool CanMoveHead(RobotVO robot, HeadVO headMoved);
    }
}
