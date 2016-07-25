using Bursify.Data.EF.SponsorUser;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.EF.EntityMappings
{
    public class SponsorMapping : EntityTypeConfiguration<Sponsor>
    {
        public SponsorMapping()
        {
            this.ToTable("Sponsor", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.NumberOfStudentsSponsored);

            this.Property(x => x.NumberOfSponsorships);

            this.Property(x => x.NumberOfApplicants);

            this.Property(x => x.BursifyRank)
                .IsOptional();

            this.Property(x => x.BursifyScore)
                .IsOptional();

            this.HasMany(x => x.Sponsorhips);

            this.HasMany(x => x.CampaignSponsors);

            this.HasRequired(x => x.BursifyUser);
        }
    }
}
