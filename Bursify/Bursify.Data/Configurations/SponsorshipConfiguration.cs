using Bursify.Entities.SponsorEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class SponsorshipConfiguration : EntityTypeConfiguration<Sponsorship>
    {
        public SponsorshipConfiguration()
        {
            ToTable("Sponsorship", "dbo");

            HasKey(x => x.SponsorshipId);

            Property(x => x.SponsorshipId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.SponsorId)
               .IsRequired();

            Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.Description)
                .IsRequired();

            Property(x => x.ClosingDate)
                .IsRequired();

            Property(x => x.EssayRequired)
                .IsRequired();

            Property(x => x.SponsorshipValue)
                .IsRequired();

            Property(x => x.StudyFields)
                .IsRequired();

            Property(x => x.Province)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.AverageMarkRequired)
                .IsOptional();

            Property(x => x.EducationLevel)
                .HasMaxLength(200)
                .IsOptional();

            Property(x => x.PreferredInstitutions)
                .HasMaxLength(500)
                .IsOptional();

            Property(x => x.ExpensesCovered)
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.TermsAndConditions)
                .IsRequired();

            HasRequired(x => x.Sponsor)
                .WithMany(s => s.Sponsorhips)
                .HasForeignKey(f => f.SponsorId);

            HasMany(x => x.StudentSponsorships);

            HasMany(x => x.Requirements);
        }
    }
}
