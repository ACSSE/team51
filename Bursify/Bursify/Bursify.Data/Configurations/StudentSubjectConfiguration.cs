using Bursify.Entities.StudentEntities;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class StudentSubjectConfiguration : EntityTypeConfiguration<StudentSubject>
    {
        public StudentSubjectConfiguration()
        {
            ToTable("StudentSubject", "dbo");

            HasKey(x => new { x.StudentId, x.SubjectId });

            Property(x => x.StudentId)
                .IsRequired();

            Property(x => x.SubjectId)
                .IsRequired();

            Property(x => x.MarkAcquired)
                .IsRequired();

            HasRequired(x => x.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(f => f.StudentId);

            HasRequired(x => x.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(f => f.SubjectId);
        }
    }
}
