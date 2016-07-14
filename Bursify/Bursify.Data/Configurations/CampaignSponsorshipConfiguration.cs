using Bursify.Entities.UserEntities;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class CampaignSponsorConfiguration : EntityTypeConfiguration<CampaignSponsor>
    {
        public CampaignSponsorConfiguration()
        {
            ToTable("CampaignSponsor", "dbo");

            HasKey(x => new { x.CampaignId, x.SponsorId });

            Property(x => x.CampaignId)
                .IsRequired();

            Property(x => x.SponsorId)
                .IsRequired();

            Property(x => x.AmountContributed)
                .IsRequired();

            Property(x => x.DateOfContribution)
                .IsRequired();

            HasRequired(x => x.Campaign)
                .WithMany(c => c.CampaignSponsors)
                .HasForeignKey(f => f.CampaignId);

            HasRequired(x => x.Sponsor)
                .WithMany(x => x.CampaignSponsors)
                .HasForeignKey(f => f.SponsorId);
        }
    }
}
