using Bursify.Entities.CampaignEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class CampaignConfiguration : EntityTypeConfiguration<Campaign>
    {
        public CampaignConfiguration()
        {
            ToTable("Campaign", "dbo");

            HasKey(x => x.CampaignId);

            Property(x => x.CampaignId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.StudentId)
                .IsRequired();

            Property(x => x.CampaignName)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Tagline)
                .HasMaxLength(200)
                .IsOptional();

            Property(x => x.Location)
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.Description)
                .IsRequired();

            Property(x => x.AmountRequired)
                .IsRequired();

            Property(x => x.CampaignType)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.VideoPath)
                .HasMaxLength(200)
                .IsOptional();

            Property(x => x.PicturePath)
                .HasMaxLength(200)
                .IsOptional();

            Property(x => x.StartDate)
                .IsRequired();

            Property(x => x.EndDate)
                .IsRequired();

            Property(x => x.AmountContributed)
                .IsRequired();

            Property(x => x.FundUsage)
                .IsRequired();

            Property(x => x.ReasonsToSupport)
                .IsOptional();

            HasMany(x => x.CampaignSponsors);

            HasRequired(x => x.Student)
                .WithMany(c => c.Campaigns)
                .HasForeignKey(s => s.StudentId);

            HasRequired(x => x.Account)
                .WithRequiredPrincipal(x => x.Campaign);
        }
    }
}
