using BAE_Brasil.Models;
using Microsoft.EntityFrameworkCore;

namespace BAE_Brasil.DataSource
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> Profiles { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<ProfessionalExperience> ProfessionalExperiences { get; set; }
        public virtual DbSet<ResumeLanguage> ResumeLanguages { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.UserProfile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            modelBuilder.Entity<UserProfile>()
                .HasMany(p => p.Documents)
                .WithOne(p => p.Profile)
                .HasForeignKey(p => p.UserProfileId);

            modelBuilder.Entity<UserProfile>()
                .HasOne(p => p.Address)
                .WithOne(p => p.Profile)
                .HasForeignKey<Address>(p => p.UserProfileId);
            
            modelBuilder.Entity<UserProfile>()
                .HasMany(p => p.Contacts)
                .WithOne(p => p.Profile)
                .HasForeignKey(p => p.UserProfileId);
            
            modelBuilder.Entity<UserProfile>()
                .HasMany(p => p.Documents)
                .WithOne(p => p.Profile)
                .HasForeignKey(p => p.UserProfileId);
            
            modelBuilder.Entity<UserProfile>()
                .HasOne(p => p.Resume)
                .WithOne(p => p.UserProfile)
                .HasForeignKey<Resume>(p => p.UserProfileId);

            modelBuilder.Entity<Resume>()
                .HasMany(p => p.Degrees)
                .WithOne(p => p.Resume)
                .HasForeignKey(p => p.ResumeId);
            
            modelBuilder.Entity<Resume>()
                .HasMany(p => p.ResumeLanguages)
                .WithOne(p => p.Resume)
                .HasForeignKey(p => p.ResumeId);
            
            modelBuilder.Entity<Resume>()
                .HasMany(p => p.ProfessionalExperiences)
                .WithOne(p => p.Resume)
                .HasForeignKey(p => p.ResumeId);

            modelBuilder.Entity<Language>()
                .HasMany(p => p.ResumeLanguages)
                .WithOne(p => p.Language)
                .HasForeignKey(p => p.LanguageId);
        }
    }
}