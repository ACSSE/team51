using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.EntityMappings
{
    public class CampaignSponsorMapping : EntityTypeConfiguration<CampaignSponsor>
    {
        public CampaignSponsorMapping()
        {
            this.ToTable("CampaignSponsor", "dbo");

            this.HasKey(x => new {x.CampaignId, x.SponsorId});

            this.Property(x => x.CampaignId)
                .IsRequired();

            this.Property(x => x.SponsorId)
                .IsRequired();

            this.Property(x => x.AmountContributed)
                .IsRequired();

            this.Property(x => x.DateOfContribution)
                .IsRequired();

            this.HasRequired(x => x.Campaign)
                .WithMany(c => c.CampaignSponsors)
                .HasForeignKey(f => f.CampaignId);

            this.HasRequired(x => x.Sponsor)
                .WithMany(x => x.CampaignSponsors)
                .HasForeignKey(f => f.SponsorId);
        }
    }
}
