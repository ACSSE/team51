using Bursify.Entities.SponsorEntities;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class SponsorConfiguration : EntityTypeConfiguration<Sponsor>
    {
        public SponsorConfiguration()
        {
            ToTable("Sponsor", "dbo");

            HasKey(x => x.BursifyUserId);

            Property(x => x.NumberOfStudentsSponsored);

            Property(x => x.NumberOfSponsorships);

            Property(x => x.NumberOfApplicants);

            Property(x => x.BursifyRank)
                .IsOptional();

            Property(x => x.BursifyScore)
                .IsOptional();

            HasMany(x => x.Sponsorhips);

            HasMany(x => x.CampaignSponsors);

            HasRequired(x => x.BursifyUser);
        }
    }
}
