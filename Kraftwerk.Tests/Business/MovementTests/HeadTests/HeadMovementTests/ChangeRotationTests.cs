using Kraftwerk.Business.Movement.Head;
using Kraftwerk.ValueObjects.Head;
using Kraftwerk.ValueObjects.Robot;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kraftwerk.Tests.Business.MovementTests.HeadTests.HeadMovementTests
{
    public class ChangeRotationTests
    {
        private IHeadMovement _headMovement;

        public ChangeRotationTests() => _headMovement = new HeadMovement();

        [Fact]
        public void DevePermitirRotacionarCabeca()
        {
            //Arrange
            var robot = new RobotVO()
            {
                Head = new HeadVO()
                {
                    HeadInclination = HeadInclination.InRest,
                    HeadRotation = HeadRotation.InRest
                }
            };

            HeadRotation headRotation = HeadRotation.Rotate45Degrees;

            //Act
            var result = _headMovement.ChangeRotation(robot, headRotation);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void NaoDevePermitirRotacionarCabeca()
        {
            //Arrange
            var robot = new RobotVO()
            {
                Head = new HeadVO()
                {
                    HeadInclination = HeadInclination.Down,
                    HeadRotation = HeadRotation.InRest
                }
            };

            HeadRotation headRotation = HeadRotation.Rotate45Degrees;

            //Act
            var result = _headMovement.ChangeRotation(robot, headRotation);

            //Assert
            Assert.False(result);
        }
    }
}
