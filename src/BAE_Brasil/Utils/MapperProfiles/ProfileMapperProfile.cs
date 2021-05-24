using System.Collections.Generic;
using AutoMapper;
using BAE_Brasil.Models;
using BAE_Brasil.Models.ViewModels;
using BAE_Brasil.Utils.Enums;

namespace BAE_Brasil.Utils.MapperProfiles
{
    public class ProfileMapperProfile : Profile
    {
        public ProfileMapperProfile()
        {
            CreateMap<UserProfileViewModel, Address>()
                .ForSourceMember(s => s.ProfileData, o => o.DoNotValidate());
            
            CreateMap<CreateProfileViewModel, UserProfile>()
                .ForMember(p => p.Documents, o => o.MapFrom(p => new List<Document>
                {
                    new Document
                    {
                        DocumentType = p.DocumentType,
                        Description = p.DocDescription,
                    }
                }))
                .ForMember(p => p.Contacts, o => o.MapFrom(p => new List<Contact>
                {
                    new Contact
                    {
                        ContactType = ContactType.Telefone,
                        Description = p.TelStateCode.Trim() + p.TelNumber.Trim(),
                    },
                    new Contact
                    {
                        ContactType = ContactType.Celular,
                        Description = p.CellStateCode.Trim() + p.CellNumber.Trim()
                    }
                }));
        }
    }
}