using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KraftwerkAPI.Models;
using KraftwerkAPI.Models.Head;
using KraftwerkAPI.Models.Arm;
using Kraftwerk.Business.Movement.Arm;
using Kraftwerk.Business.Movement.Head;
using AutoMapper;
using Kraftwerk.ValueObjects.Robot;
using Kraftwerk.ValueObjects.Head;
using Kraftwerk.ValueObjects.Arm;
using KraftwerkAPI.Builders;
using KraftwerkAPI.Helpers;

namespace KraftwerkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly RobotContext _context;
        private readonly RobotBuilder _robotBuilder;
        private readonly RobotReset _robotReset;
        private readonly IMapper _mapper;
        private readonly IArmMovement _armMovement;
        private readonly IHeadMovement _headMovement;

        public RobotController(RobotContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _armMovement = new ArmMovement();
            _headMovement = new HeadMovement();
            _robotBuilder = new RobotBuilder();
            _robotReset = new RobotReset();
        }

        // GET: api/Robot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RobotModel>>> GetRobots() => await _context.Robots.ToListAsync();

        // GET: api/Robot/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RobotModel>> GetRobotModel(long id)
        {
            var robot = await _context.Robots.FindAsync(id);

            if (robot == null)
                return NotFound();

            return robot;
        }

        // POST: api/Robot
        [HttpPost]
        public async Task<ActionResult<RobotModel>> PostRobotModel()
        {
            RobotModel robot = CreateDefaultRobot();
            _context.Robots.Add(robot);
            await _context.SaveChangesAsync();
            return CreatedAtAction("PostRobotModel", new { id = robot.Id }, robot);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<RobotModel>> PostRobotModel(long id)
        {
            var robot = await _context.Robots.FindAsync(id);

            if (robot is null)
                return NotFound();

            _robotReset.Reset(robot);
            _context.Entry(robot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Robot/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RobotModel>> DeleteRobotModel(long id)
        {
            var robot = await _context.Robots.FindAsync(id);

            if (robot == null)
                return NotFound();

            _context.Robots.Remove(robot);
            await _context.SaveChangesAsync();

            return robot;
        }

        #region Movimentos do Robô

        // PUT: api/Robot/5/Head
        [HttpPut("{id}/Head")]
        public async Task<IActionResult> PutHead(long id, [FromBody]HeadModel headMoved)
        {
            RobotModel robot = await _context.Robots.FindAsync(id);

            if (robot is null)
                return NotFound();

            var robotVO = _mapper.Map<RobotVO>(robot);
            var headMovedVO = _mapper.Map<HeadVO>(headMoved);

            var canMoveHead = _headMovement.CanMoveHead(robotVO, headMovedVO);

            if (canMoveHead == false)
                return BadRequest();

            robot.Head = headMoved;

            _context.Entry(robot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // PUT: api/Robot/5/LeftArm
        [HttpPut("{id}/LeftArm")]
        public async Task<IActionResult> PutLeftArm(long id, [FromBody]ArmModel leftArmMoved)
        {
            RobotModel robot = await _context.Robots.FindAsync(id);

            if (robot is null)
                return NotFound();

            var robotVO = _mapper.Map<RobotVO>(robot);
            var leftArmMovedVO = _mapper.Map<ArmVO>(leftArmMoved);
            var canMoveLeftArm = _armMovement.CanMoveArm(robotVO, leftArmMovedVO, ArmSide.Left);

            if (canMoveLeftArm == false)
                return BadRequest();

            robot.LeftArm = leftArmMoved;

            _context.Entry(robot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // PUT: api/Robot/5/RightArm
        [HttpPut("{id}/RightArm")]
        public async Task<IActionResult> PutRightArm(long id, [FromBody]ArmModel rightArmMoved)
        {
            RobotModel robot = await _context.Robots.FindAsync(id);

            if (robot is null)
                return NotFound();

            var robotVO = _mapper.Map<RobotVO>(robot);
            var rightArmMovedVO = _mapper.Map<ArmVO>(rightArmMoved);
            var canMoveLeftArm = _armMovement.CanMoveArm(robotVO, rightArmMovedVO, ArmSide.Right);

            if (canMoveLeftArm == false)
                return BadRequest();

            robot.RightArm = rightArmMoved;
            _context.Entry(robot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // GET: api/Robot/5/Head
        [HttpGet("{id}/Head")]
        public async Task<ActionResult<HeadModel>> GetHead(long id)
        {
            var robot = await _context.Robots.FindAsync(id);

            if (robot == null)
                return NotFound();

            return robot.Head;
        }

        // GET: api/Robot/5/LeftArm
        [HttpGet("{id}/LeftArm")]
        public async Task<ActionResult<ArmModel>> GetLeftArm(long id)
        {
            var robot = await _context.Robots.FindAsync(id);

            if (robot == null)
                return NotFound();

            return robot.LeftArm;
        }

        // GET: api/Robot/5/RightArm
        [HttpGet("{id}/RightArm")]
        public async Task<ActionResult<ArmModel>> GetRightArm(long id)
        {
            var robot = await _context.Robots.FindAsync(id);

            if (robot == null)
                return NotFound();

            return robot.RightArm;
        }

        #endregion

        [NonAction]
        private RobotModel CreateDefaultRobot()
        {
            return _robotBuilder
                .CreateRobot()
                .WithHead()
                .WithLeftArm()
                .WithRightArm()
                .Get();
        }
    }
}
