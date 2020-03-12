using Kraftwerk.Business.Movement.Arm;
using Kraftwerk.ValueObjects.Arm;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kraftwerk.Tests.Business.MovementTests.ArmTests.ArmMovementTests
{
    public class ChangeWristMovementTests
    {
        private IArmMovement _armMovement;

        public ChangeWristMovementTests() => _armMovement = new ArmMovement();

        [Fact]
        public void DevePermitirMovimentoDoPulso()
        {
            //Arrange
            ArmVO arm = new ArmVO() 
            {
                Elbow = ElbowMovement.StronglyContracted,
                Wrist = WristMovement.InRest
            };

            WristMovement wristMovement = WristMovement.Rotate135Degrees;

            //Act
            var result = _armMovement.ChangeWristMovement(arm, wristMovement);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void NaoDevePermitirMovimentoDoPulso()
        {
            //Assert
            ArmVO arm = new ArmVO()
            {
                Elbow = ElbowMovement.InRest,
                Wrist = WristMovement.InRest
            };

            WristMovement wristMovement = WristMovement.Rotate135Degrees;

            //Act
            var result = _armMovement.ChangeWristMovement(arm, wristMovement);

            //Assert
            Assert.False(result);
        }
    }
}
