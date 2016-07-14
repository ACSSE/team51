using Bursify.Entities.UserEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.Configurations
{
    public class UserAddressConfiguration : EntityTypeConfiguration<UserAddress>
    {
        public UserAddressConfiguration()
        {
            ToTable("UserAddress", "dbo");

            HasKey(x => x.AddressId);

            Property(x => x.AddressId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.BursifyUserId)
                .IsRequired();

            Property(x => x.AddressType)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.PreferredAddress)
                .IsRequired();

            Property(x => x.HouseNumber)
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.StreetName)
                .HasMaxLength(200)
                .IsOptional();

            Property(x => x.Suburb)
                .HasMaxLength(200)
                .IsOptional();

            Property(x => x.City)
                .HasMaxLength(200)
                .IsOptional();

            Property(x => x.PostOfficeBoxNumber)
                .IsOptional();

            Property(x => x.PostOfficeName)
                .HasMaxLength(200)
                .IsOptional();

            Property(x => x.PostalCode)
                .HasMaxLength(50)
                .IsRequired();

            HasRequired(x => x.BursifyUser);
        }
    }
}
