using AutoMapper;
using Kraftwerk.ValueObjects.Arm;
using Kraftwerk.ValueObjects.Head;
using Kraftwerk.ValueObjects.Robot;
using MoroderWebApp.Models.Arm;
using MoroderWebApp.Models.Head;
using MoroderWebApp.Models.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoroderWebApp.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RobotModel, RobotVO>()
                .ReverseMap();

            CreateMap<HeadModel, HeadVO>()
                .ReverseMap();

            CreateMap<ArmModel, ArmVO>()
                .ReverseMap();
        }
    }
}
