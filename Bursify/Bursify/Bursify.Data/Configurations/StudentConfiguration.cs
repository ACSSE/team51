using Bursify.Entities.StudentEntities;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            ToTable("Student", "dbo");

            HasKey(x => x.BursifyUserId);

            Property(x => x.BursifyUserId)
                .HasDatabaseGeneratedOption(0);

            Property(x => x.Surname)
                .HasMaxLength(200)
                .IsOptional();

            Property(X => X.EducationLevel)
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.AverageMark)
                .IsOptional();

            Property(x => x.StudentNumber)
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.Age)
                .IsOptional();

            Property(x => x.HasDisability)
                .IsOptional();

            Property(x => x.Race)
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.Gender)
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.CurrentOccupation)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.HighestAcademicAchievement)
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.YearOfAcademicAchievement)
                .IsOptional();

            Property(x => x.DateOfBirth)
                .IsOptional();

            HasRequired(x => x.BursifyUser);

            HasOptional(x => x.Institution);

            HasMany(x => x.StudentSubjects);

            HasMany(x => x.StudentSponsorships);

            HasMany(x => x.Campaigns);

        }
    }
}
