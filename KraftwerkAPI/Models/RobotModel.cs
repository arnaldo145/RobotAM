using KraftwerkAPI.Models.Arm;
using KraftwerkAPI.Models.Head;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace KraftwerkAPI.Models
{
    public class RobotModel
    {
        public long Id { get; set; }
        public HeadModel Head { get; set; }
        public ArmModel LeftArm { get; set; }
        public ArmModel RightArm { get; set; }
    }
}
