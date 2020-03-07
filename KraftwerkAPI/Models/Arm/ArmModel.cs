using Kraftwerk.ValueObjects.Arm;

namespace KraftwerkAPI.Models.Arm
{
    public class ArmModel
    {
        public ElbowMovement Elbow { get; set; }
        public WristMovement Wrist { get; set; }
    }
}
