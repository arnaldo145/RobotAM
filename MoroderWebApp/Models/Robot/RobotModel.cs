using MoroderWebApp.Models.Arm;
using MoroderWebApp.Models.Head;

namespace MoroderWebApp.Models.Robot
{
    public class RobotModel
    {
        public long Id { get; set; }
        public HeadModel Head { get; set; }
        public ArmModel LeftArm { get; set; }
        public ArmModel RightArm { get; set; }
    }
}
