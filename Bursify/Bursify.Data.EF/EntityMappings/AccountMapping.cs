using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.User;

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

            this.Property(x => x.CardNumber)
                .IsOptional();

            this.Property(x => x.ExpirationYear)
                .IsOptional();

            this.Property(x => x.ExpirationMonth)
                .IsOptional();

            this.Property(x => x.CvvNumber)
                .IsOptional();

            this.HasRequired(x => x.BursifyUser);
        }
    }
}
