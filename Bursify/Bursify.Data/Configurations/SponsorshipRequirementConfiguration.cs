using Bursify.Entities.SponsorEntities;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class SponsorshipRequirementConfiguration : EntityTypeConfiguration<SponsorshipRequirement>
    {
        public SponsorshipRequirementConfiguration()
        {
            ToTable("SponsorshipRequirement", "dbo");

            HasKey(x => new { x.SponsorshipId, x.SubjectId });

            Property(x => x.SponsorshipId)
                .IsRequired();

            Property(x => x.SubjectId)
                .IsRequired();

            Property(x => x.RequiredMark)
                .IsOptional();

            HasRequired(x => x.Sponsorship)
                .WithMany(s => s.Requirements)
                .HasForeignKey(f => f.SponsorshipId);

            HasRequired(x => x.Subject)
                .WithMany(s => s.Requirements)
                .HasForeignKey(f => f.SubjectId);
        }
    }
}
