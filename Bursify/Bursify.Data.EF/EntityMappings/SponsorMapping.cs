using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Data.EF.EntityMappings
{
    public class SponsorMapping : EntityTypeConfiguration<Sponsor>
    {
        public SponsorMapping()
        {
            this.ToTable("Sponsor", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID);

            this.Property(x => x.CompanyName).IsOptional();

            this.Property(x => x.Industry)
                .IsOptional();

            this.Property(x => x.Website)
                .IsOptional();

            this.Property(x => x.Location)
                .IsOptional();

            this.Property(x => x.CompanyEmail)
            .IsOptional();

            this.Property(x => x.NumberOfStudentsSponsored)
                .IsOptional();

            this.Property(x => x.NumberOfSponsorships)
                .IsOptional();

            this.Property(x => x.NumberOfApplicants)
                .IsOptional();

            this.Property(x => x.BursifyRank)
                .IsOptional();

            this.Property(x => x.BursifyScore)
                .IsOptional();

            this.HasMany(x => x.Sponsorhips);

            this.HasMany(x => x.CampaignSponsors);

            this.HasRequired(x => x.BursifyUser);
        }
    }
}
