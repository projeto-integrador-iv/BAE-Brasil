using AutoMapper;
using BAE_Brasil.Models;
using BAE_Brasil.Models.ViewModels;

namespace BAE_Brasil.Utils.MapperProfiles
{
    public class ResumeMapperProfile : Profile
    {
        public ResumeMapperProfile()
        {
            CreateMap<CreateResumeViewModel, Resume>();
        }
    }
}