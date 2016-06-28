using System.Data.Entity.ModelConfiguration;
using Bursify.Data.User;

namespace Bursify.Data.EntityMappings
{
    public class BursifyUserMapping : EntityTypeConfiguration<BursifyUser>
    {
        public BursifyUserMapping()
        {
            this.ToTable("BursifyUser", "dbo");

            this.HasKey(x => x.BursifyUserId);

            this.Property(x => x.Name)
                .HasMaxLength(100);
        }                                     
    }
}