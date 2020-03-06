using Kraftwerk.Models.Robot;
using KraftwerkAPI.Builders;
using Microsoft.EntityFrameworkCore;

namespace KraftwerkAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public RobotModel Robot { get; set; }
        private readonly RobotBuilder _robotBuilder = new RobotBuilder();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Robot = _robotBuilder.CreateRobot()
            .WithHead()
            .WithLeftArm()
            .WithRightArm()
            .Get();
        }
    }
}