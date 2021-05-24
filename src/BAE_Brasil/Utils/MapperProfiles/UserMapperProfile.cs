using BAE_Brasil.Models;
using BAE_Brasil.Models.ViewModels;
using Profile = AutoMapper.Profile;

namespace BAE_Brasil.Utils.MapperProfiles
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