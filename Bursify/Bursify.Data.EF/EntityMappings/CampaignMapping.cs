using Bursify.Data.CampaignUser;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF.EntityMappings
{
    public class CampaignMapping : EntityTypeConfiguration<Campaign>
    {
        public CampaignMapping()
        {
            this.ToTable("Campaign", "dbo");

            this.HasKey(x => x.CampaignId);

            this.Property(x => x.CampaignName)
                .HasMaxLength(200)
                .IsRequired();

            this.Property(x => x.Tagline)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.Location)
                .HasMaxLength(500)
                .IsRequired();

            this.Property(x => x.Description)
                .IsRequired();

            this.Property(x => x.AmountContributed)
                .IsRequired();

            this.Property(x => x.CampaignType)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(x => x.VideoPath)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.PicturePath)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.Deadline)
                .IsRequired();

            this.Property(x => x.AmountContributed)
                .IsRequired();

            this.Property(x => x.StudentId)
                .IsRequired();
        }
    }
}
