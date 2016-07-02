using Bursify.Data.CampaignUser;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF.EntityMappings
{
    public class AccountMapping : EntityTypeConfiguration<Account>
    {
        public AccountMapping()
        {
            this.ToTable("Account", "dbo");

            this.HasKey(x => x.CampaignId);

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
            
        }
    }
}
