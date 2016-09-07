using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.Entities.Bridge;

namespace Bursify.Data.EF.EntityMappings
{
    public class CampaignSponsorMapping : EntityTypeConfiguration<CampaignSponsor>
    {
        public CampaignSponsorMapping()
        {
            this.ToTable("CampaignSponsor", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.CampaignId)
                .IsRequired();

            this.Property(x => x.SponsorId)
                .IsRequired();

            this.Property(x => x.AmountContributed)
                .IsOptional();

            this.Property(x => x.DateOfContribution)
                .IsOptional();

            this.HasRequired(x => x.Campaign)
                .WithMany(c => c.CampaignSponsors)
                .HasForeignKey(f => f.CampaignId);

            this.HasRequired(x => x.Sponsor)
                .WithMany(x => x.CampaignSponsors)
                .HasForeignKey(f => f.SponsorId);
        }
    }
}
