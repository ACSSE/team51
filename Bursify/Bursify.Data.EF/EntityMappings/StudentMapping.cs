using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.Entities.StudentUser;

namespace Bursify.Data.EF.EntityMappings
{
    public class StudentMapping : EntityTypeConfiguration<Student>
    {
        public StudentMapping()
        {
            this.ToTable("Student", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID);

            this.Property(x => x.Surname)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(X => X.EducationLevel)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.AverageMark)
                .IsOptional();

            this.Property(x => x.StudentNumber)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.Age)
                .IsOptional();

            this.Property(x => x.HasDisability)
                .IsOptional();

            this.Property(x => x.Race)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.Gender)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.CurrentOccupation)
                .HasMaxLength(100)
                .IsOptional();

            this.Property(x => x.StudyField)
                .IsOptional();

            this.Property(x => x.HighestAcademicAchievement)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.YearOfAcademicAchievement)
                .IsOptional();

            this.Property(x => x.DateOfBirth)
                .IsOptional();

            this.Property(x => x.NumberOfViews)
                .IsOptional();

            this.HasRequired(x => x.BursifyUser);

            this.HasOptional(x => x.Institution);

            this.HasMany(x => x.StudentSubjects);

            this.HasMany(x => x.StudentSponsorships);
            
            this.HasMany(x => x.Campaigns);
        }
    }
}
