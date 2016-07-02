using Bursify.Data.User;
using System.Data.Entity.ModelConfiguration;


namespace Bursify.Data.EF.EntityMappings
{                        
    public class BursifyUserMapping : EntityTypeConfiguration<BursifyUser>
    {
        public BursifyUserMapping()
        {
            this.ToTable("BursifyUser", "dbo");

            this.HasKey(x => x.BursifyUserId);

            this.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(x => x.PasswordHash)
                .IsRequired();

            this.Property(x => x.PasswordSalt)
                .IsRequired();

            this.Property(x => x.AccountStatus)
                .IsRequired();

            this.Property(x => x.UserType)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(x => x.RegistrationDate)
                .IsRequired();

            this.Property(x => x.Biography)
                .IsOptional();
           
        }                                     
    }
}