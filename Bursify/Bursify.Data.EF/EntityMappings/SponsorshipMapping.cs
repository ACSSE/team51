using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Data.EF.EntityMappings
{
    public class SponsorshipMapping : EntityTypeConfiguration<Sponsorship>
    {
        public SponsorshipMapping()
        {
            this.ToTable("Sponsorship", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.SponsorId)
               .IsRequired();

            this.Property(x => x.Name)
                .HasMaxLength(500)
                .IsOptional();

            this.Property(x => x.SponsorshipType)
                .IsOptional();

            this.Property(x => x.Description)
                .IsOptional();

            this.Property(x => x.ClosingDate)
                .IsOptional();

            this.Property(x => x.EssayRequired)
                .IsOptional();

            this.Property(x => x.SponsorshipValue)
                .IsOptional();

            this.Property(x => x.StudyFields)
                .IsOptional();

            this.Property(x => x.Province)
                .HasMaxLength(100)
                .IsOptional();

            this.Property(x => x.AverageMarkRequired)
                .IsOptional();

            this.Property(x => x.EducationLevel)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.PreferredInstitutions)
                .HasMaxLength(500)
                .IsOptional();

            this.Property(x => x.ExpensesCovered)
                .HasMaxLength(500)
                .IsOptional();

            this.Property(x => x.TermsAndConditions)
                .IsOptional();

            this.Property(x => x.NumberOfViews)
                .IsOptional();

            this.Property(x => x.AgeGroup).IsOptional();

            this.Property(x => x.Rating).IsOptional();

            this.HasRequired(x => x.Sponsor)
                .WithMany(s => s.Sponsorhips)
                .HasForeignKey(f => f.SponsorId);

            this.HasMany(x => x.StudentSponsorships);

            this.HasMany(x => x.Requirements);

        }
    }
}
