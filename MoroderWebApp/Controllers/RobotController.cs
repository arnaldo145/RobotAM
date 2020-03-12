using AutoMapper;
using Kraftwerk.Business.Movement.Arm;
using Kraftwerk.ValueObjects.Arm;
using Kraftwerk.ValueObjects.Head;
using Kraftwerk.ValueObjects.Robot;
using Microsoft.AspNetCore.Mvc;
using Moroder.Business.Services;
using Moroder.Business.Util;
using MoroderWebApp.Helpers;
using MoroderWebApp.Models.Robot;
using System.IO;

namespace MoroderWebApp.Controllers
{
    public class RobotController : Controller
    {
        private readonly IRobotService _robotService;
        private readonly IMapper _mapper;

        public RobotController(IMapper mapper, IRobotService robotService)
        {
            _mapper = mapper;
            _robotService = robotService;
        }

        public IActionResult Index(long id)
        {
            RobotVO robot = _robotService.GetRobot(id);

            if (robot == null)
                return RedirectToAction("Index", "Home");

            RobotModel robotModel = _mapper.Map<RobotModel>(robot);
            return View(robotModel);
        }

        [HttpPost]
        public IActionResult RotateHeadToLeft(long id)
        {
            HeadVO robotHead = _robotService.GetHead(id);
            int newRotationNumber = ((int)robotHead.HeadRotation) - 1;
            return ChangeRobotHeadRotation(id, robotHead, newRotationNumber);
        }

        [HttpPost]
        public IActionResult RotateHeadToRight(long id)
        {
            HeadVO robotHead = _robotService.GetHead(id);
            int newRotationNumber = ((int)robotHead.HeadRotation) + 1;
            return ChangeRobotHeadRotation(id, robotHead, newRotationNumber);
        }

        [NonAction]
        private JsonResult ChangeRobotHeadRotation(long id, HeadVO robotHead, int newRotationNumber)
        {
            HeadRotation newHeadRotation;
            string newHeadRotationDescription = string.Empty;

            bool isValidMovement = newRotationNumber.TryParseEnum(out newHeadRotation);

            if (isValidMovement)
            {
                robotHead.HeadRotation = newHeadRotation;
                newHeadRotationDescription = robotHead.HeadRotation.GetDescription();

                bool isHeadMoved = _robotService.PutHead(id, robotHead);

                if (isHeadMoved == false)
                    isValidMovement = false;
            }

            return Json(new { isValidMovement, description = newHeadRotationDescription });
        }

        [HttpPost]
        public IActionResult TiltUpHead(long id)
        {
            HeadVO robotHead = _robotService.GetHead(id);
            int newInclinationNumber = ((int)robotHead.HeadInclination) - 1;
            return ChangeRobotInclination(id, robotHead, newInclinationNumber);
        }

        [HttpPost]
        public IActionResult TiltDownHead(long id)
        {
            HeadVO robotHead = _robotService.GetHead(id);
            int newInclinationNumber = ((int)robotHead.HeadInclination) + 1;
            return ChangeRobotInclination(id, robotHead, newInclinationNumber);
        }

        [NonAction]
        private JsonResult ChangeRobotInclination(long id, HeadVO robotHead, int newInclinationNumber)
        {
            HeadInclination newHeadInclination;
            string newHeadInclinationDescription = string.Empty;

            bool isValidMovement = newInclinationNumber.TryParseEnum(out newHeadInclination);

            if (isValidMovement)
            {
                robotHead.HeadInclination = newHeadInclination;
                newHeadInclinationDescription = robotHead.HeadInclination.GetDescription();

                bool isHeadMoved = _robotService.PutHead(id, robotHead);

                if (isHeadMoved == false)
                    isValidMovement = false;
            }

            return Json(new { isValidMovement, description = newHeadInclinationDescription });
        }

        [HttpPost]
        public IActionResult StretchLeftElbow(long id)
        {
            var leftArm = _robotService.GetLeftArm(id);
            int newPositionElbowNumeric = ((int)leftArm.Elbow) + 1;

            return ChangeElbowPosition(id, leftArm, newPositionElbowNumeric, ArmSide.Left);
        }

        [HttpPost]
        public IActionResult RelaxLeftElbow(long id)
        {
            var leftArm = _robotService.GetLeftArm(id);
            int newPositionElbowNumeric = ((int)leftArm.Elbow) - 1;

            return ChangeElbowPosition(id, leftArm, newPositionElbowNumeric, ArmSide.Left);
        }

        [HttpPost]
        public IActionResult StretchRightElbow(long id)
        {
            var rightArm = _robotService.GetLeftArm(id);
            int newPositionElbowNumeric = ((int)rightArm.Elbow) + 1;

            return ChangeElbowPosition(id, rightArm, newPositionElbowNumeric, ArmSide.Right);
        }

        [HttpPost]
        public IActionResult RelaxRightElbow(long id)
        {
            var rightArm = _robotService.GetLeftArm(id);
            int newPositionElbowNumeric = ((int)rightArm.Elbow) - 1;

            return ChangeElbowPosition(id, rightArm, newPositionElbowNumeric, ArmSide.Right);
        }

        [NonAction]
        private JsonResult ChangeElbowPosition(long id, ArmVO arm, int newPositionElbowNumeric, ArmSide armSide)
        {
            ElbowMovement newElbowMovement;
            string movementDescription = string.Empty;

            bool isValidMovement = newPositionElbowNumeric.TryParseEnum(out newElbowMovement);

            if (isValidMovement)
            {
                arm.Elbow = newElbowMovement;
                movementDescription = arm.Elbow.GetDescription();

                bool isArmMoved = armSide == ArmSide.Left ? _robotService.PutLeftArm(id, arm) : _robotService.PutRightArm(id, arm);

                if (isArmMoved == false)
                    isValidMovement = false;
            }

            return Json(new { isValidMovement, description = movementDescription });
        }

        [HttpPost]
        public IActionResult RotateToLeftLeftWrist(long id)
        {
            var leftArm = _robotService.GetLeftArm(id);
            int newPositionWristNumeric = ((int)leftArm.Wrist) - 1;
            return ChangeWristPosition(id, leftArm, newPositionWristNumeric, ArmSide.Left);
        }

        [HttpPost]
        public IActionResult RotateToRightLeftWrist(long id)
        {
            var leftArm = _robotService.GetLeftArm(id);
            int newPositionWristNumeric = ((int)leftArm.Wrist) + 1;
            return ChangeWristPosition(id, leftArm, newPositionWristNumeric, ArmSide.Left);
        }

        [HttpPost]
        public IActionResult RotateToLeftRightWrist(long id)
        {
            var rightArm = _robotService.GetLeftArm(id);
            int newPositionWristNumeric = ((int)rightArm.Wrist) - 1;
            return ChangeWristPosition(id, rightArm, newPositionWristNumeric, ArmSide.Right);
        }

        [HttpPost]
        public IActionResult RotateToRightRightWrist(long id)
        {
            var rightArm = _robotService.GetLeftArm(id);
            int newPositionWristNumeric = ((int)rightArm.Wrist) + 1;
            return ChangeWristPosition(id, rightArm, newPositionWristNumeric, ArmSide.Right);
        }

        [NonAction]
        private JsonResult ChangeWristPosition(long id, ArmVO arm, int newPositionWristNumeric, ArmSide armSide)
        {
            WristMovement newWristMovement;
            string movementDescription = string.Empty;

            bool isValidMovement = newPositionWristNumeric.TryParseEnum(out newWristMovement);

            if (isValidMovement)
            {
                arm.Wrist = newWristMovement;
                movementDescription = arm.Wrist.GetDescription();

                bool isArmMoved = armSide == ArmSide.Left ? _robotService.PutLeftArm(id, arm) : _robotService.PutRightArm(id, arm);

                if (isArmMoved == false)
                    isValidMovement = false;
            }

            return Json(new { isValidMovement, description = movementDescription });
        }

        [HttpPost]
        public IActionResult DeleteRobot(long id)
        {
            bool isRobotDeleted = _robotService.DeleteRobot(id);
            return Json(new { isRobotDeleted });
        }
    }
}