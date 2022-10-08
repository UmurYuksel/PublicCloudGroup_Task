using AutoMapper;
using Google.Cloud.Compute.V1;
using publiccloudgroup_api.DTO_s;
using publiccloudgroup_api.Models;


namespace publiccloudgroup_api.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            CreateMap<StartRequestModelDto, StartInstanceRequest>()
                .ForMember(x => x.Instance, y => y.MapFrom(z => z.InstanceName)).ReverseMap();

            CreateMap<StopRequestModelDto, StopInstanceRequest>()
               .ForMember(x => x.Instance, y => y.MapFrom(z => z.InstanceName)).ReverseMap();

            CreateMap<SuspendInstanceRequest, SuspendRequestModelDto>()
             .ForMember(x => x.InstanceName, y => y.MapFrom(z => z.Instance)).ReverseMap();


            CreateMap<ResumeInstanceRequest, ResumeRequestModelDto>()
             .ForMember(x => x.InstanceName, y => y.MapFrom(z => z.Instance)).ReverseMap();

            CreateMap<Instance, InstanceDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
