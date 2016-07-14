using Bursify.Data.Configurations;
using Bursify.Entities;
using Bursify.Entities.CampaignEntities;
using Bursify.Entities.SponsorEntities;
using Bursify.Entities.StudentEntities;
using Bursify.Entities.UserEntities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Bursify.Data
{
    public class BursifyContext : DbContext
    {
        public BursifyContext() : base("BursifyDB")
        {
            Database.SetInitializer<BursifyContext>(null);
        }

        public IDbSet<BursifyUser> BursifyUserSet { get; set; }
        public IDbSet<Account> AccountSet { get; set; }
        public IDbSet<Campaign> CampaignSet { get; set; }
        public IDbSet<CampaignSponsor> CampaignSponsorSet { get; set; }
        public IDbSet<Institution> InstituitionSet { get; set; }
        public IDbSet<Sponsor> SponsorSet { get; set; }
        public IDbSet<Sponsorship> SponsorshipSet { get; set; }
        public IDbSet<SponsorshipRequirement> SponsorshipRequirementSet { get; set; }
        public IDbSet<Student> StudentSet { get; set; }
        public IDbSet<StudentSponsorship> StudentSponsorshipSet{ get; set; }
        public IDbSet<StudentSubject> StudentSubjectSet { get; set; }
        public IDbSet<Subject> SubjectSet { get; set; }
        public IDbSet<UserAddress> UserAddressSet { get; set; }



        public IDbSet<Error> ErrorSet { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new BursifyUserConfiguration());
            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new CampaignConfiguration());
            modelBuilder.Configurations.Add(new CampaignSponsorConfiguration());
            modelBuilder.Configurations.Add(new InstitutionConfiguration());
            modelBuilder.Configurations.Add(new SponsorConfiguration());
            modelBuilder.Configurations.Add(new SponsorshipConfiguration());
            modelBuilder.Configurations.Add(new SponsorshipRequirementConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new StudentSponsorshipConfiguration());
;     
            modelBuilder.Configurations.Add(new StudentSubjectConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new UserAddressConfiguration());


        }
    }
}
