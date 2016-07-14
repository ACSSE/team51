using Bursify.Entities.StudentEntities;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class StudentSponsorshipConfiguration : EntityTypeConfiguration<StudentSponsorship>
    {
        public StudentSponsorshipConfiguration()
        {
            ToTable("StudentSponsorship", "dbo");


            HasKey(x => new { x.StudentId, x.SponsorshipId });

            Property(x => x.StudentId)
                .IsRequired();

            Property(x => x.SponsorshipId)
                .IsRequired();

            Property(x => x.ApplicationDate)
                .IsRequired();

            HasRequired(x => x.Student)
                .WithMany(s => s.StudentSponsorships)
                .HasForeignKey(f => f.StudentId);

            HasRequired(x => x.Sponsorship)
                .WithMany(s => s.StudentSponsorships)
                .HasForeignKey(f => f.SponsorshipId);
        }
    }
}
