using Bursify.Data.SponsorUser;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.EF.EntityMappings
{
    public class SponsorMapping : EntityTypeConfiguration<Sponsor>
    {
        public SponsorMapping()
        {
            this.ToTable("Sponsor", "dbo");

            this.HasKey(x => x.SponsorId);

            this.Property(x => x.NumberOfStudentsSponsored);

            this.Property(x => x.NumberOfSponsorships);

            this.Property(x => x.BursifyUserId).IsRequired();
        }
    }
}
