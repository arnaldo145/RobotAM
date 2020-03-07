using Kraftwerk.ValueObjects.Arm;
using Kraftwerk.ValueObjects.Head;
using KraftwerkAPI.Helpers;
using KraftwerkAPI.Models;
using KraftwerkAPI.Models.Arm;
using KraftwerkAPI.Models.Head;

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
            _robot.Head = RobotHelper.CreadDefaultHead();
            return this;
        }

        public RobotBuilder WithLeftArm()
        {
            _robot.LeftArm = RobotHelper.CreateDefaultArm();
            return this;
        }

        public RobotBuilder WithRightArm()
        {
            _robot.RightArm = RobotHelper.CreateDefaultArm();
            return this;
        }

        public RobotModel Get()
        {
            return _robot;
        }
    }
}
