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
    public class NotificationMapping : EntityTypeConfiguration<Notification>
    {
        public NotificationMapping()
        {
            this.ToTable("Notification", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.BursifyUserId)
                .IsRequired();

            this.Property(x => x.TimeStamp).IsOptional();

            this.Property(x => x.Action).HasMaxLength(20).IsOptional();

            this.Property(x => x.ActionId).IsOptional();

            this.Property(x => x.Message).HasMaxLength(100).IsOptional();

            this.Property(x => x.Sender).HasMaxLength(50).IsOptional();

            this.Property(x => x.ReadStatus).IsOptional();

            this.HasRequired(x => x.User);
        }
    }
}
