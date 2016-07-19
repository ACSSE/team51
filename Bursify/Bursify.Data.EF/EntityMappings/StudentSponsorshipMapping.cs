using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.EntityMappings
{
    public class StudentSponsorshipMapping : EntityTypeConfiguration<StudentSponsorship>
    {
        public StudentSponsorshipMapping()
        {
            this.ToTable("StudentSponsorship", "dbo");

            this.HasKey(x => new {x.StudentId, x.SponsorshipId});

            this.Property(x => x.StudentId)
                .IsRequired();

            this.Property(x => x.SponsorshipId)
                .IsRequired();

            this.Property(x => x.ApplicationDate)
                .IsRequired();

            this.HasRequired(x => x.Student)
                .WithMany(s => s.StudentSponsorships)
                .HasForeignKey(f => f.StudentId);

            this.HasRequired(x => x.Sponsorship)
                .WithMany(s => s.StudentSponsorships)
                .HasForeignKey(f => f.SponsorshipId);
        }
    }
}
