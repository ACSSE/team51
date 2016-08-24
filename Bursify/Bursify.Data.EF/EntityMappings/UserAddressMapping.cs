using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Data.EF.EntityMappings
{
    public class UserAddressMapping : EntityTypeConfiguration<UserAddress>
    {
        public UserAddressMapping()
        {
            this.ToTable("UserAddress", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.BursifyUserId)
                .IsRequired();

            this.Property(x => x.AddressType)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.PreferredAddress)
                .IsOptional();

            this.Property(x => x.StreetAddress)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.Province)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.City)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.PostOfficeBoxNumber)
                .IsOptional();

            this.Property(x => x.PostalCode)
                .HasMaxLength(50)
                .IsOptional();

            this.HasRequired(x => x.BursifyUser);
        }
    }
}
