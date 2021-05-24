using BAE_Brasil.Identity.Models;
using BAE_Brasil.Identity.Models.ViewModels;
using Profile = AutoMapper.Profile;

namespace BAE_Brasil.Identity.Utils.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<CreateUserViewModel, User>()
                .ForMember(d => d.Password, s => s.MapFrom(sp => BCrypt.Net.BCrypt.HashPassword(sp.Password)));
        }
    }
}