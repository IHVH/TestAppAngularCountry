using AutoMapper;
using EntitiesDAL.Models;
using Microsoft.AspNetCore.Identity;
using TestAppAngularCountry.Server.DataTransferObjects;

namespace TestAppAngularCountry.Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(u => u.Country, opt => opt.Ignore())
                .ForMember(u => u.CountryId, opt => opt.Ignore())
                .ForMember(u => u.Province, opt => opt.Ignore())
                .ForMember(u => u.ProvinceId, opt => opt.Ignore())
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForMember(u => u.NormalizedUserName, opt => opt.Ignore())
                .ForMember(u => u.NormalizedEmail, opt => opt.Ignore())
                .ForMember(u => u.EmailConfirmed, opt => opt.Ignore())
                .ForMember(u => u.PasswordHash, opt => opt.Ignore())
                .ForMember(u => u.SecurityStamp, opt => opt.Ignore())
                .ForMember(u => u.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(u => u.PhoneNumber, opt => opt.Ignore())
                .ForMember(u => u.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(u => u.TwoFactorEnabled, opt => opt.Ignore())
                .ForMember(u => u.LockoutEnd, opt => opt.Ignore())
                .ForMember(u => u.LockoutEnabled, opt => opt.Ignore())
                .ForMember(u => u.AccessFailedCount, opt => opt.Ignore());

            CreateMap<Country, CountryDto>();

            CreateMap<Province, ProvinceDto>();
        }
    }
}
