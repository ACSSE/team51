using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.StudentUser;

namespace Bursify.Data.EF.EntityMappings
{
    public class StudentSubjectMapping : EntityTypeConfiguration<StudentSubject>
    {
        public StudentSubjectMapping()
        {
            this.ToTable("StudentSubject", "dbo");

            this.HasKey(x => new { x.StudentId, x.SubjectId });

            this.Property(x => x.StudentId)
                .IsRequired();

            this.Property(x => x.SubjectId)
                .IsRequired();

            this.Property(x => x.MarkAcquired)
                .IsRequired();

            this.HasRequired(x => x.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(f => f.StudentId);

            this.HasRequired(x => x.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(f => f.SubjectId);
        }
    }
}
