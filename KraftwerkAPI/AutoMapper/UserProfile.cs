using Kraftwerk.ValueObjects.Robot;
using KraftwerkAPI.Models;
using AutoMapper;
using Kraftwerk.ValueObjects.Head;
using KraftwerkAPI.Models.Head;
using KraftwerkAPI.Models.Arm;
using Kraftwerk.ValueObjects.Arm;

namespace KraftwerkAPI.AutoMapper
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
