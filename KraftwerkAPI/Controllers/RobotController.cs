using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kraftwerk.Models.Robot;
using KraftwerkAPI.Builders;
using KraftwerkAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KraftwerkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly ApplicationDbContext database;

        public RobotController(ApplicationDbContext database)
        {
            this.database = database;
        }
        
        // GET: api/Robot
        [HttpGet]
        public RobotModel Get()
        {
            return this.database.Robot;
        }

        // POST: api/Robot
        [HttpPost]
        public void Post([FromBody] RobotModel robot)
        {
            this.database.Robot = robot;
        }
    }
}
