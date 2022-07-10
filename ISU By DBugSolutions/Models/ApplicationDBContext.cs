using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISU_By_DBugSolutions.Models;

namespace ISU_By_DBugSolutions.Models
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        private readonly DbContextOptions _options;

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            _options = options;
        }

        public DbSet<Enquiry> Enquiry { get; set; }
        public DbSet<Allergy> Allergy { get; set; }
        public DbSet<Creche> Creche { get; set; }
        public DbSet<Disease> Disease { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<ECDCManager> ECDCManager { get; set; }
        public DbSet<ECDCTeacher> ECDCTeacher { get; set; }
        public DbSet<MedicalHistory> MedicalHistory { get; set; }
        public DbSet<Medication> Medication { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<ProvincialLiason> ProvincialLiason { get; set; }
        public DbSet<Pupil> Pupil { get; set; }
        public DbSet<RegionalCoordinator> RegionalCoordinator { get; set; }
        public DbSet<Surgery> Surgery { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<EatingSchedule> EatingSchedule { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<PictureBook> PictureBooks { get; set; }
        public DbSet<Spreadsheet> Spreadsheets { get; set; }
        public DbSet<MeetingSchedule> MeetingSchedule { get; set; }
        public DbSet<UserActivity> UserActivity { get; set; }
        public DbSet<Message> Messages { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Message>()
                .HasOne<ApplicationUser>(a => a.Sender)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserID);
        }
    }
}
