using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.CampaignUser;

namespace Bursify.Data.EF.EntityMappings
{
    public class CampaignReportMapping : EntityTypeConfiguration<CampaignReport>
    {
        public CampaignReportMapping()
        {
            ToTable("CampaignReport", "dbo");

            HasKey(x => new { x.CampaignId, x.BursifyUserId });


        }
    }
}
