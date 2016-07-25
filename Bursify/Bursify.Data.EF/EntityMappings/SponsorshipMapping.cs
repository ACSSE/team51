﻿using System.ComponentModel.DataAnnotations.Schema;
using Bursify.Data.EF.SponsorUser;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.EF.EntityMappings
{
    public class SponsorshipMapping : EntityTypeConfiguration<Sponsorship>
    {
        public SponsorshipMapping()
        {
            this.ToTable("Sponsorship", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.SponsorId)
               .IsRequired();

            this.Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();

            this.Property(x => x.SponsorshipType)
                .IsRequired();

            this.Property(x => x.Description)
                .IsRequired();

            this.Property(x => x.ClosingDate)
                .IsRequired();

            this.Property(x => x.EssayRequired)
                .IsRequired();

            this.Property(x => x.SponsorshipValue)
                .IsRequired();

            this.Property(x => x.StudyFields)
                .IsRequired();

            this.Property(x => x.Province)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(x => x.AverageMarkRequired)
                .IsOptional();

            this.Property(x => x.EducationLevel)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.PreferredInstitutions)
                .HasMaxLength(500)
                .IsOptional();

            this.Property(x => x.ExpensesCovered)
                .HasMaxLength(500)
                .IsRequired();

            this.Property(x => x.TermsAndConditions)
                .IsRequired();

            this.Property(x => x.NumberOfViews)
                .IsOptional();

            this.HasRequired(x => x.Sponsor)
                .WithMany(s => s.Sponsorhips)
                .HasForeignKey(f => f.SponsorId);

            this.HasMany(x => x.StudentSponsorships);

            this.HasMany(x => x.Requirements);
        }
    }
}
