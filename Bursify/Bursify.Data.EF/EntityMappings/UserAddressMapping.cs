using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.EntityMappings
{
    public class UserAddressMapping : EntityTypeConfiguration<UserAddress>
    {
        public UserAddressMapping()
        {
            this.ToTable("UserAddress", "dbo");

            this.HasKey(x => x.AddressId);

            this.Property(x => x.AddressId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.BursifyUserId)
                .IsRequired();

            this.Property(x => x.AddressType)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(x => x.PreferredAddress)
                .IsRequired();

            this.Property(x => x.HouseNumber)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(x => x.StreetName)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.Suburb)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.City)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.PostOfficeBoxNumber)
                .IsOptional();

            this.Property(x => x.PostOfficeName)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.PostalCode)
                .HasMaxLength(50)
                .IsRequired();

            this.HasRequired(x => x.BursifyUser);
        }
    }
}
