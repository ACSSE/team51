using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.EntityMappings
{
    public class StudentSponsorshipMapping : EntityTypeConfiguration<StudentSponsorship>
    {
        public StudentSponsorshipMapping()
        {
            this.ToTable("StudentSponsorship", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.StudentId)
                .IsRequired();

            this.Property(x => x.SponsorshipId)
                .IsRequired();

            this.Property(x => x.ApplicationDate)
                .IsRequired();

            this.Property(x => x.IsSponsorshipOfferd)
                .IsRequired();

            this.Property(x => x.SponsorshipConfirmed)
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
