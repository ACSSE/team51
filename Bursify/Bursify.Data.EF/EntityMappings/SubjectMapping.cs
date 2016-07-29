using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bursify.Data.User;

namespace Bursify.Data.EF.EntityMappings
{
    public class SubjectMapping : EntityTypeConfiguration<Subject>
    {
        public SubjectMapping()
        {
            this.ToTable("Subject", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            this.Property(x => x.SubjectLevel)
                .IsRequired();

            this.HasMany(x => x.StudentSubjects);

            this.HasMany(x => x.Requirements);
        }
    }
}
