using Bursify.Data.EF.Entities.Bridge;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.EF.EntityMappings
{
    public class SponsorStudentNotificationMapping : EntityTypeConfiguration<SponsorStudentNotification>
    {
        public SponsorStudentNotificationMapping()
        {
            this.ToTable("SponsorStudentNotification", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.SponsorId)
                .IsRequired();

            this.Property(x => x.StudentId)
                .IsRequired();

            this.Property(x => x.DateNotified)
            .IsOptional();

            this.Property(x => x.Status)
            .IsOptional();

            this.Property(x => x.Message)
            .IsOptional();

            this.HasRequired(x => x.Sponsor)
            .WithMany(c => c.SponsorStudentNotification)
            .HasForeignKey(f => f.SponsorId);

            this.HasRequired(x => x.Student)
                .WithMany(x => x.SponsorStudentNotification)
                .HasForeignKey(f => f.StudentId);
        }
    }
}
