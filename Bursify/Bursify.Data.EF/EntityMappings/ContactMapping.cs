using Bursify.Data.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bursify.Data.EF.EntityMappings
{
    public class ContactMapping : EntityTypeConfiguration<Contact>
    {
        public ContactMapping()
        {   
            this.ToTable("Contact", "dbo");

            this.HasKey(x => x.ContactId);

            this.Property(x => x.CellphoneNumber)
                .HasMaxLength(10)
                .IsRequired();

            this.Property(x => x.TelephoneNumber)
                .IsOptional();

            this.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(x => x.PhysicalAddress)
                .HasMaxLength(200)
                .IsRequired();

            this.Property(x => x.PostalAddress)
                .HasMaxLength(200)
                .IsOptional();

            this.Property(x => x.BursifyUserId).IsRequired();
        }
    }
}