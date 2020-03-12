using Kraftwerk.ValueObjects.Arm;
using Kraftwerk.ValueObjects.Head;
using Kraftwerk.ValueObjects.Robot;
using Kraftwerk.ValueObjects.RobotResult;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moroder.Business.Services
{
    public interface IRobotService
    {
        IEnumerable<RobotVO> GetRobots();
        RobotVO GetRobot(long id);
        long PostRobot();
        bool DeleteRobot(long id);
        bool PutHead(long id, HeadVO headMoved);
        bool PutLeftArm(long id, ArmVO leftArmMoved);
        bool PutRightArm(long id, ArmVO rightArmMoved);
        HeadVO GetHead(long id);
        ArmVO GetLeftArm(long id);
        ArmVO GetRightArm(long id);

    }
}
