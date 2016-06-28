using Bursify.Data.EF;

namespace Bursify.Data.User
{
    public class BursifyUser : IEntity
    {
        public int BursifyUserId { get; set; }
        public string Name { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public bool AccountStatus { get; set; }
        //public UserType UserType { get; set; }
        //public DateTime RegistrationDate { get; set; }
        //public string Biography { get; set; }
        //[Key, ForeignKey("ContactInfo")]
        //public int ContactId { get; set; }
        //[Key, ForeignKey("Sponsor")]
        //public int SponsorId { get; set; }
        //[Key, ForeignKey("Student")]
        //public int StudentId { get; set; }

        //public virtual Contact ContactInfo { get; set; }
        //public virtual Sponsor Sponsor { get; set; }
        //public virtual Student Student { get; set; }

        public int Id
        {
            get { return BursifyUserId; }
        }
    }
}