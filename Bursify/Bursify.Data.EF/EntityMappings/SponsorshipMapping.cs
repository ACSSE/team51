using Bursify.Data.SponsorUser;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF.EntityMappings
{
    public class SponsorshipMapping : EntityTypeConfiguration<Sponsorship>
    {
        public SponsorshipMapping()
        {
            this.ToTable("Sponsorship", "dbo");

            this.HasKey(x => x.SponsorshipId);

            this.Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();

            this.Property(x => x.Description)
                .IsRequired();

            this.Property(x => x.ClosingDate)
                .IsRequired();

            this.Property(x => x.EssayRequired)
                .IsRequired();

            this.Property(x => x.StudyFields)
                .HasMaxLength(500)
                .IsRequired();

            this.Property(x => x.Province)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(x => x.AverageMarkRequired)
                .IsOptional();

            this.Property(x => x.SponsorId)
                .IsRequired();
        }
    }
}
