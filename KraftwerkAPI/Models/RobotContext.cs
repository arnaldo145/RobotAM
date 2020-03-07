using KraftwerkAPI.Models.Arm;
using KraftwerkAPI.Models.Head;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraftwerkAPI.Models
{
    public class RobotContext : DbContext
    {
        public RobotContext(DbContextOptions<RobotContext> options) : base(options)
        {
        }

        public DbSet<RobotModel> Robots { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RobotModel>().ToTable("Robot");
            builder.Entity<RobotModel>().HasKey(m => m.Id);

            builder.Entity<RobotModel>()
                .Property(m => m.Head)
                .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<HeadModel>(v));

            builder.Entity<RobotModel>()
               .Property(m => m.LeftArm)
               .HasConversion(
               v => JsonConvert.SerializeObject(v),
               v => JsonConvert.DeserializeObject<ArmModel>(v));

            builder.Entity<RobotModel>()
               .Property(m => m.RightArm)
               .HasConversion(
               v => JsonConvert.SerializeObject(v),
               v => JsonConvert.DeserializeObject<ArmModel>(v));

            base.OnModelCreating(builder);
        }
    }
}
