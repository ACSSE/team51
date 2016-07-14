using Bursify.Entities.UserEntities;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class InstitutionConfiguration : EntityTypeConfiguration<Institution>
    {
        public InstitutionConfiguration()
        {
            ToTable("Institution", "dbo");

           HasKey(x => x.StudentId);

            Property(x => x.StudentId)
                .IsRequired();

           Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();

           Property(x => x.Type)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Website)
                .HasMaxLength(500)
                .IsOptional();

            HasRequired(x => x.Student);
        }
    }
}
