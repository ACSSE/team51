using Bursify.Data.EF.SponsorUser;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.EF.EntityMappings
{
    public class SponsorMapping : EntityTypeConfiguration<Sponsor>
    {
        public SponsorMapping()
        {
            this.ToTable("Sponsor", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID);

            this.Property(x => x.Type)
                .IsRequired();

            this.Property(x => x.OrganisationSize)
                .IsRequired();

            this.Property(x => x.Website)
                .IsOptional();

            this.Property(x => x.YearFounded)
                .IsRequired();

            this.Property(x => x.Location)
                .IsRequired();

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
