using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.EntityMappings
{
    public class SponsorshipRequirementMapping : EntityTypeConfiguration<SponsorshipRequirement>
    {
        public SponsorshipRequirementMapping()
        {
            this.ToTable("SponsorshipRequirement", "dbo");

            this.HasKey(x => new {x.SponsorshipId, x.SubjectId});

            this.Property(x => x.SponsorshipId)
                .IsRequired();

            this.Property(x => x.SubjectId)
                .IsRequired();

            this.Property(x => x.RequiredMark)
                .IsOptional();

            this.HasRequired(x => x.Sponsorship)
                .WithMany(s => s.Requirements)
                .HasForeignKey(f => f.SponsorshipId);

            this.HasRequired(x => x.Subject)
                .WithMany(s => s.Requirements)
                .HasForeignKey(f => f.SubjectId);
        }
    }
}
