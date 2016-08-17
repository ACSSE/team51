using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.Entities.Bridge;

namespace Bursify.Data.EF.EntityMappings
{
    public class CampaignReportMapping : EntityTypeConfiguration<CampaignReport>
    {
        public CampaignReportMapping()
        {
            this.ToTable("CampaignReport", "dbo");

            this.HasKey(x => new {x.CampaignId, x.BursifyUserId});

            this.Property(x => x.CampaignId).IsRequired();

            this.Property(x => x.BursifyUserId).IsRequired();

            this.Property(x => x.Reason).IsOptional();

            this.HasRequired(x => x.Campaign)
                .WithMany(c => c.CampaignReports)
                .HasForeignKey(f => f.CampaignId);

            this.HasRequired(x => x.BursifyUser).WithMany(c => c.CampaignReports).HasForeignKey(f => f.BursifyUserId);
        }
    }
}
