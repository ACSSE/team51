using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Entities.Campaigns;

namespace Bursify.Data.EF.EntityMappings
{
    public class CampaignAccountMapping : EntityTypeConfiguration<CampaignAccount>
    {
        public CampaignAccountMapping()
        {
            this.ToTable("CampaignAccount", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID);

            this.Property(x => x.AccountName)
                .HasMaxLength(200)
                .IsRequired();

            this.Property(x => x.AccountNumber)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(x => x.BankName)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(x => x.BranchName)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.BranchCode)
                .HasMaxLength(50)
                .IsOptional();

            this.HasRequired(x => x.Campaign);
        }
    }
}
