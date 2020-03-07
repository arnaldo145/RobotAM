using Kraftwerk.ValueObjects.Head;
using Kraftwerk.ValueObjects.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kraftwerk.Business.Movement.Head
{
    public class HeadMovement : IHeadMovement
    {
        public bool CanMoveHead(RobotVO robot, HeadVO headMoved)
        {
            var isInclinationMovement = IsInclinationMovement(robot, headMoved.HeadInclination);
            var isRotationMovement = IsRotationMovement(robot, headMoved.HeadRotation);

            // Não pode haver dois movimentos de uma vez
            if (isInclinationMovement && isRotationMovement)
                return false;

            if (isInclinationMovement)
                return ChangeInclination(robot, headMoved.HeadInclination);

            if (isRotationMovement)
                return ChangeRotation(robot, headMoved.HeadRotation);

            //Não houve movimento
            return true;
        }

        public bool ChangeInclination(RobotVO robot, HeadInclination headInclination)
        {
            return true;
        }

        public bool ChangeRotation(RobotVO robot, HeadRotation headRotation)
        {
            if (robot.Head.HeadInclination == HeadInclination.Down)
                return false;

            return true;
        }

        private bool IsInclinationMovement(RobotVO robot, HeadInclination inclination) => robot.Head.HeadInclination != inclination;

        private bool IsRotationMovement(RobotVO robot, HeadRotation rotation) => robot.Head.HeadRotation != rotation;
    }
}
