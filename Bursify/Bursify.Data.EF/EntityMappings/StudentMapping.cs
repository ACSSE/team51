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

            this.Property(x => x.InstitutionID).IsRequired();

            this.Property(x => x.IDNumber).IsOptional();

            this.Property(x => x.Surname)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.Headline)
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

            this.Property(x => x.DisabilityDescription).IsOptional();

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

            this.Property(x => x.Essay).IsOptional();

            this.Property(x => x.GuardianPhone).IsOptional();

            this.Property(x => x.GuardianRelationship).IsOptional();

            this.Property(x => x.GuardianEmail).IsOptional();

            this.Property(x => x.IDDocumentPath).IsOptional();

            this.Property(x => x.MatricCertificatePath).IsOptional();

            this.Property(x => x.CVPath).IsOptional();

            this.Property(x => x.AgreeTandC).IsOptional();

            this.HasRequired(x => x.BursifyUser);

            this.HasMany(x => x.StudentReports)
                .WithRequired(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            this.HasRequired(x => x.Institution)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.InstitutionID);

            this.HasMany(x => x.StudentSponsorships);
            
            this.HasMany(x => x.Campaigns);
        }
    }
}
