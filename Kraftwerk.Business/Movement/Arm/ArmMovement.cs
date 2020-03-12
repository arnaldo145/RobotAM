using Kraftwerk.ValueObjects.Arm;
using Kraftwerk.ValueObjects.Robot;

namespace Kraftwerk.Business.Movement.Arm
{
    public class ArmMovement : IArmMovement
    {
        public bool ChangeElbowMovement(ArmVO arm, ElbowMovement elbowMovement) => true;

        public bool ChangeWristMovement(ArmVO arm, WristMovement wristMovement)
        {
            if (arm.Elbow != ElbowMovement.StronglyContracted)
                return false;

            return true;
        }

        public bool CanMoveArm(RobotVO robot, ArmVO armMoved, ArmSide armSide)
        {
            ArmVO arm = armSide == ArmSide.Left ? robot.LeftArm : robot.RightArm;

            bool isElbowMovement = IsElbowMovement(arm, armMoved.Elbow);
            bool isWristMovement = IsWristMovement(arm, armMoved.Wrist);

            // Não se pode mexer mais de uma parte do braço por vez
            if (isElbowMovement && isWristMovement)
                return false;

            if (isElbowMovement)
                return ChangeElbowMovement(arm, armMoved.Elbow);

            if (isWristMovement)
                return ChangeWristMovement(arm, armMoved.Wrist);

            //Não houve mudança
            return true;
        }

        private bool IsElbowMovement(ArmVO arm, ElbowMovement elbowMovement) => arm.Elbow != elbowMovement;

        private bool IsWristMovement(ArmVO arm, WristMovement wristMovement) => arm.Wrist != wristMovement;
    }
}
