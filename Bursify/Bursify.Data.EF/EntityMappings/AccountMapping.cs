using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.Entities.Campaigns;

namespace Bursify.Data.EF.EntityMappings
{
    public class AccountMapping : EntityTypeConfiguration<Account>
    {
        public AccountMapping()
        {
            this.ToTable("Account", "dbo");

            this.HasKey(x => x.ID);
            
            this.Property(x => x.AccountName)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.AccountNumber)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.BankName)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.BranchName)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.BranchCode)
                .HasMaxLength(50)
                .IsOptional();

            this.HasRequired(x => x.Campaign)
                .WithRequiredDependent(a => a.Account);

        }
    }
}
