using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Data.EF.Entities.User
{
    public class Subject : IEntity 
    {
        public int ID { get; set; }
        public int RequirementId { get; set; }
        public string Name { get; set; }
        public int MarkAcquired { get; set; }

        public virtual StudentReport Report { get; set; }
        public virtual Sponsorship Sponsorship { get; set; }
//        public ICollection<StudentSubject> StudentSubjects { get; set; }
//        public ICollection<SponsorshipRequirement> Requirements { get; set; } 
    }
}