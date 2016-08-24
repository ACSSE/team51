using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Data.EF.EntityMappings
{
    public class UserActivityMapping : EntityTypeConfiguration<UserActivity>
    {
        public UserActivityMapping()
        {
            this.ToTable("UserActivity", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.BursifyUserId)
                .IsRequired();

            this.Property(x => x.Type)
                .IsOptional();

            this.Property(x => x.Description)
                .IsOptional();

            this.Property(x => x.TimeStamp)
                .IsOptional();

            this.HasRequired(x => x.BursifyUser);
        }
    }
}
