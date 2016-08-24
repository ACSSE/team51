using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.Entities.User;


namespace Bursify.Data.EF.EntityMappings
{                        
    public class BursifyUserMapping : EntityTypeConfiguration<BursifyUser>
    {
        public BursifyUserMapping()
        {
            this.ToTable("BursifyUser", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Email)
                .HasMaxLength(100)
                .IsOptional();

            this.Property(x => x.PasswordHash)
                .IsOptional();

            this.Property(x => x.PasswordSalt)
                .IsOptional();

            this.Property(x => x.AccountStatus)
                .IsOptional();

            this.Property(x => x.UserType)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.RegistrationDate)
                .IsOptional();

            this.Property(x => x.Biography)
                .IsOptional();

            this.Property(x => x.CellphoneNumber)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.TelephoneNumber)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.ProfilePicturePath)
                .HasMaxLength(200)
                .IsOptional();

            this.HasMany(x => x.Addresses);

            this.HasMany(x => x.Activities);

            this.HasOptional(x => x.Student);

            this.HasOptional(x => x.Sponsor);

            this.HasOptional(x => x.Account);
        }                                     
    }
}