using AutoMapper;
using EntitiesDAL.Models;
using TestAppAngularCountry.Server.DataTransferObjects;

namespace TestAppAngularCountry.Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
