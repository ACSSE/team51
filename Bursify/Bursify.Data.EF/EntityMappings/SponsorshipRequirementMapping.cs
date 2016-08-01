using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.SponsorUser;

namespace Bursify.Data.EF.EntityMappings
{
    public class SponsorshipRequirementMapping : EntityTypeConfiguration<SponsorshipRequirement>
    {
        public SponsorshipRequirementMapping()
        {
            this.ToTable("SponsorshipRequirement", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.SponsorshipId)
                .IsRequired();

            this.Property(x => x.SubjectId)
                .IsRequired();

            this.Property(x => x.RequiredMark)
                .IsOptional();

            this.HasRequired(x => x.Sponsorship)
                .WithMany(s => s.Requirements)
                .HasForeignKey(f => f.SponsorshipId);

            this.HasRequired(x => x.Subject)
                .WithMany(s => s.Requirements)
                .HasForeignKey(f => f.SubjectId);
        }
    }
}
