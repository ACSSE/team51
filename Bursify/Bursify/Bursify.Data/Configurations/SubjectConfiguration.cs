using Bursify.Entities.StudentEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration()
        {
            ToTable("Subject", "dbo");

            HasKey(x => x.SubjectId);

            Property(x => x.SubjectId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            HasMany(x => x.StudentSubjects);

            HasMany(x => x.Requirements);
        }
    }
}
