using Kraftwerk.Models.Arm;
using Kraftwerk.Models.Head;
using Kraftwerk.Models.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraftwerkAPI.Builders
{
    public class RobotBuilder
    {
        private RobotModel _robot;

        public RobotBuilder CreateRobot()
        {
            _robot = new RobotModel();
            return this;
        }

        public RobotBuilder WithHead()
        {
            _robot.Head = new HeadModel() 
            {
                HeadInclination = HeadInclination.InRest,
                HeadRotation = HeadRotation.InRest
            };

            return this;
        }

        public RobotBuilder WithLeftArm()
        {
            _robot.LeftArm = CreateDefaultArm();
            return this;
        }

        public RobotBuilder WithRightArm()
        {
            _robot.RightArm = CreateDefaultArm();
            return this;
        }

        private ArmModel CreateDefaultArm()
        {
            return new ArmModel()
            {
                Elbow = ElbowMovement.InRest,
                Wrist = WristMovement.InRest
            };
        }

        public RobotModel Get()
        {
            return _robot;
        }
    }
}
