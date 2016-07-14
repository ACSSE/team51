using Bursify.Entities.UserEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class BursifyUserConfiguration : EntityTypeConfiguration<BursifyUser>
    {
        public BursifyUserConfiguration()
        {
            ToTable("BursifyUser", "dbo");

            HasKey(x => x.BursifyUserId);

            Property(x => x.BursifyUserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.PasswordHash)
                .IsRequired();

            Property(x => x.PasswordSalt)
                .IsRequired();

            Property(x => x.AccountStatus)
                .IsRequired();

            Property(x => x.UserType)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.RegistrationDate)
                .IsRequired();

            Property(x => x.Biography)
                .IsOptional();

            Property(x => x.CellphoneNumber)
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.TelephoneNumber)
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.ProfilePicturePath)
                .HasMaxLength(200)
                .IsOptional();

            HasMany(x => x.Addresses);

            HasOptional(x => x.Student);

            HasOptional(x => x.Sponsor);
        }
    }
}
