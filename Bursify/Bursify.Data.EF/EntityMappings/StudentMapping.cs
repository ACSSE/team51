using Bursify.Data.StudentUser;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.EF.EntityMappings
{
    public class StudentMapping : EntityTypeConfiguration<Student>
    {
        public StudentMapping()
        {
            this.ToTable("Student", "dbo");

            this.HasKey(x => x.StudentId);

            this.Property(x => x.EducationLevel)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(x => x.AverageMark)
                .IsRequired();

            this.Property(x => x.ProfilePicturePath)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.BursifyUserId)
                .IsRequired();
        }
    }
}
