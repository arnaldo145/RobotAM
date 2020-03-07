using KraftwerkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraftwerkAPI.Helpers
{
    public class RobotReset
    {
        public RobotModel Reset(RobotModel robot)
        {
            robot.Head = RobotHelper.CreadDefaultHead();
            robot.LeftArm = RobotHelper.CreateDefaultArm();
            robot.RightArm = RobotHelper.CreateDefaultArm();

            return robot;
        }
    }
}
