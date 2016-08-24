using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Data.EF.EntityMappings
{
    public class RequirementMapping : EntityTypeConfiguration<Requirement>
    {
        public RequirementMapping()
        {
            this.ToTable("Requirement", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.SponsorshipId)
                .IsRequired();

            this.Property(x => x.Name)
                .IsOptional();

            this.Property(x => x.MarkRequired)
                .IsOptional();

            this.HasRequired(x => x.Sponsorship);
        }
    }
}
