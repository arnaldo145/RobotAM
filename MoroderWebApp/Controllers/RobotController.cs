using AutoMapper;
using Kraftwerk.Business.Movement.Arm;
using Kraftwerk.ValueObjects.Head;
using Kraftwerk.ValueObjects.Robot;
using Microsoft.AspNetCore.Mvc;
using Moroder.Business.Services;
using Moroder.Business.Util;
using MoroderWebApp.Helpers;
using MoroderWebApp.Models.Robot;

namespace MoroderWebApp.Controllers
{
    public class RobotController : Controller
    {
        private readonly IRobotService _robotService;
        private readonly IMapper _mapper;
        private readonly IArmMovement _armMovement;

        public RobotController(IMapper mapper, IRobotService robotService, IArmMovement armMovement)
        {
            _mapper = mapper;
            _robotService = robotService;
            _armMovement = armMovement;
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
    }
}