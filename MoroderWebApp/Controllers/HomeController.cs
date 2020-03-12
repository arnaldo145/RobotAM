using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Moroder.Business.Services;
using MoroderWebApp.Models;

namespace MoroderWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRobotService _robotService;

        public HomeController(IRobotService robotService)
        {
            _robotService = robotService;
        }

        public IActionResult Index()
        {
            var robots = _robotService.GetRobots();
            return View(robots);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateRobot()
        {
            var robotId = _robotService.PostRobot();

            if (robotId == 0)
            {
                return NoContent();
            }

            return RedirectToAction("Index", "Robot", new { id = robotId });
        }
    }
}
