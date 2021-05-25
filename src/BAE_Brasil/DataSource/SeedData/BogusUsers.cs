using System;
using System.Collections.Generic;
using BAE_Brasil.Models;
using BAE_Brasil.Utils.Enums;
using BAE_Brasil.Views.AttributesCollections;
using Bogus;
using Bogus.Extensions.Brazil;
using System.Globalization;
using System.Linq;

namespace BAE_Brasil.DataSource.SeedData
{
    public class BogusUsers
    {
        public static List<User> CreateBogusUsers(int nUsers)
        {

            var testLangs = new Faker<Language>()
                .RuleFor(p => p.LanguageId, f => Guid.NewGuid())
                .RuleFor(p => p.Name, f => f.PickRandomParam(AttributesCollections.Languages))
                .RuleFor(p => p.Proficiency, f => f.PickRandom<Proficiency>());

            var testResumeLangs = new Faker<ResumeLanguage>()
                .RuleFor(p => p.ResumeLanguageId, f => Guid.NewGuid())
                .RuleFor(p => p.Language, testLangs.Generate());
            
            var testProfessionalExps = new Faker<ProfessionalExperience>()
                .RuleFor(p => p.ProfessionalExperienceId, f => Guid.NewGuid())
                .RuleFor(p => p.Job, f => f.Lorem.Sentence(wordCount: 3))
                .RuleFor(p => p.Description, f => f.Lorem.Sentence(3, 10))
                .RuleFor(p => p.CompanyName, f => f.Company.CompanyName())
                .RuleFor(p => p.StartedAt, f => f.Date.Between(new DateTime(2007, 1, 1), new DateTime(2014, 1, 1)))
                .RuleFor(p => p.EndedAt, f => f.Date.Between(new DateTime(2014, 1, 1), new DateTime(2020, 1, 1)));
                
            var testDegrees = new Faker<Degree>()
                .RuleFor(p => p.DegreeId, f => Guid.NewGuid())
                .RuleFor(p => p.Level, f => f.PickRandomParam(AttributesCollections.DegreeLevels))
                .RuleFor(p => p.Institution, f => "Instituto " + f.Person.Company.Name)
                .RuleFor(p => p.Subject, f => f.PickRandomParam(AttributesCollections.Subjects))
                .RuleFor(p => p.StartedAt, f => f.Date.Between(new DateTime(2000, 1, 1), new DateTime(2010, 1, 1)))
                .RuleFor(p => p.EndedAt, f => f.Date.Between(new DateTime(2011, 1, 1), DateTime.Now.AddMonths(-10)));
                
            var testResume = new Faker<Resume>()
                .RuleFor(p => p.ResumeId, f => Guid.NewGuid())
                .RuleFor(p => p.Goal, f => f.Lorem.Sentence())
                .RuleFor(p => p.Degrees, f => testDegrees.Generate(1).ToList())
                .RuleFor(p => p.Nationality, p => p.PickRandomParam(AttributesCollections.Nationalities))
                .RuleFor(p => p.ProfessionalExperiences, f => testProfessionalExps.Generate(new Random().Next(2, 3)).ToList())
                .RuleFor(p => p.ResumeLanguages, f => testResumeLangs.Generate(new Random().Next(2, 4)).ToList());

            var testDocs = new Faker<Document>("pt_BR")
                .RuleFor(p => p.DocumentId, f => Guid.NewGuid())
                .RuleFor(p => p.Description, f => f.Person.Cpf())
                .RuleFor(p => p.DocumentType, f => f.PickRandomParam(DocumentType.Passaporte, DocumentType.RG));

            var testContacts = new Faker<Contact>("pt_BR")
                .RuleFor(p => p.ContactId, f => Guid.NewGuid())
                .RuleFor(p => p.Description, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.ContactType, f => f.PickRandomParam(ContactType.Celular, ContactType.Telefone));
            
            var testAddresses = new Faker<Address>("pt_BR")
                .RuleFor(p => p.AddressId, f => Guid.NewGuid())
                .RuleFor(p => p.Street, f => f.Address.StreetName())
                .RuleFor(p => p.City, f => f.Address.City())
                .RuleFor(p => p.Bairro, f => "Nova Granada")
                .RuleFor(p => p.Cep, f => f.Address.ZipCode("########"))
                .RuleFor(p => p.Number, f => f.Address.BuildingNumber())
                .RuleFor(p => p.Complement, f => f.Random.Number(100, 1000).ToString())
                .RuleFor(p => p.State, f => f.Address.StateAbbr());

            var testProfiles = new Faker<UserProfile>("pt_BR")
                .RuleFor(p => p.UserProfileId, f => Guid.NewGuid())
                .RuleFor(p => p.BirthDate, (faker) => faker.Date.Between(new DateTime(1960, 1, 1), new DateTime(1990, 1, 1)))
                .RuleFor(p => p.FullName, (faker) => faker.Name.FullName())
                .RuleFor(p => p.Contacts, f => testContacts.Generate(2).ToList())
                .RuleFor(p => p.Address, f => testAddresses.Generate())
                .RuleFor(p => p.Documents, f => testDocs.Generate(1).ToList())
                .RuleFor(p => p.Resume, f => testResume.Generate());
        
            var testUsers = new Faker<User>("pt_BR")
                .RuleFor(p => p.UserId, f => Guid.NewGuid())
                .RuleFor(p => p.Email, (faker, user) => faker.Internet.Email().ToLower())
                .RuleFor(p => p.Password, f => BCrypt.Net.BCrypt.HashPassword("123456789"))
                .RuleFor(p => p.UserType, f => UserType.Candidato)
                .RuleFor(p => p.UserProfile, f => testProfiles.Generate())
                .FinishWith((f, u) =>
                {
                    Console.WriteLine($"User Created: Id: {u.UserId}, Profile: {u.UserProfile.UserProfileId}");
                })
                .Generate(nUsers);
            return testUsers;
        }
    }
}