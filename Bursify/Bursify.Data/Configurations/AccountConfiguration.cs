using Bursify.Entities.CampaignEntities;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            ToTable("Account", "dbo");

            HasKey(x => x.CampaignId);

            Property(x => x.AccountName)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.AccountNumber)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.BankName)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.BranchName)
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.BranchCode)
                .HasMaxLength(50)
                .IsOptional();

            HasRequired(x => x.Campaign)
                .WithRequiredDependent(a => a.Account);

        }
    }
}
